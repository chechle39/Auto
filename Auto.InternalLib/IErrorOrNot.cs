using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto.InternalLib
{
    public interface IErrorOrNot
    {
        List<Error>? Errors { get; }

        bool IsError { get; }
    }
}
