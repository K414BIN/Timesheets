using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Timesheets.Models.Entities;
using Timesheets.Services.Managers.Interfaces;

namespace Timesheets.Services.Managers.Implementetion
{
    public class SheetManager : ISheetManager
    {
        private readonly ISheetRepo _sheetRepo;

        public SheetManager(ISheetRepo sheetRepo)
        {
          _sheetRepo = sheetRepo;
        }

        public async Task<Sheet> GetItem(Guid id)
        {
            return await _sheetRepo.GetItem(id);
        }

        public async Task<IEnumerable<Sheet>> GetItems()
        {
            return await _sheetRepo.GetItems();
        }

        public async Task<Guid> Create( SheetCreateRequest sheetRequest)
        {
            var sheet = new Sheet
            {
                ID = Guid.NewGuid(),
                Amount = sheetRequest.Amount,
                ContractID = sheetRequest.ContractID,
                Date = sheetRequest.Date,
                EmployeeID = sheetRequest.EmployeeID,
                ServiceID = sheetRequest.ServiceID
            };

            sheet.IsApproved = true;
            sheet.ApprovedDate = DateTime.Now;
            await _sheetRepo.Add(sheet);
            return sheet.ID;
        }

        public async Task Update(Guid id, SheetCreateRequest sheetRequest)
        {
            var sheet = new Sheet
            {
                ID = id,
                Amount = sheetRequest.Amount,
                ContractID = sheetRequest.ContractID,
                Date = sheetRequest.Date,
                EmployeeID = sheetRequest.EmployeeID,
                ServiceID = sheetRequest.ServiceID
            };
            
            await _sheetRepo.Update(sheet);
        }
    }
}
