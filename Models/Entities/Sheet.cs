﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models.Entities
{
    /// <summary>
    /// Информация о затраченном времени сотрудника
    /// </summary>
    public class Sheet
    {
        public DateTime ApproveDate  {get;set;}
        public Guid ID {get;set;}
        public DateTime Date  {get;set;}
        public Guid ContractID {get;set;}
        public Guid ServiceID  {get;set;}
        public int Amount  {get;set;}
        public Guid EmployeeID  {get;set;}
        public Guid? InvoiceId  {get;set;}
        public bool IsApproved  {get;set;}
        public Employee Employee {get;set;}
        public Service Service {get;set;}
        public Contract Contract  {get;set;}
        public Invoice Invoice {get;set;}
    }
}