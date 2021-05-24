using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementetion
{
    public class ClientRepo : IClientRepo
    {
        private readonly TimeSheetDbContext _context;

        public ClientRepo(TimeSheetDbContext context)
        {
            _context = context;
        }

        Task IRepoBase<Client>.Add(Client item)
        {
            throw new NotImplementedException();
        }

        Task IRepoBase<Client>.Delete(Client item)
        {
            throw new NotImplementedException();
        }

        Task<Client> IRepoBase<Client>.GetItem(Guid ID)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Client>> IRepoBase<Client>.GetItems()
        {
            throw new NotImplementedException();
        }

        Task IRepoBase<Client>.Update(Client item)
        {
            throw new NotImplementedException();
        }
    }
}
