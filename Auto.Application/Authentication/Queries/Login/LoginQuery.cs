using Auto.Application.Authentication.Common;
using Auto.InternalLib;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password
        ) : IRequest<ErrorOrNot<AuthenticationResult>>;
}
