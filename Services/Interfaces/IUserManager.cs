using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Services.Interfaces
{
    /// <summary>
    /// реализация CRUD для класса User 
    /// </summary>
    public interface IUserManager
    {
        Task<User> GetItem(Guid id);
        Task<IEnumerable<User>> GetItems();
        Task<Guid> Create(UserCreateRequest userRequest);
        Task Update(Guid id, UserCreateRequest userRequest);
        Task Delete(Guid id);
    }
}
