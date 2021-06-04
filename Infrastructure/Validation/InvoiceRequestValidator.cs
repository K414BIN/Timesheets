using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Timesheets.Models.Dto;

namespace Timesheets.Infrastructure.Validation
{
    public class InvoiceRequestValidator :AbstractValidator<InvoiceRequest>
    {
        public InvoiceRequestValidator()
        {
        

            RuleFor ( unit  => unit.ContractId)
                .NotEmpty();
            RuleFor ( unit  => unit.DateStart).LessThanOrEqualTo( x => x.DateEnd)
                      .WithMessage(ValidationMessages.RequestDataStartError);

            RuleFor ( unit  => unit.DateEnd).GreaterThanOrEqualTo( x => x.DateStart)
                      .WithMessage(ValidationMessages.RequestDataEndError);
           
        }
    }
}
