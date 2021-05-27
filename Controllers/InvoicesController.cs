using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Models.Dto;
using Timesheets.Services.Interfaces;

namespace Timesheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceManager _invoiceManager;
        
        public InvoicesController(IInvoiceManager invoiceManager)
        {
            _invoiceManager = invoiceManager;
        }
        
        /// <summary> Создает клиентский счет </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InvoiceRequest invoiceRequest)
        {
            var id = await _invoiceManager.Create(invoiceRequest);
            return Ok(id);
        }
    }
}
