using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Timesheets.Models.Entities;
using Timesheets.Services.Aggregates.InvoiceAggregate;
using Timesheets.Services.Managers.Interfaces;
using Timesheets.Services.ValueObjects;

namespace Timesheets.Services.Managers.Implementetion
{
    public class InvoiceManager : IInvoiceManager 
    {
        private readonly IInvoiceRepo _invoiceRepo;
        private readonly IInvoiceAggregateRepo _invoceAggregateRepo;
    

        public InvoiceManager(IInvoiceRepo invoiceRepo, ISheetRepo sheetRepo)
        {
            _invoiceRepo = invoiceRepo;
           // _sheetRepo = sheetRepo;
        }

        public async Task<Guid> Create(InvoiceRequest invoiceRequest)
        {
            var invoice = InvoiceAggregate.Create (invoiceRequest.ContractId,invoiceRequest.DateStart,invoiceRequest.DateEnd);
            var sheetsToInclude = await _invoceAggregateRepo.GetSheets(invoiceRequest.ContractId,invoiceRequest.DateStart,invoiceRequest.DateEnd);
            
            invoice.IncludeSheets(sheetsToInclude);

            await _invoiceRepo.Add(invoice);
            return invoice.ID;
        }
    }
}
