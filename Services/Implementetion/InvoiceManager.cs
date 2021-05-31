﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Timesheets.Services.Interfaces;

namespace Timesheets.Services.Implementetion
{
    public class InvoiceManager : IInvoiceManager 
    {
         private readonly IInvoiceRepo _invoiceRepo;
        private readonly ISheetRepo _sheetRepo;

        public InvoiceManager(IInvoiceRepo invoiceRepo, ISheetRepo sheetRepo)
        {
            _invoiceRepo = invoiceRepo;
            _sheetRepo = sheetRepo;
        }

        public async Task<Guid> Create(InvoiceRequest invoiceRequest)
        {
            var invoice = new Invoice
            {
                ID = Guid.NewGuid(),
                ContractID = invoiceRequest.ContractId,
                DateEnd = invoiceRequest.DateEnd,
                DateStart = invoiceRequest.DateStart
            };

            var sheetsToInclude = await _sheetRepo
                .GetItemsForInvoice(invoiceRequest.ContractId, invoiceRequest.DateStart, invoiceRequest.DateEnd);

            invoice.Sheets.AddRange(sheetsToInclude);
            invoice.Sum = invoice.Sheets.Sum(x => x.Amount * 150);

            await _invoiceRepo.Add(invoice);

            return invoice.ID;
        }
    }
}