using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Services.Interfaces
{
    /// <summary>   Pеализация CRUD для класса Employee    </summary>
    public interface IEmployeeManager
    {
        Task<Employee> GetItem(Guid id);
        Task<IEnumerable<Employee>> GetItems();
        Task<Guid> Create(EmployeeCreateRequest EmployeeRequest);
        Task Update(Guid id, EmployeeCreateRequest EmployeeRequest);
        Task Delete(Guid id);
    }
}
