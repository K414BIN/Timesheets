using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models.Dto
{
    public class SheetCreateRequest
    {
        public DateTime Date  {get;set;}
        public Guid ContractID {get;set;}
        public Guid ServiceID  {get;set;}
        public int Amount  {get;set;}
        public Guid EmployeeID  {get;set;}
    }
}
