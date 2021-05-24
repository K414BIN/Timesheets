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
    

        void IRepoBase<Client>.Add(Client item)
        {
            throw new NotImplementedException();
        }

        Client IRepoBase<Client>.GetItem(Guid ID)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Client> IRepoBase<Client>.GetItems()
        {
            throw new NotImplementedException();
        }

        void IRepoBase<Client>.Update()
        {
            throw new NotImplementedException();
        }
    }
}
