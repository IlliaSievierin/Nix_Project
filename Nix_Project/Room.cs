using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nix_Project
{
    [Serializable]
    class Room
    {
        public Room(int number, int price, int numberOfSeats, string category)
        {
            Number        = number;
            Price         = price;
            NumberOfSeats = numberOfSeats;
            Category      = category;
        }
        public int Number { get; private set; }

        public int Price { get; private set; }

        public int NumberOfSeats { get; private set; }

        public string Category { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Room room = (Room)obj;
                return (Number == room.Number) && (Price == room.Price) && (NumberOfSeats == room.NumberOfSeats) && (Category == room.Category);
            }
        }
    }
}
