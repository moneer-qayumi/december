using December.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace December.Services
{
    public interface IHelpers
    {
        Contact GetContactFromUser();
        void ShowMenu();
        void ViewContactList(List<Contact> list);
    }
}
