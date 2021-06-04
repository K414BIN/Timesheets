using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Timesheets.Models.Dto.Authentication
{
     public interface IUserService
    {
            TokenResponse Authenticate(string user, string password);
            string RefreshToken(string token);
        	bool IsUserNameAlreadyExist(string firstName);
     }
}
