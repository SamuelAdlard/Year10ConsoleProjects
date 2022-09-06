using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33_ContactsList
{
    class Contact
    {
        private string FirstName;
        private string LastName;
        private string Number;
        private string Address;

        public Contact(string firstname, string lastname, string number , string address)
        {
            FirstName = firstname;
            LastName = lastname;
            Number = number;
            Address = address;
        }

        public void ChangeName(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public void ChangeNumber(string NewNumber)
        {
            Number = NewNumber;
        }

        public void ChangeAddress(string NewAddress)
        {
            Address = NewAddress;
        }

        public string[] GetInformation()
        {
            string[] result = new string[4];
            result[0] = FirstName;
            result[1] = LastName;
            result[2] = Number;
            result[3] = Address;
            return result;
        }

    }
}
