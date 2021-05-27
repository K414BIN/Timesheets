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
        public async Task<IActionResult> Create([FromBody] UserCreateRequest request)
        {            
            var id =await _userManager.Create(request);
            return Ok(id);
        }

        /// <summary>
        /// Возвращает одного пользователя по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("userid/{id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id) 
        {
           var result =await _userManager.GetItem(id);
           return Ok(result);
        }

        /// <summary>
        /// Возвращает список всех пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var result = await _userManager.GetItems();
            return Ok(result);
        }

         /// <summary> Удаляет пользователя с заданным id /// </summary>
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] Guid id)
        {
            await _userManager.Delete(id);
        }

        /// <summary> Обновляет пользователя по ID          </summary>
        
        [HttpPut("{id}")]
        public async Task Update([FromRoute] Guid id, [FromBody] UserCreateRequest userRequest)
        {
            await _userManager.Update(id, userRequest);   
        }

    }
}
