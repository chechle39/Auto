﻿using Auto.InternalLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class AuthenticationError
        {
            public static Error InvalidCredentials => Error.Validation(code: "Authen.InvalidCred", description: "Invalid credentials");
        }
    }
    
}
