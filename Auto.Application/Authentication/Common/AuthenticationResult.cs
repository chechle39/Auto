using Auto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Application.Authentication.Common
{
    public record AuthenticationResult(
     User user,
     string Token
    );
}
