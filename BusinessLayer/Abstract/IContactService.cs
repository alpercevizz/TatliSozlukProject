using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetContactList();
        void AddContact(Contact contact);
        Contact GetById(int id);

        void ContactDelete(Contact contact);
        void ContactUpdate(Contact contact);
    }
}
