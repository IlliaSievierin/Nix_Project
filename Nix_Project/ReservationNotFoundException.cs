using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nix_Project
{
    [Serializable]
    class ReservationNotFoundException : Exception
    {
        public ReservationNotFoundException() { }

        public ReservationNotFoundException(string message)
            : base(message) { }

        public ReservationNotFoundException(string message, Exception inner)
            : base(message, inner) { }
    }
}
