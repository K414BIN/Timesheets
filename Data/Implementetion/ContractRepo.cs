using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementetion
{
    public class ContractRepo : IContractRepo

    {
 
        void IRepoBase<Contract>.Add(Contract item)
        {
            throw new NotImplementedException();
        }

        Contract IRepoBase<Contract>.GetItem(Guid ID)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Contract> IRepoBase<Contract>.GetItems()
        {
            throw new NotImplementedException();
        }

        void IRepoBase<Contract>.Update()
        {
            throw new NotImplementedException();
        }
    }
}
