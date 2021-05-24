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

namespace Timesheets.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class SheetController : ControllerBase
    {
        private readonly ISheetManager _sheetManager;

             public SheetController(ISheetManager sheetManager)
            {
                _sheetManager = sheetManager;
            }


        [HttpGet("getbyid/{id}")]
        public IActionResult Get([FromRoute] Guid id) 
            {
            var result =_sheetManager.GetItem(id);

            return Ok(result);
            }
        
        [HttpPost("create")]
        public IActionResult Create([FromBody] SheetCreateRequest sheet)
        {
            
            var id =_sheetManager.Create(sheet);
            return Ok(id);
        }
    }
}
