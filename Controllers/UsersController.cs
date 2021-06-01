using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Data.Implementetion;
using Timesheets.Infrastructure.Validation;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Timesheets.Models.Dto.Authentication;
using Timesheets.Services.Interfaces;

namespace Timesheets.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public sealed class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserManager _userManager;
        
        public UsersController(IUserService userService, IUserManager userManager)
        {
               _userService = userService;
               _userManager = userManager;
        }

        [AllowAnonymous]
    	[HttpPost("authenticate")]
    	public IActionResult Authenticate([FromQuery] string user, string password)
    	{
        	TokenResponse token = _userService.Authenticate(user, password);
        	if (token is null)
        	{
            	return BadRequest(new {message = "Username or password is incorrect"});
        	}
            SetTokenCookie(token.RefreshToken);
        	return Ok(token);
    	}

    	[Authorize]
    	[HttpPost("refresh-token")]
    	public IActionResult Refresh()
    	{
        	string oldRefreshToken = Request.Cookies["refreshToken"];
        	string newRefreshToken = _userService.RefreshToken(oldRefreshToken);
 
        	if (string.IsNullOrWhiteSpace(newRefreshToken))
        	{
            	return Unauthorized(new { message = "Invalid token" });
        	}
        	SetTokenCookie(newRefreshToken);	
        	return Ok(newRefreshToken);
    	}

    	private void SetTokenCookie(string token)
    	{
        	var cookieOptions = new CookieOptions
        	{
            	HttpOnly = true,
            	Expires = DateTime.UtcNow.AddDays(7)
        	};	
            Response.Cookies.Append("refreshToken", token, cookieOptions);
    	}

        [HttpPost("create")]
    	public IActionResult Create([FromBody] UserCreateRequest user)
        {
            IOperationResult<User> result = (IOperationResult<User>)_userManager.CreateUser(user);
                

            if (result.Succeed)
            {
                return Created(new Uri($"users/{result.Result.ID}"), result);
            }

            return BadRequest(result);
        
    	}
	}
    
}
