using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Models.Dto;
using Timesheets.Services.Managers.Interfaces;

namespace Timesheets.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        
        private readonly IContractManager _contractManager;

        private readonly IInvoiceManager _invoiceManager;
        
        /// <summary> Cоздает клиентский счет </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InvoiceRequest request)
        {
            var isAllowedToCreate = await _contractManager.CheckContractIsActive(request.ContractId);
			if (isAllowedToCreate != null && !(bool)isAllowedToCreate)
			{
				return BadRequest($"Contract {request.ContractId} is not active or not found.");
			}
			
			var Id = await _invoiceManager.Create(request);
			return Ok(Id);
        }  
    }
}
