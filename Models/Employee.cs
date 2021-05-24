using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{

    /// <summary>
    /// Информация о сотрудникe
    /// </summary>
    public class Employee
    {
           public Guid UserID {get;set;}
           public Guid ID {get;set;}

        public ICollection<Sheet> Sheets  {get;set;}
    }
}
