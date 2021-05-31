using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Models.Dto;
using Timesheets.Models.Dto.Authentication;


namespace Timesheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UsersController(IUserService userService)

            {
               _userService = userService;

                //_userManager = UserManager;
            }

        //[HttpPost("create")]
        //public async Task<IActionResult> CreateUser([FromBody] UserCreateRequest request)
        //{
        //    var response = await _userManager.CreateUser(request);
        //    return Ok(response);
        //}

        ///// <summary>
        ///// Возвращает одного пользователя по ID
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet("userid/{id}")]
        //public async Task<IActionResult> GetOne([FromRoute] Guid id) 
        //{
        //   var result =await _userManager.GetItem(id);
        //   return Ok(result);
        //}

        ///// <summary>
        ///// Возвращает список всех пользователей
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> Get() 
        //{
        //    var result = await _userManager.GetItems();
        //    return Ok(result);
        //}

        // /// <summary> Удаляет пользователя с заданным id /// </summary>
        //[HttpDelete("{id}")]
        //public async Task Delete([FromRoute] Guid id)
        //{
        //    await _userManager.Delete(id);
        //}

        ///// <summary> Обновляет пользователя по ID          </summary>

        //[HttpPut("{id}")]
        //public async Task Update([FromRoute] Guid id, [FromBody] UserCreateRequest userRequest)
        //{
        //    await _userManager.Update(id, userRequest);   
        //}

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
	}
    
}
