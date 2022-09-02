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
            AddContact("Tom", "K", "123123", "1");
            AddContact("Jakob", "M", "123123", "1");
            AddContact("Sam", "A", "123123", "1");
            AddContact("Jarrah", "F", "123123", "1");
            AddContact("Ash", "B", "123123", "1");


            
            // Hints: 
            // 1. Create a Contact class
            // 2. Create the properties and methods for this class
            // 3. Create a list or array of the contact class
            // 4. Create a menu system in a loop that gives you the various options you need
            // 5. Implement methods to add/remove contacts from the list
            // 6. Implement a method to search for contacts
            while (true)
            {
                Console.WriteLine("Press 1 to add contact.");
                Console.WriteLine("Press 2 to remove contact");
                Console.WriteLine("Press 3 to show list");
                Console.WriteLine("Press 4 to sort list");
                Console.WriteLine("Press 5 to search for a contact");
                
                string input = Console.ReadLine();
                if(int.TryParse(input, out int choice))
                {
                    UserChoice(choice);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a number");
                }
               
                
                
                

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
                RemoveContact();
            }
            else if(choice == 3)
            {
                PrintList();
            }
            else if(choice == 4)
            {
                SortContacts(false);
            }
            else if(choice == 5)
            {
                Console.WriteLine("Enter the name:");
                
                string name = Console.ReadLine();
                SortContacts(true);
                int index = Search(name, 0, contactList.Count - 1, 0, 0);
                if (index >= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"Found for contact '{name}'");
                    PrintContact(index);
                }
                 
            }
        }



        static void AskUserForContact()
        {
            Console.WriteLine("Please enter a first name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please enter a last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Please enter a phonenumber:");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Please enter an address:");
            string address = Console.ReadLine();
            AddContact(firstName, lastName, phoneNumber, address);
            Console.Clear();
            Console.WriteLine($"Added new contact: {firstName} {lastName}");
        }


        static void AddContact(string firstname, string lastname, string number, string address)
        {
            contactList.Add(new Contact(firstname, lastname, number, address));
        }

        static void PrintContact(int index)
        {
            
            Contact contact = contactList[index];
            string[] info = new string[4];
            info = contact.GetInformation();
            //Console.WriteLine(contactList.IndexOf(contact));
            Console.WriteLine();
            Console.WriteLine($"Name: {info[0]} {info[1]}");
            Console.WriteLine($"Phone number: {info[2]}");
            Console.WriteLine($"Address: {info[3]}");
            Console.WriteLine();
        }

        static void RemoveContact()
        {
            Console.WriteLine("Enter the name:");

            string name = Console.ReadLine();
            SortContacts(true);
            int index = Search(name, 0, contactList.Count - 1, 0, 0);
            if (index >= 0)
            {
                Console.Clear();
                
                contactList.RemoveAt(index);
            }
            
        }

        static void PrintList()
        {
            Console.Clear();
            Console.WriteLine("Contacts: ");
            
            foreach (Contact contact in contactList)
            {
                string[] info = new string[4];
                info = contact.GetInformation();
                Console.WriteLine(info[0]);
            }
        }

        static void SortContacts(bool searching)
        {
            Console.Clear();
            
            int comparing = 0;
            if (!searching)
            {
                Console.WriteLine("Press 1 to sort by first name");
                Console.WriteLine("Press 2 to sort by last name");
                comparing = int.Parse(Console.ReadLine());
                if (comparing == 1)
                {
                    comparing = 0;
                }
                else
                {
                    comparing = 1;
                }
            }
            
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
                    sorted = true;
                    
                }
                //checks if sorted
                
                //counts place in list
                
                //creats two arrays to store contact information
                string[] info1 = new string[3];
                string[] info2 = new string[3];
                //gets the contacts information
                info1 = contactList[i].GetInformation();
                info2 = contactList[i + 1].GetInformation();
                //keeps track of the letters being compared
                int placeInName = 0;
                //checks for a difference between letters
                bool foundDifference = false;
               
                do
                {
                    CheckContact(ref i, ref sorted, info1, info2, ref placeInName, ref foundDifference, comparing);

                }
                while (!foundDifference);

                
            }
            while (!endsort);


            Console.WriteLine("list sorted");

        }


        static int Search(string name,int low, int high, int searchingfor, int numberOfCycles)
        {
            int middle = FindMiddle(low, high);
            //Console.WriteLine("High:" + high);
            //Console.WriteLine("Middle:" + middle);
            //Console.WriteLine("Low:" + low);
            //Console.WriteLine("High:" + contactList[high].GetInformation()[searchingfor]);
            //Console.WriteLine("Middle:" + contactList[middle].GetInformation()[searchingfor]);
            //Console.WriteLine("Low:" + contactList[low].GetInformation()[searchingfor]);

            if (contactList[middle].GetInformation()[searchingfor] == name)
            {
                
                return middle;
            }
            
            if (comparename(name, middle, searchingfor))
            {
                low = middle;
            }
            else
            {
                high = middle;
                
            }

            if (low == high)
            {


                Console.WriteLine("Not Found");
                return -1;
            }
           

            return Search(name, low, high, searchingfor, numberOfCycles++);
            
        }

        static bool comparename(string name, int middle, int searchingfor)
        {
            bool foundDifference = false;
            int checkingLetter = 0;
            string newName = name.ToLower();
            string middleName = contactList[middle].GetInformation()[searchingfor].ToLower();
            do
            {

                if (newName[checkingLetter] > middleName[checkingLetter])
                {
                    
                    return true;
                }

                if (newName[checkingLetter] < middleName[checkingLetter])
                {
                    
                    return false;
                }

                if (newName[checkingLetter] == middleName[checkingLetter])
                {
                    checkingLetter++;
                }

                
            }
            while (!foundDifference);

            return true;

        }


        static int FindMiddle(int startIndex, int endIndex)
        {
            double middle = startIndex + endIndex;
            middle /= 2;
            return (int)Math.Round(middle);
        }




        private static void CheckContact(ref int i, ref bool sorted, string[] info1, string[] info2, ref int placeInName, ref bool foundDifference, int comparing)
        {
           Console.WriteLine($" {info1[comparing][placeInName]} and {info2[comparing][placeInName]} ");

            if (info1[comparing][placeInName] > info2[comparing][placeInName])
            {
                Console.WriteLine("Swap");
                sorted = false;
                Swap(i);
                foundDifference = true;

                i++;

            }
            else if (info1[comparing][placeInName] < info2[comparing][placeInName])
            {
                //check if already sorted
                Console.WriteLine("Keep");
                foundDifference = true;

                i++;
            }

            if (info1[comparing][placeInName] == info2[comparing][placeInName])
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
