using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementetion
{
    public class SheetRepo : ISheetRepo
    {
       private static List<Sheet> Sheets {get;set;} = new List<Sheet>()
        {
            new Sheet {ID = Guid.Parse ("329CE9FA-CD09-9248-319C-87BBE43377D9"), Amount = 5, ContractID = Guid.Parse ("24031BB9-925E-1E47-DD0C-7281249936C0"), EmployeeID = Guid.Parse ("F5607940-EE4C-8D09-0091-7C32480A1302"), ServiceID = Guid.Parse ("4782D7A5-0F6C-2949-20E2-E70F9BFCE665") },
	        new Sheet {ID = Guid.Parse ("EA16D718-CBE6-DDD3-ED63-F450097F502A"), Amount = 4, ContractID = Guid.Parse ("6A220BC4-0328-9B14-7289-C5BB6033CB9C"), EmployeeID = Guid.Parse ("2D5B2BF3-7457-DB58-F9C7-9410BB7A206D"), ServiceID = Guid.Parse ("C0CCFECD-04BB-71E2-24A9-75F5D86E24AC") },
	        new Sheet {ID = Guid.Parse ("5DB4D076-14BF-3B02-07B7-32453B00EB77"), Amount = 7, ContractID = Guid.Parse ("C59B6984-FA6E-8B53-EDE1-7421C66560ED"), EmployeeID = Guid.Parse ("8D0319F2-8DCA-1B3F-5BF2-74BA7AF0BB39"), ServiceID = Guid.Parse ("73C406F8-0865-DBED-86CF-EB25E03BB1A9" )},
	        new Sheet {ID = Guid.Parse ("494BB96E-C344-7A5F-5FF1-DB9397AB901D"), Amount = 1, ContractID = Guid.Parse ("A439F419-1D36-0358-86F1-3C3B1BA7FF31"), EmployeeID = Guid.Parse ("C456E604-00FC-8C90-37CE-C15917FE96E3"), ServiceID = Guid.Parse ("A46F8F36-F94A-DB71-3A4F-37ABB3B03BE2" )},
	        new Sheet {ID = Guid.Parse ("2BC85B8E-D173-7F1A-C1D5-4C1BB659959C"), Amount = 3, ContractID = Guid.Parse ("CDA9357B-F615-F716-64DB-7D1B4DDFB1A0"), EmployeeID = Guid.Parse ("A362452C-DDD1-DDA1-39CC-9B23B9398AEC"), ServiceID = Guid.Parse ("BA2F751A-9ED0-A660-274A-A61B6B765F7E" )},

        };

  

        void IRepoBase<Sheet>.Add(Sheet item)
        {
            Sheets.Add(item);
        }

        Sheet IRepoBase<Sheet>.GetItem(Guid id)
        {
           return  Sheets.FirstOrDefault(x => x.ID == id);
        }

        IEnumerable<Sheet> IRepoBase<Sheet>.GetItems()
        {
            throw new NotImplementedException();
        }

        void IRepoBase<Sheet>.Update()
        {
            throw new NotImplementedException();
        }
    }
}
