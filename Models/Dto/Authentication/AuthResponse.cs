﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models.Dto.Authentication
{
    internal sealed class AuthResponse
    {
        public string Password { get; set; }
    	
    	public RefreshToken LatestRefreshToken { get; set; }

    }
}
