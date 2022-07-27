using System;
using System.Collections.Generic;

namespace _33_ContactsList
{
    class Program
    {
        static List<Contact> contactList = new List<Contact>();
        
        static void Main(string[] args)
        {
            // Challenge: Create a contact list that that can store a list of contacts (plus add, search, remove etc..)
            
            // Hints: 
            // 1. Create a Contact class
            // 2. Create the properties and methods for this class
            // 3. Create a list or array of the contact class
            // 4. Create a menu system in a loop that gives you the various options you need
            // 5. Implement methods to add/remove contacts from the list
            // 6. Implement a method to search for contacts

            // Extension:
            // 1. Figure out how to save / load to a file
        }

        static void AddContact(string firstname, string lastname, string number, string address)
        {
            contactList.Add(new Contact(firstname, lastname, number, address));


        }

        static void SortContacts()
        {

        }
    }
}
