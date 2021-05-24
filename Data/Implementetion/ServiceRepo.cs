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
            private readonly TimeSheetDbContext _context;

        public ServiceRepo(TimeSheetDbContext context)
        {
            _context = context;
        }

        Task IRepoBase<Service>.Add(Service item)
        {
            throw new NotImplementedException();
        }

        Task IRepoBase<Service>.Delete(Service item)
        {
            throw new NotImplementedException();
        }

        Task<Service> IRepoBase<Service>.GetItem(Guid ID)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Service>> IRepoBase<Service>.GetItems()
        {
            throw new NotImplementedException();
        }

        Task IRepoBase<Service>.Update(Service item)
        {
            throw new NotImplementedException();
        }
    }
}
