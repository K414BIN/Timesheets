using System;
using System.Collections.Generic;
using System.Linq;
using Timesheets.Models;
using System.Threading.Tasks;
using Timesheets.Models.Entities;

namespace Timesheets.Data.Interfaces
{
    public interface IServiceRepo :IRepoBase<Service>
    {
    }
}
