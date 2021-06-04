using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Entities;

namespace Timesheets.Infrastructure.Validation
{
    internal interface IUserValidationService : IValidationService<User>
    {
        
    }
}
