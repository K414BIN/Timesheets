using System;
using System.Collections.Generic;

namespace Timesheets.Models.Entities
{
    public class Invoice
    {
          public Guid ContractID {get;set;}
          public Guid ID {get;set;}
          public DateTime DateStart  {get;set;}
          public DateTime DateEnd  {get;set;}
          public decimal Sum   {get;set;}
          public Contract Contract  {get;set;}
          public List<Sheet> Sheets {get; set;} = new  List<Sheet>();
    }
}