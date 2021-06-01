using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementetion
{
    public class ContractRepo : IContractRepo
    {
        private readonly TimeSheetDbContext _context;

        public ContractRepo(TimeSheetDbContext context)
        {
            _context = context;
        }

        public async Task Add(Contract item)
        {
 
            await _context.Contracts.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Contract item)
        {
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async  Task<Contract> GetItem(Guid ID)
        {
            var result = await _context.Contracts.FindAsync(ID);
            return result;
        }

        public async Task<IEnumerable<Contract>> GetItems()
        {
            var result = await _context.Contracts.ToListAsync();
            return result;
        }

         public async Task Update(Contract item)
        {
             _context.Contracts.Update(item);
            await _context.SaveChangesAsync();
        }

        
        public async Task<bool?> CheckContractIsActive(Guid id)
        {
            var contract = await _context.Contracts.FindAsync(id);
            var now = DateTime.Now;
            var isActive = now <= contract?.DateEnd && now >= contract?.DateStart;
            
            return isActive;
        }
    }
}
