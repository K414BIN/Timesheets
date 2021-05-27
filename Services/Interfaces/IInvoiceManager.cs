using System;
using System.Threading.Tasks;
using Timesheets.Models.Dto;

namespace Timesheets.Services.Interfaces
{
    public interface IInvoiceManager
    {
        Task<Guid> Create(InvoiceRequest  invoiceRequest);
    }
}