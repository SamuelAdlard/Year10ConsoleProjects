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
            AddContact("Sam", "Adlard", "000", "22 Flinders Way Ocean Shores");
            AddContact("Tom1", "Kuznik", "999", "2 Hart Court Ocean Shores");
            AddContact("Tom2", "Bghh", "999", "2 Hart Court Ocean Shores");
            AddContact("Tom3", "Uznik", "999", "2 Hart Court Ocean Shores");
            AddContact("Tom4", "Kaznik", "999", "2 Hart Court Ocean Shores");
            // Hints: 
            // 1. Create a Contact class
            // 2. Create the properties and methods for this class
            // 3. Create a list or array of the contact class
            // 4. Create a menu system in a loop that gives you the various options you need
            // 5. Implement methods to add/remove contacts from the list
            // 6. Implement a method to search for contacts

            SortContacts();
            

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
            Console.WriteLine("test");
            Console.WriteLine(contactList.Count + "test");
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
            bool sorted = false;
            do
            {
                if (i > contactList.Count - 1 && !sorted)
                {
                    i = 0;
                }
                //checks if sorted
                sorted = false;
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
                do
                {
                    Console.WriteLine($"looking at letters {info1[1][placeInName]} and {info2[1][placeInName]} ");

                    if ((int)info1[1][placeInName] > (int)info2[1][placeInName])
                    {
                        Console.WriteLine("Swap");
                        foundDifference = true;
                        Contact firstContact = contactList[i];
                        contactList[i] = contactList[i + 1];
                        contactList[i + 1] = firstContact;
                        i++;
                        sorted = false;
                    }
                    else if ((int)info1[1][placeInName] < (int)info2[1][placeInName])
                    {
                        //check if already sorted
                        Console.WriteLine("Keep location");
                        foundDifference = true;
                        sorted = false;
                        i++;
                    }
                    Console.WriteLine(i);
                    if ((int)info1[1][placeInName] == (int)info2[1][placeInName])
                    {
                        foundDifference = false;
                        placeInName++;
                        Console.WriteLine("letters same new letter");
                    }
                    
                } 
                while (!foundDifference);

                
            }
            while (!sorted);


            Console.WriteLine("list sorted");

        }

        static void Swap()
        {

        }



    }
}
