using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Timesheets.Infrastructure.Constans;
using Timesheets.Models.Dto;

namespace Timesheets.Infrastructure.Validation
{
    public class SheetRequestValidator :AbstractValidator<SheetCreateRequest>
    {
        public SheetRequestValidator()
        {
            RuleFor( unit  => unit.Amount)
                    .InclusiveBetween(1,8)  
                    .WithMessage(ValidationMessages.SheetAmountError);

            RuleFor ( unit  => unit.ContractID)
                .NotEmpty();
            RuleFor ( unit  => unit.ServiceID)
                .NotEmpty();
            RuleFor ( unit  => unit.EmployeeID)
                .NotEmpty();
             
        }
    }
}
