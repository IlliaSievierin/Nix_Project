using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nix_Project
{
    [Serializable]
     class Hotel
    {
        public Hotel()
        {
            Lodgers      = new List<Lodger>();
            Rooms        = new List<Room>();
            Reservations = new List<Reservation>();
        }
        public List<Lodger> Lodgers { get; private set; }

        public List<Room> Rooms { get; private set; }

        public List<Reservation> Reservations { get; private set; }

        private void AddLodger(Lodger lodger)
        {
            if (!Lodgers.Contains(lodger))
            {
                Lodgers.Add(lodger);
            }
        }

        public void AddRoom(Room room)
        {
            if (Rooms.Where(r => r.Number == room.Number).Count() == 0)
            {
                Rooms.Add(room);
            }
            else
            {
                throw new Exception();
            }
        }
        public void DeleteRoom(int number)
        {
            if (Rooms.Where(r => r.Number == number).Count() > 0)
            {
                Rooms.Remove(Rooms.Where(r => r.Number == number).FirstOrDefault());
            }
            else
            {
                throw new RoomNotFoundException();
            }
        }
        public void MakeReservation(Lodger lodger,Room room, DateTime arrivalDate,DateTime departureDate)
        {
            AddLodger(lodger);
            if(Rooms.Contains(room))
            {
                if (Reservations.Where(r => r.HotelRoom.Equals(room) &&  
                ((r.ArrivalDate <= arrivalDate) && (r.DepartureDate >= arrivalDate) ||
                ((r.ArrivalDate <= departureDate) && (r.DepartureDate >= departureDate)) ||
                ((r.ArrivalDate >= arrivalDate) && (r.DepartureDate <= departureDate)))).Count() == 0) 
                {
                    Reservations.Add(new Reservation(lodger, room, arrivalDate, departureDate));
                }
                else
                {
                    throw new RoomBusyException();
                }
            }
            else
            {
                throw new RoomNotFoundException();
            }

        }

        public int NumberOfFreeRooms(DateTime arrivalDate, DateTime departureDate)
        {
            return Rooms.Count() - Reservations.Where(r =>
                (((r.ArrivalDate <= arrivalDate) && (r.DepartureDate >= arrivalDate)) ||
                ((r.ArrivalDate <= departureDate) && (r.DepartureDate >= departureDate)) ||
                ((r.ArrivalDate >= arrivalDate) && (r.DepartureDate <= departureDate)))).Select(r=>r.HotelRoom).Count();
        }
        public void CheckIn(Lodger lodger, Room room, DateTime arrivalDate, DateTime departureDate)
        {
            Reservation reservations = Reservations.Where(r => r.Renter == lodger && r.HotelRoom == room && r.ArrivalDate == arrivalDate && r.DepartureDate == departureDate).FirstOrDefault();
            if (reservations != null)
            {
                reservations.RenterCheckIn();
            }
            else
            {
                throw new ReservationNotFoundException();
            }
        }
        public void CheckOut(Lodger lodger, Room room, DateTime arrivalDate, DateTime departureDate)
        {
            Reservation reservations = Reservations.Where(r => r.Renter == lodger && r.HotelRoom == room && r.ArrivalDate == arrivalDate && r.DepartureDate == departureDate).FirstOrDefault();
            if (reservations != null)
            {
                reservations.RenterCheckOut();
            }
            else
            {
                throw new ReservationNotFoundException();
            }
        }




    }
}
