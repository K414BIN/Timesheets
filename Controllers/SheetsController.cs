using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Timesheets.Services.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Microsoft.AspNetCore.Authorization;

namespace Timesheets.Controllers
{
    [Produces("application/json")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class SheetsController : ControllerBase
    {
        private readonly ISheetManager _sheetManager;
        private readonly IContractManager _contractManager;

        public SheetsController(ISheetManager sheetManager, IContractManager contractManager)
        {
                _contractManager = contractManager;
                _sheetManager = sheetManager;
        }


        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id) 
        {
            var result =await _sheetManager.GetItem(id);
            return Ok(result);
        }
        
        [HttpPost("create")]
   
        public async Task<IActionResult> Create([FromBody] SheetCreateRequest sheet)
        {
            var isAllowedToCreate = await _contractManager.CheckContractIsActive(sheet.ContractID);

            if (isAllowedToCreate !=null && !(bool)isAllowedToCreate)
            {
                return BadRequest($"Contract {sheet.ContractID} is not active or not found.");
            }
            
            var id = await _sheetManager.Create(sheet);
            return Ok(id);
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = await _sheetManager.GetItems();
            return Ok(result);
        }

        
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SheetCreateRequest sheet)
        {
            var isAllowedToCreate = await _contractManager.CheckContractIsActive(sheet.ContractID);
            if (isAllowedToCreate !=null && !(bool)isAllowedToCreate)
            {
                return BadRequest($"Contract {sheet.ContractID} is not active or not found.");
            }
            await _sheetManager.Update(id, sheet);
            return Ok(id);
        }
    }
}
