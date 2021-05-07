using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nix_Project
{
    [Serializable]
    class Reservation
    {
        public Reservation(Lodger lodger, Room room, DateTime arrivalDate, DateTime departureDate)
        {
            Renter        = lodger;
            HotelRoom     = room;
            ArrivalDate   = arrivalDate;
            DepartureDate = departureDate;
            CheckIn       = false;
            CheckOut      = false;
        }
        public Lodger Renter { get; private set; }

        public Room HotelRoom { get; private set; }

        public DateTime ArrivalDate { get; private set; }

        public DateTime DepartureDate { get; private set; }

        public bool CheckIn { get; private set; }

        public bool CheckOut { get; private set; }

        public void RenterCheckIn()
        {
            CheckIn = true;
        }

        public void RenterCheckOut()
        {
            CheckOut = true;
        }
    }
}
