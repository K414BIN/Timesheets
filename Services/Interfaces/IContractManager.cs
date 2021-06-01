using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Services.Interfaces
{
    public interface IContractManager
    {
         Task<bool?> CheckContractIsActive(Guid id);
    }
}