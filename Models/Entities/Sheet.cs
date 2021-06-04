using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models.Entities
{
    /// <summary>
    /// Информация о затраченном времени сотрудника
    /// </summary>
    public class Sheet
    {   
        public Guid ID {get; protected set;}
        public DateTime  ApprovedDate {get;protected set;}
        public DateTime Date  {get;protected set;}
        public Guid ContractID {get;protected set;}
        public Guid ServiceID  {get;protected set;}
        public int Amount  {get;protected set;}
        public Guid EmployeeID  {get;protected set;}
        public Guid? InvoiceId  {get;protected set;}
        public bool IsApproved  {get;protected set;}

        public Employee Employee {get;set; }
        public Service Service   {get;set; }
        public Contract Contract {get;set; }
        public Invoice Invoice   {get;set; }
    }
}
