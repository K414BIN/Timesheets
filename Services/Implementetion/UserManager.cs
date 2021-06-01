using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Timesheets.Services.Interfaces;

namespace Timesheets.Services.Implementetion
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepo _userRepo;

        public UserManager( IUserRepo userRepo)
        {
          _userRepo = userRepo;
        }

        public async Task<User> GetUser(LoginRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var passwordHash = GetPasswordHash(request.Password);
            var user = await _userRepo.GetByLoginAndPasswordHash(request.Login, passwordHash);
            return user;
        }

        public async Task<Guid> CreateUser(UserCreateRequest user)
        {
            var sheet = new User
            {
                ID=Guid.NewGuid(),
                Username = user.Username,
                PasswordHash = GetPasswordHash(user.Password),
                Role = user.Role
            };

            await _userRepo.CreateUser(sheet);
            return sheet.ID;
        }

        static byte[] GetPasswordHash (string password)
        {
            using ( var sha1 =  new SHA1CryptoServiceProvider())
            {
                return sha1.ComputeHash(Encoding.Unicode.GetBytes(password));
            }
        }

        /// <summary>
        /// Не понимаю как реализовать удаление через метод
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(Guid id)
        {
           throw new NotImplementedException();
        }

        public async Task<User> GetItem(Guid id)
        {
           return await _userRepo.GetItem(id);
        }

        public async Task<IEnumerable<User>> GetItems()
        {
            return await _userRepo.GetItems();
        }
    
        public async Task Update(Guid id, UserCreateRequest userRequest)
        {
            var user = new User
            {
                ID = id,
                Username=userRequest.Username
            };

           await _userRepo.Update(user);
        }
    }
}
