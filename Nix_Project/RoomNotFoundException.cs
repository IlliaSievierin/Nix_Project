using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nix_Project
{
    [Serializable]
    class RoomNotFoundException : Exception
    {
        public RoomNotFoundException() { }

        public RoomNotFoundException(string message)
            : base(message) { }

        public RoomNotFoundException(string message, Exception inner)
            : base(message, inner) { }
    }
}
