using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Models.Entities;
using Timesheets.Services.ValueObjects;

namespace Timesheets.Services.Aggregates.InvoiceAggregate
{
    public class InvoiceAggregate : Invoice
    {
        private readonly decimal _rate = 150;

        private InvoiceAggregate(){}

        public static InvoiceAggregate Create(Guid contractId, DateTime dateEnd, DateTime dateStart)
        {
            return new InvoiceAggregate()
            {
                ID = Guid.NewGuid(),
                ContractID = contractId,
                DateEnd = dateEnd,
                DateStart = dateStart
            };
        }

        public void IncludeSheets(IEnumerable<Sheet> sheets)
        {
            Sheets.AddRange(sheets);
            CalculateSum();
        }

        private void CalculateSum()
        {
            var amount = Sheets.Sum(x => x.Amount * _rate);
            Sum = Money.FromDecimal(amount);
        }
    
    }
}
