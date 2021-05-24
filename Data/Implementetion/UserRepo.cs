using System;
using System.Collections.Generic;
using System.Linq;
using Timesheets.Data.Interfaces;
using Timesheets.Models;
using System.Threading.Tasks;

namespace Timesheets.Data.Implementetion
{
    public class UserRepo : IUserRepo
    {
    

        void IRepoBase<User>.Add(User item)
        {
            throw new NotImplementedException();
        }

        User IRepoBase<User>.GetItem(Guid ID)
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> IRepoBase<User>.GetItems()
        {
            throw new NotImplementedException();
        }

        void IRepoBase<User>.Update()
        {
            throw new NotImplementedException();
        }
    }
}
