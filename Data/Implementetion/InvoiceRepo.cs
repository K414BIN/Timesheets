using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementetion
{
    public class InvoiceRepo : IInvoiceRepo
    {
        private readonly TimeSheetDbContext _context;

        public InvoiceRepo(TimeSheetDbContext context)
        {
            _context = context;
        }

        public async Task Add(Invoice item)
        {
            await _context.Invoices.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Invoice item)
        {
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async  Task<Invoice> GetItem(Guid ID)
        {
            var result = await _context.Invoices.FindAsync(ID);
            return result;
        }

        public async Task<IEnumerable<Invoice>> GetItems()
        {
            var result = await _context.Invoices.ToListAsync();
            return result;
        }

        public async Task Update(Invoice item)
        {
             _context.Invoices.Update(item);
            await _context.SaveChangesAsync();
        }

    }
}
