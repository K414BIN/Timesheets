namespace Timesheets.Models.Dto.Authentication
{
     public sealed  class TokenResponse
    {
          
         public string  Token (get; set;)
         public string RefreshToken  (string token) (get; set;)
    }
}