using December.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace December.Services
{
    public class Helpers : IHelpers
    {
        int selectedIndex = 0;

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("******************************************");
            Console.WriteLine("Address book");
            Console.WriteLine("******************************************");

            Console.WriteLine("Please choose from menu bellow:");

            Console.WriteLine("A. Add Contact");
            Console.WriteLine("V. View Contacts");
            Console.WriteLine("R. Remove a Contact");
            Console.WriteLine("E. Exit");
            Console.WriteLine();
        }

        public Contact GetContactFromUser() // To get contact info from user by reading via Console.ReadLine()
        {
            Contact newContact = new Contact();

            bool tryMore = true;

            Console.WriteLine("Please enter the first name:");
            newContact.FirstName = Console.ReadLine();

            Console.WriteLine("Please enter the last name:");
            newContact.LastName = Console.ReadLine();

            Console.WriteLine("Please enter the email:");
            newContact.Email = Console.ReadLine();

            Console.WriteLine("Please enter the address:");
            newContact.Address = Console.ReadLine();

            Console.WriteLine("Please enter the phone number:");

            while (tryMore)
            {
                if (Int32.TryParse(Console.ReadLine(), out int result))
                {
                    newContact.PhoneNumber = result;
                    tryMore = false;
                }
                else
                {
                    Console.WriteLine("Please enter just numbers:");
                    tryMore = true;
                }
            }

            return newContact;

        }



        public void ViewContactList(List<Contact> list) // to list all contacts
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo key;

            do
            {
                Console.Clear();
                DisplayContacts(list);

                key = Console.ReadKey();

                // Handle arrow key input
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selectedIndex > 0)
                            selectedIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectedIndex < list.Count - 1)
                            selectedIndex++;
                        break;
                }
            } while (key.Key != ConsoleKey.Enter);
        }

        private void DisplayContacts(List<Contact> list)
        {
            Console.WriteLine("Contact List:");
            Console.WriteLine("-----------------");


            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"{list[i].FirstName} {list[i].LastName}");

                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine($"First Name:      {list[i].FirstName}");
                    Console.WriteLine($"Last Name:       {list[i].LastName}");
                    Console.WriteLine($"Email:           {list[i].Email}");
                    Console.WriteLine($"Address:         {list[i].Address}");
                    Console.WriteLine($"Phone Number:    {list[i].PhoneNumber}");
                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine();
                }                
                Console.ResetColor();       
            }
        }
    }
}
