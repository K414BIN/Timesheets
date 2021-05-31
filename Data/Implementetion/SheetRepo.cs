using System;
using System.Collections.Generic;
using Timesheets.Data;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Timesheets.Data.Implementetion
{
    public class SheetRepo : ISheetRepo
    {
       
        private readonly TimeSheetDbContext _context;

        public SheetRepo(TimeSheetDbContext context)
        {
            _context = context;
        }

        public async Task Add(Sheet item)
        { 
            _context.Sheets.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Sheet item)
        { 
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Sheet> GetItem(Guid ID)
        {
            var result = await _context.Sheets.FindAsync(ID);
            return result;
        }

        public async Task<IEnumerable<Sheet>> GetItems()
        {
            var result  = await _context.Sheets.ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Sheet>> GetItemsForInvoice(Guid contractId, DateTime dateStart, DateTime dateEnd)
        {
              
           var sheets =  await _context.Sheets
                .Where(x => x.ContractID == contractId)
                .Where(x => x.Date >= dateStart && x.Date <= dateEnd)
                .ToListAsync();

            return sheets;
        }

        public async Task Update(Sheet item)
        {
           _context.Sheets.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
