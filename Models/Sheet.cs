using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    /// <summary>
    /// Информация о затраченном времени сотрудника
    /// </summary>
    public class Sheet
    {
        public Guid ID {get;set;}
        public DateTime Date  {get;set;}
        public Guid ContractID {get;set;}
        public Guid ServiceID  {get;set;}
        public int Amount  {get;set;}
        public Guid EmployeeID  {get;set;}
        public Guid? Invoiced  {get;set;}

         public Employee Employee {get;set;}
         public Service Service {get;set;}
         public Contract Contract  {get;set;}
         public Invoice Invoice {get;set;}

    }
}
