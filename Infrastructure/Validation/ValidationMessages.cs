using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Infrastructure.Validation
{
    public static class ValidationMessages
    {
        public const string InvalidValue = "Incorrect value";
        public const string SheetAmountError = "Amount should be between 1 and 8 hours.";
    }
}
