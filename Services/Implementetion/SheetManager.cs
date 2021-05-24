using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Timesheets.Services.Interfaces;

namespace Timesheets.Services.Implementetion
{
    public class SheetManager : ISheetManager
    {
          private readonly ISheetRepo _sheetRepo;

        public SheetManager(ISheetRepo sheetRepo)
        {
          _sheetRepo = sheetRepo;
        }

        Guid ISheetManager.Create(SheetCreateRequest sheetRequest)
        {
           var sheet = new Sheet()
            {
                Amount = sheetRequest.Amount,
                ID = Guid.NewGuid(),
                Date = sheetRequest.Date,
                EmployeeID = sheetRequest.EmployeeID,
                ContractID = sheetRequest.ContractID,
                ServiceID = sheetRequest.ServiceID
            };
            _sheetRepo.Add(sheet);
            return  sheet.ID;
        }

        Sheet ISheetManager.GetItem(Guid id)
        {
            return _sheetRepo.GetItem(id);
        }
    }
}
