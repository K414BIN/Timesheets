using System;
using System.Threading.Tasks;
using Timesheets.Models.Dto;
using Timesheets.Models.Entities;

namespace Timesheets.Services.Managers.Interfaces
{
    public interface IInvoiceManager
    {
        Task<Guid> Create(InvoiceRequest  invoiceRequest);
    }
}