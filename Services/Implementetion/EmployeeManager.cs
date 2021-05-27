using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Timesheets.Services.Interfaces;

namespace Timesheets.Services.Implementetion
{
    public class EmployeeManager:IEmployeeManager
    {
        private readonly IEmployeeRepo _employeeRepo;

        public  EmployeeManager(IEmployeeRepo employeetRepo)
        {
          _employeeRepo =employeetRepo;
        }

        public async Task<Guid> Create(EmployeeCreateRequest EmployeeRequest)
          {
            var employee = new Employee
            {
                ID = Guid.NewGuid(),
                Sheets =  EmployeeRequest.Sheets,
                UserID =  EmployeeRequest.UserId
            };

            await _employeeRepo.Add(employee);
            return  employee.ID;
        }

        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetItem(Guid id)
        {
           return await _employeeRepo.GetItem(id);
        }

        public async Task<IEnumerable<Employee>>  GetItems()
        {
             return await _employeeRepo.GetItems();
        }

        public async Task Update(Guid id, EmployeeCreateRequest EmployeeRequest)
        {
            var employee = new Employee
            {
                ID = id,
                Sheets =  EmployeeRequest.Sheets,
                UserID =  EmployeeRequest.UserId
            };

            await _employeeRepo.Update(employee);
        }
    }
}
