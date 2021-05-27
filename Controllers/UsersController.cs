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
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _userManager;
        
        public UsersController(IUserManager userManager)

            {
                _userManager = userManager;
            }

          
        [HttpPost("create")]
        public IActionResult Create([FromBody] UserCreateRequest request)
        {            
            var id =_userManager.Create(request);
            return Ok(id);
        }

        [HttpGet("userid/{id}")]
        public IActionResult GetOne([FromRoute] Guid id) 
        {
           var result =_userManager.GetItem(id);
           return Ok(result);
        }

        [HttpGet]
        public IActionResult Get() 
        {
            var result = _userManager.GetItems();
            return Ok(result);
        }
    }
}
