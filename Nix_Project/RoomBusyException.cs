using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nix_Project
{
    class RoomBusyException : Exception
    {
        public RoomBusyException() { }

        public RoomBusyException(string message)
            : base(message) { }

        public RoomBusyException(string message, Exception inner)
            : base(message, inner) { }
    }
}
