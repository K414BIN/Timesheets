using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Timesheets.Models.Entities;

namespace Timesheets.Services.Managers.Interfaces
{
     public  interface ISheetManager
    {
       
        Task<Sheet> GetItem(Guid id);
        Task<IEnumerable<Sheet>> GetItems();
        Task<Guid> Create(SheetCreateRequest sheet);
        Task Update(Guid id, SheetCreateRequest sheetRequest);
    }
}
