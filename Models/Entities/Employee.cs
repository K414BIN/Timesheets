using System;
using System.Collections.Generic;

namespace Timesheets.Models.Entities
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
