
using December.Interfaces;
using December.Models;
using December.Services;
using Newtonsoft.Json;

namespace December.Data
{
    public class Repository : IRepository
    {
        private readonly IHelpers _services;

        public Repository(IHelpers services)
        {
            _services = services;
        }


        public List<Contact>? ContactsList { get; set; }

        public List<Contact> ReadFile(string path)
        {
            try
            {
                if (File.Exists(path)) //Check if the file exists
                {
                    using (var sr = new StreamReader(path))
                    {
                        try
                        {
                            ContactsList = JsonConvert.DeserializeObject<List<Contact>>(sr.ReadToEnd())!;
                            if (ContactsList == null) 
                            {
                                ContactsList = new List<Contact>();
                            }
                            return ContactsList;
                        }
                        catch (Exception ex) 
                        {
                            Console.WriteLine(ex);
                            return new List<Contact>();
                        }
                    }
                }
                else //If the file does not exist the function return an empty list
                {
                    return new List<Contact>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void AddContactToList()// this function has another function in itself to get contact info and then adds that contact to the list
        {
            var contact = _services.GetContactFromUser();
            ContactsList.Add(contact);
        }

        public void SaveContactList(string path)
        {
            using (var sw = new StreamWriter(path))
            {
                try
                {
                    sw.WriteLine(JsonConvert.SerializeObject(ContactsList));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public void RemoveContact() // removes a contact
        {
            Console.Clear();
            Console.WriteLine("***************************");
            Console.WriteLine("Remove a contact");
            Console.WriteLine("***************************");
            Console.WriteLine();
            Console.WriteLine("To remove a contact please enter the email:");
            Console.WriteLine();

            string email = Console.ReadLine()!;

            ContactsList!.RemoveAll(contact => contact.Email == email);

            Console.WriteLine($"The contact with email: {email} has been removed!");
            Thread.Sleep(2000);
        }
    }
}
