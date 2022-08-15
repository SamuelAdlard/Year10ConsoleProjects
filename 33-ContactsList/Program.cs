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
            AddContact("C", "C", "000", "22 Flinders Way Ocean Shores");
            AddContact("B", "Ba", "999", "2 Hart Court Ocean Shores");
            AddContact("B", "Be", "999", "2 Hart Court Ocean Shores");
            AddContact("A", "A", "999", "2 Hart Court Ocean Shores");
            AddContact("D", "D", "999", "2 Hart Court Ocean Shores");
            AddContact("E", "E", "999", "2 Hart Court Ocean Shores");
            // Hints: 
            // 1. Create a Contact class
            // 2. Create the properties and methods for this class
            // 3. Create a list or array of the contact class
            // 4. Create a menu system in a loop that gives you the various options you need
            // 5. Implement methods to add/remove contacts from the list
            // 6. Implement a method to search for contacts
            PrintList();
            SortContacts();
            PrintList();

            Console.ReadKey();
            // Extension:
            // 1. Figure out how to save / load to a file
        }

        static void AddContact(string firstname, string lastname, string number, string address)
        {
            contactList.Add(new Contact(firstname, lastname, number, address));


        }

        static void PrintList()
        {
            Console.WriteLine("Contacts: ");
            
            foreach (Contact contact in contactList)
            {
                string[] info = new string[4];
                info = contact.GetInformation();
                
                foreach (string text in info)
                {
                    Console.WriteLine(text);
                }
                Console.WriteLine();
            }
        }

        static void SortContacts()
        {
            int i = 0;
            bool endsort = false;
            bool sorted = true;
            do
            {
                endsort = false;
                
                if (sorted && i > contactList.Count - 2)
                {
                    endsort = true;
                }

                if (i > contactList.Count - 2)
                {
                    i = 0;
                }
                //checks if sorted
                
                //counts place in list
                
                //creats two arrays to store contact information
                string[] info1 = new string[3];
                string[] info2 = new string[3];
                //gets the contacts information
                info1 = contactList[i].GetInformation();
                info2 = contactList[i + 1].GetInformation();
                //keeps track of the letter being checked
                int placeInName = 0;
                //checks for a difference between letters
                bool foundDifference = false;
                sorted = true;
                do
                {
                    Console.WriteLine($" {info1[1][placeInName]} and {info2[1][placeInName]} ");

                    if ((int)info1[1][placeInName] > (int)info2[1][placeInName])
                    {
                        Console.WriteLine("Swap");
                        sorted = false;
                        foundDifference = true;
                        Contact firstContact = contactList[i];
                        contactList[i] = contactList[i + 1];
                        contactList[i + 1] = firstContact;
                        i++;
                        
                    }
                    else if ((int)info1[1][placeInName] < (int)info2[1][placeInName])
                    {
                        //check if already sorted
                        Console.WriteLine("Keep");
                        foundDifference = true;
                        
                        i++;
                    }
                   
                    if ((int)info1[1][placeInName] == (int)info2[1][placeInName])
                    {
                        foundDifference = false;
                        sorted = false;
                        placeInName++;
                        
                    }
                    
                } 
                while (!foundDifference);

                
            }
            while (!endsort);


            Console.WriteLine("list sorted");

        }

        static void Swap()
        {

        }



    }
}
