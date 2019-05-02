namespace Providers.Dao.Implementation
{
    using ContactManager.Domain.WebApi;
    using Providers.Dao.Interface;
    using System.Collections.Generic;
    using System.Linq;

    public class ContactsDao : BaseDao, IContactsDao
    {
        private readonly DatabaseContext db;

        public ContactsDao(ISessionFactory sf)
            : base(sf)
        {
            db = sf.CreateSession();
        }

        public void CreateContact(Contact contact)
        {
            db.Contacts.Add(contact);
        }

        public List<Contact> GetAll()
        {
            return db.Contacts.ToList();
        }

        public List<Contact> GetByCity(string city)
        {
            var contacts = from c in db.Contacts
                           where c.Address.City.ToLower().Equals(city)
                           select c;

            return contacts.ToList();
        }

        public List<Contact> GetByEmail(string email)
        {
            var contacts = from c in db.Contacts
                           where c.Email.ToLower().Equals(email)
                           select c;

            return contacts.ToList();
        }

        public List<Contact> GetByPhone(string phone)
        {
            var contacts = from c in db.Contacts
                           where c.PersonalPhone.Equals(phone)
                           || c.WorkPhone.Equals(phone)
                           select c;

            return contacts.ToList();
        }

        public List<Contact> GetByState(string state)
        {
            var contacts = from c in db.Contacts
                           where c.Address.State.ToLower().Equals(state)
                           select c;

            return contacts.ToList();
        }

        public Contact GetById(int id)
        {
            return db.Contacts.Find(id);
        }

        public void UpdateContact(Contact contact, ContactViewModel newContact)
        {
            db.Entry(contact).CurrentValues.SetValues(newContact);
        }

        public void DeleteContact(Contact contact)
        {
            db.Contacts.Remove(contact);
        }

        public bool ContactExists(int id)
        {
            return db.Contacts.Count(e => e.ID == id) > 0;
        }

        public void Commit()
        {
            db.SaveChanges();
        }
    }
}
