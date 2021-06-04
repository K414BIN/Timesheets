using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models.Entities
{
    /// <summary>
    /// Информация о владельце контракта
    /// </summary>
    public class Client
    {
          public bool IsDeleted  {get;set;}
          public Guid User {get;set;}
          public Guid ID {get;set;}
    }
}
