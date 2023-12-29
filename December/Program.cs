using December.Data;
using December.Services;

IHelpers services = new Helpers();
var repo = new Repository(services);
var path = @"..\..\..\..\Contacts.json";
repo.ReadFile(path);
bool exit = false;


while (!exit)
{
    services.ShowMenu(); // shows the main menu

    var choice = Console.ReadLine().ToLower();

    switch (choice)
    {
        case "a":
            repo.AddContactToList();
            repo.SaveContactList(path);
            break;
        case "v":
            repo.ReadFile(path);
            services.ViewContactList(repo.ContactsList);
            break;
        case "r":
            repo.RemoveContact();
            repo.SaveContactList(path);
            break;
        case "e":
            exit = true;
            break;
        default:
            Console.WriteLine("Invalid choice! Please try again!");
            Thread.Sleep(1400);
            break;
    }
}