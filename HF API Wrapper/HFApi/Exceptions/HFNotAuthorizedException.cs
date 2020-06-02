using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFApi.Exceptions
{
    class HFNotAuthorizedException : Exception
    {
        public HFNotAuthorizedException() { }

        public HFNotAuthorizedException(string message) : base(message) { }
    }
}
