using December.Models;

namespace December.Interfaces
{
    public interface IRepository
    {
        List<Contact>? ContactsList { get; set; }
        public void AddContactToList();
        List<Contact> ReadFile(string path);
        void SaveContactList(string path);
        void RemoveContact();
    }
}
