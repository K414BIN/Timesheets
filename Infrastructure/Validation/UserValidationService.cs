using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Timesheets.Models;
using Timesheets.Models.Dto.Authentication;

namespace Timesheets.Infrastructure.Validation
{
     internal sealed class UserValidationService : FluentValidationService<User> , IUserValidationService
    {
        private readonly IUserService _userService;

          	public UserValidationService(IUserService userService)
    	{
            _userService = userService;
        	
            RuleFor(x => x.FirstName)
                .NotEmpty()
            	.WithMessage("Имя не должно быть пустым")
            	.WithErrorCode("BRL-100.1");
        	
            RuleFor(x => x.LastName)
    	        .NotEmpty()
            	.WithMessage("Фамилия не должна быть пустым")
            	.WithErrorCode("BRL-100.2");
        	
            RuleFor(x => x.MiddleName)
                .NotEmpty()
            	.WithMessage("Отчество не должно быть пустым")
            	.WithErrorCode("BRL-100.3");
 
            RuleFor(x => x.FirstName).Custom((s, context) =>
        	{
                if (_userService.IsUserNameAlreadyExist(s))
        	    {
                    context.AddFailure(new ValidationFailure(
                    	nameof(User.FirstName), "Пользователь уже существует")
                	{
                    	ErrorCode = "BRL-100.4"
                    });
                }
            });
    	}
	}   
}
