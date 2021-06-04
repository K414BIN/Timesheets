using System;
using System.Collections.Generic;
using Timesheets.Services;
using Timesheets.Services.ValueObjects;

namespace Timesheets.Models.Entities
{
    public class Invoice
    {
          public Guid ContractID {get;set;}
          public Guid ID {get;set;}
          public DateTime DateStart  {get;set;}
          public DateTime DateEnd  {get;set;}
          public  Money Sum   {get;set;}
          public Contract Contract  {get;set;}
          public List<Sheet> Sheets {get; set;} = new  List<Sheet>();
    }
}