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
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;
        
        public EmployeesController(IEmployeeManager employeeManager)
        {
               _employeeManager = employeeManager;
        }

        /// <summary> создает работающего по найму (работника в дальнейшем)</summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] EmployeeCreateRequest request)
        {            
            var id =await _employeeManager.Create(request);
            return Ok(id);
        }

        /// <summary>
        /// Возвращает одного работника по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("userid/{id}")]
        public async Task<IActionResult> GetOne([FromRoute] Guid id) 
        {
           var result =await _employeeManager.GetItem(id);
           return Ok(result);
        }

        /// <summary>
        /// Возвращает список всех работников
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var result = await _employeeManager.GetItems();
            return Ok(result);
        }

         /// <summary> Удаляет работника с заданным id /// </summary>
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] Guid id)
        {
            await _employeeManager.Delete(id);
        }

        /// <summary> Обновляет работника по ID          </summary>
        [HttpPut("{id}")]
        public async Task Update([FromRoute] Guid id, [FromBody] EmployeeCreateRequest request)
        {
            await _employeeManager.Update(id, request);   
        }

    }
}
