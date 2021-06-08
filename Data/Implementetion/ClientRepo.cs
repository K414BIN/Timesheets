using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Entities;

namespace Timesheets.Data.Implementetion
{
    public class ClientRepo : IClientRepo
    {
        private readonly TimeSheetDbContext _context;

        public ClientRepo(TimeSheetDbContext context)
        {
            _context = context;
        }

        public async Task Add(Client item)
        {
            await _context.Clients.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Client item)
        {
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async  Task<Client> GetItem(Guid ID)
        {
            var result = await _context.Clients.FindAsync(ID);
            return result;
        }

        public async Task<IEnumerable<Client>> GetItems()
        {
            var result = await _context.Clients.ToListAsync();
            return result;
        }

        public async Task Update(Client item)
        {
             _context.Clients.Update(item);
            await _context.SaveChangesAsync();
        }

    }
}
