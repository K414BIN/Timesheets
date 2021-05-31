using System;
using System.Collections.Generic;
using System.Linq;
using Timesheets.Data.Interfaces;
using Timesheets.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Timesheets.Data.Implementetion
{
    public class UserRepo : IUserRepo
    {
        
        private readonly TimeSheetDbContext _context;

        public UserRepo(TimeSheetDbContext context)
        {
            _context = context;
        }

        public  async Task<User> GetItem(Guid ID)
        {
            var result = await _context.Users.FindAsync(ID);
            return result;
        }

        public async Task<IEnumerable<User>> GetItems()
        {
           var result = await _context.Users.ToListAsync();
           return result;
        }

        public async Task Update(User item)
        {
             _context.Users.Update(item);
             await _context.SaveChangesAsync();
        }  

        public async Task Add(User item)
        {
             await _context.Users.AddAsync(item);
             await _context.SaveChangesAsync();  
        }   

        public async Task Delete(User item)
        {
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByLoginAndPasswordHash(string login, byte[] passwordHash)
        {
            return    await _context.Users
                                            .Where(x=> x.Username == login && x.PasswordHash == passwordHash)
                                            .FirstOrDefaultAsync();
        }

        public async  Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
