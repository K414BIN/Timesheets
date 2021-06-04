
namespace Timesheets.Infrastructure.Constans
{
    public static class ValidationMessages
    {
        public const string InvalidValue = "Incorrect value";
        public const string SheetAmountError = "Amount should be between 1 and 8 hours.";   
        public const string RequestDataStartError = "Start date should be less then or equal to the end date.";
        public const string RequestDataEndError = "End date should be greater then or equal to the start date.";
    }
}
