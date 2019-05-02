namespace Providers.Dao.Interface
{
    using ContactManager.Domain.WebApi;
    using System.Collections.Generic;

    public interface IContactsDao
    {
        Contact GetById(int id);

        List<Contact> GetByEmail(string email);

        List<Contact> GetByPhone(string phone);

        List<Contact> GetByState(string state);

        List<Contact> GetByCity(string city);

        List<Contact> GetAll();

        void UpdateContact(Contact contact, ContactViewModel newContact);

        void CreateContact(Contact contact);

        void DeleteContact(Contact contact);

        bool ContactExists(int id);

        void Commit();
    }
}
