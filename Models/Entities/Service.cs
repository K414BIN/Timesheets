using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models.Entities
{

    /// <summary>
    /// Информация о предоставляемой услуге в рамках контракта
    /// </summary>
    public class Service
    {
           public Guid ID {get;set;}
           public string Name {get;set;}

           public ICollection<Sheet> Sheets  {get;set;}
    }
}
