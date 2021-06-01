using System;
using System.Collections.Generic;

namespace Timesheets.Models.Dto
{
    public class EmployeeCreateRequest
    {
        public Guid UserId { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Sheet> Sheets { get; set; }
    } 
}