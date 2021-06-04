using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementetion
{
    public class ServiceRepo : IServiceRepo
    {
            private readonly TimeSheetDbContext _context;

        public ServiceRepo(TimeSheetDbContext context)
        {
            _context = context;
        }

       public async Task Add(Service item)
        {
            await _context.Services.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Service item)
        {
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async  Task<Service> GetItem(Guid ID)
        {
            var result = await _context.Services.FindAsync(ID);
            return result;
        }

        public async Task<IEnumerable<Service>> GetItems()
        {
            var result = await _context.Services.ToListAsync();
            return result;
        }

        public async Task Update(Service item)
        {
             _context.Services.Update(item);
            await _context.SaveChangesAsync();
        }

    }
}
