using Auto.InternalLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class UserError
        {
            public static Error DuplicateEmail => Error.Conflict(code: "User.DuplicateEmail", description: "Email is already in use.");
        }
    }
    
}
