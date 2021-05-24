using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    /// <summary>
    /// Информация о пользователе системы
    /// </summary>
    public class User
    {
        public Guid ID {get;set;}
        public string Username {get;set;}
    }
}
