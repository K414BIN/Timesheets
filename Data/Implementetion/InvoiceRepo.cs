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
            await _context.Invoices.Addasync(item)

            await _context.SaveChangesAsync();
        }

        Task IRepoBase<Invoice>.Delete(Invoice item)
        {
            throw new NotImplementedException();
        }

        Task<Invoice> IRepoBase<Invoice>.GetItem(Guid ID)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Invoice>> IRepoBase<Invoice>.GetItems()
        {
            throw new NotImplementedException();
        }

        Task IRepoBase<Invoice>.Update(Invoice item)
        {
            throw new NotImplementedException();
        }
    }
}
