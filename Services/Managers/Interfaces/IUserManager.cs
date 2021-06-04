using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Timesheets.Models.Entities;

namespace Timesheets.Services.Managers.Interfaces
{
  
    public interface IUserManager
    {
          /// <summary> Возвращает пользователя по логину и паролю </summary>
        Task<User> GetUser(LoginRequest request);

        /// <summary> Создает нового пользователя </summary>
        Task<Guid> CreateUser(UserCreateRequest request);
        Task<User> GetItem(Guid id);
        Task<IEnumerable<User>> GetItems();
        //Task<Guid> Create(UserCreateRequest UserRequest);
        Task Update(Guid id, UserCreateRequest UserRequest);
        Task Delete(Guid id);
    }
}
