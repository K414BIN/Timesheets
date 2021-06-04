using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Timesheets.Models.Entities;

namespace Timesheets.Services.Managers.Interfaces
{
    public interface IContractManager
    {
         Task<bool?> CheckContractIsActive(Guid id);
    }
}