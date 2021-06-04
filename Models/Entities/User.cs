﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models.Entities
{
    /// <summary>
    /// Информация о пользователе системы
    /// </summary>
    public class User
    {
         
        public string FirstName {get; set;}
        public string LastName  {get; set;}
        public string MiddleName {get; set;}
        public Guid ID {get;set;}
        public string Username {get;set;}
        public byte[] PasswordHash { get; internal set; }
        public string Role { get; internal set; }
    }
}