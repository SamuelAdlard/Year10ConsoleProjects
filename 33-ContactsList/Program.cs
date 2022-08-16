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
            while(true)
            {
                Console.WriteLine("Press 1 to add contact.");
                Console.WriteLine("Press 2 to remove contact");
                Console.WriteLine("Press 3 to show list");
                Console.WriteLine("Press 4 to sort list");
                int choice = int.Parse(Console.ReadLine());
                UserChoice(choice);

            }

            

            Console.ReadKey();
            // Extension:
            // 1. Figure out how to save / load to a file
        }

        static void UserChoice(int choice)
        {
            if (choice == 1)
            {
                AskUserForContact();
            }
            else if (choice == 2)
            {

            }
            else if(choice == 3)
            {
                PrintList();
            }
            else if(choice == 4)
            {
                SortContacts();
            }
        }



        static void AskUserForContact()
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string phoneNUmber = Console.ReadLine();
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
                    Console.WriteLine("END");
                    endsort = true;
                }

                if (i > contactList.Count - 2)
                {
                    i = 0;
                    sorted = true;
                    Console.WriteLine("Back to 0");
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
               
                do
                {
                    CheckContact(ref i, ref sorted, info1, info2, ref placeInName, ref foundDifference);

                }
                while (!foundDifference);

                
            }
            while (!endsort);


            Console.WriteLine("list sorted");

        }

        private static void CheckContact(ref int i, ref bool sorted, string[] info1, string[] info2, ref int placeInName, ref bool foundDifference)
        {
            Console.WriteLine($" {info1[1][placeInName]} and {info2[1][placeInName]} ");

            if (info1[1][placeInName] > info2[1][placeInName])
            {
                Console.WriteLine("Swap");
                sorted = false;
                Swap(i);
                foundDifference = true;

                i++;

            }
            else if (info1[1][placeInName] < info2[1][placeInName])
            {
                //check if already sorted
                Console.WriteLine("Keep");
                foundDifference = true;

                i++;
            }

            if (info1[1][placeInName] == info2[1][placeInName])
            {
                foundDifference = false;

                placeInName++;

            }
        }

        static void Swap(int i)
        {
            Contact firstContact = contactList[i];
            contactList[i] = contactList[i + 1];
            contactList[i + 1] = firstContact;
        }



    }
}
