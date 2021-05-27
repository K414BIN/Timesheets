﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Timesheets.Infrastructure.Extensions;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Timesheets.Models.Dto.Authentication;
using Timesheets.Services.Interfaces;

namespace Timesheets.Services.Implementetion
{
    public class LoginManager : ILoginManager
    {
        private readonly JwtAccessOptions _jwtAccessOptions;

        public LoginManager(IOptions<JwtAccessOptions> jwtAccessOptions)
        {
            _jwtAccessOptions = jwtAccessOptions.Value;
        }
        
        public Task<LoginResponse> Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.ID.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };

            var accessTokenRaw =  _jwtAccessOptions.GenerateToken(claims);
            var securityHandler = new JwtSecurityTokenHandler();
            var accessToken = securityHandler.WriteToken(accessTokenRaw);

            var loginResponse = new LoginResponse()
            {
                AccessToken = accessToken,
                ExpiresIn = accessTokenRaw.ValidTo.ToEpochTime()
            };

            return Task.FromResult(loginResponse);
        }
    }
}
