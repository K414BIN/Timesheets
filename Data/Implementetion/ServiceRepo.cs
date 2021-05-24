using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementetion
{
    public class ServiceRepo : IServiceRepo
    {
       

        void IRepoBase<Service>.Add(Service item)
        {
            throw new NotImplementedException();
        }

        Service IRepoBase<Service>.GetItem(Guid ID)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Service> IRepoBase<Service>.GetItems()
        {
            throw new NotImplementedException();
        }

        void IRepoBase<Service>.Update()
        {
            throw new NotImplementedException();
        }
    }
}
