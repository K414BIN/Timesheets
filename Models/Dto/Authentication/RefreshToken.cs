using System;

namespace Timesheets.Models.Dto.Authentication
{
    public sealed class RefreshToken
    {
        public string Token { get; set; }
    	
    	public DateTime Expires { get; set; }
    	
    	public bool IsExpired => DateTime.UtcNow >= Expires;

    }
}