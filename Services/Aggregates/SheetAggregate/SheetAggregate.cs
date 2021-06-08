using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models.Entities;
using Timesheets.Models.Dto;
using Timesheets.Models;

namespace Timesheets.Services.Aggregates.SheetAggregate
{
    public class SheetAggregate : Sheet
    {
        private SheetAggregate(){}

        public static SheetAggregate CreateFromSheetRequest(SheetCreateRequest sheetRequest)
        {
            return new SheetAggregate()
            {
                ID = Guid.NewGuid(),
                Amount = sheetRequest.Amount,
                ContractID = sheetRequest.ContractID,
                Date = sheetRequest.Date,
                EmployeeID = sheetRequest.EmployeeID,
                ServiceID = sheetRequest.ServiceID
            };
        }

        public void ApproveSheet()
        {
            IsApproved = true;
            ApprovedDate = DateTime.Now;
        }

        public void ChangeEmployee(Guid newEmployeeId)
        {
            EmployeeID = newEmployeeId;
        }
    }
}
