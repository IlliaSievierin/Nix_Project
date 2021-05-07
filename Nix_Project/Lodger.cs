using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nix_Project
{
    [Serializable]
    class Lodger
    {
        public Lodger(string fullName, DateTime dateOfBirth, string address)
        {
            FullName    = fullName;
            DateOfBirth = dateOfBirth;
            Address     = address;
        }
        public string FullName { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public string Address { get; private set; }
    }
}
