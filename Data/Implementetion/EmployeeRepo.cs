using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementetion
{
    public class EmployeeRepo : IEmployeeRepo
    {


        void IRepoBase<Employee>.Add(Employee item)
        {
            throw new NotImplementedException();
        }

        Employee IRepoBase<Employee>.GetItem(Guid ID)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Employee> IRepoBase<Employee>.GetItems()
        {
            throw new NotImplementedException();
        }

        void IRepoBase<Employee>.Update()
        {
            throw new NotImplementedException();
        }
    }
}
