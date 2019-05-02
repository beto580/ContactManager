﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using ContactManager.Domain.WebApi;
using ContactManager.SwaggerAssets.SampleRequest;
using Providers.Dao.Interface;
using Swashbuckle.Examples;
using Swashbuckle.Swagger.Annotations;

namespace ContactManager.Controllers
{
    [SwaggerResponse(HttpStatusCode.InternalServerError, "Internal server error")]
    public class ContactsController : BaseApiController
    {
        IContactsDao contactsDao;

        public ContactsController(IContactsDao dao, ISessionFactory sf)
            : base(sf)
        {
            contactsDao = dao;
        }

        // GET: api/Contacts
        /// <summary>
        /// Returns a collection of Contacts
        /// </summary>
        /// <returns></returns>
        [HttpGet,
        SwaggerResponse(HttpStatusCode.OK, "Returns a collection of Contacts", typeof(List<Contact>))]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(ContactsResponseSample))]
        public IHttpActionResult GetContacts()
        {
            try
            {
                return CatchException(() =>
                {
                    var response = contactsDao.GetAll();
                    return Ok(response);
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Returns a Contact from the specified id
        /// </summary>
        /// <param name="id">Id of the contact to find</param>
        /// <returns></returns>
        // GET: api/Contacts/5
        [SwaggerResponse(HttpStatusCode.OK, "Returns a Contact from the specified id", typeof(Contact))]
        public IHttpActionResult GetContact(int id)
        {
            Contact contact = contactsDao.GetById(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        // GET: api/Contacts/albertorojas580@hotmail.com
        /// <summary>
        /// Returns a collection of Contacts by email
        /// </summary>
        /// <param name="email">Email of the contact to find</param>
        /// <returns></returns>
        [HttpGet, Route("api/Contacts/GetByEmail"),
        SwaggerResponse(HttpStatusCode.OK, "Returns a collection of Contacts by email", typeof(IQueryable<Contact>))]
        public IHttpActionResult GetByEmail(string email)
        {
            var contacts = contactsDao.GetByEmail(email.ToLower());

            if (contacts.Count() == 0)
            {
                return NotFound();
            }

            return Ok(contacts);
        }

        // GET: api/Contacts/+541132984698
        /// <summary>
        /// Returns a collection of Contacts by phone number
        /// </summary>
        /// <param name="phone">Phone of the contact to find</param>
        /// <returns></returns>
        [HttpGet, Route("api/Contacts/GetByPhone"),
        SwaggerResponse(HttpStatusCode.OK, "Returns a collection of Contacts by phone number", typeof(IQueryable<Contact>))]
        public IHttpActionResult GetByPhone(string phone)
        {
            var contacts = contactsDao.GetByPhone(phone.ToLower());

            if (contacts.Count() == 0)
            {
                return NotFound();
            }

            return Ok(contacts);
        }

        // GET: api/Contacts/cordoba
        /// <summary>
        /// Returns a collection of Contacts by state
        /// </summary>
        /// <param name="state">Phone of the contact to find</param>
        /// <returns></returns>
        [HttpGet, Route("api/Contacts/GetByState"),
        SwaggerResponse(HttpStatusCode.OK, "Returns a collection of Contacts by state", typeof(IQueryable<Contact>))]
        public IHttpActionResult GetByState(string state)
        {
            var contacts = contactsDao.GetByState(state.ToLower());

            if (contacts.Count() == 0)
            {
                return NotFound();
            }

            return Ok(contacts);
        }

        // GET: api/Contacts/salta
        /// <summary>
        /// Returns a collection of Contacts by city
        /// </summary>
        /// <param name="city">Phone of the contact to find</param>
        /// <returns></returns>
        [HttpGet, Route("api/Contacts/GetByCity"),
        SwaggerResponse(HttpStatusCode.OK, "Returns a collection of Contacts by city", typeof(IQueryable<Contact>))]
        public IHttpActionResult GetByCity(string city)
        {
            var contacts = contactsDao.GetByCity(city.ToLower());

            if (contacts.Count() == 0)
            {
                return NotFound();
            }

            return Ok(contacts);
        }

        // PUT: api/Contacts/5
        /// <summary>
        /// Updates a Contact with the specified id
        /// </summary>
        /// <param name="id">Id of the contact to update</param>
        /// <param name="newContact">New values to update the contact</param>
        /// <returns></returns>
        [SwaggerRequestExample(typeof(ContactViewModel), typeof(ContactRequestSample))]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(ContactResponseSample))]
        [SwaggerResponse(HttpStatusCode.OK, "Updates a Contact with the specified id", typeof(void))]
        public IHttpActionResult PutContact(int id, ContactViewModel newContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Contact contact = contactsDao.GetById(id);
            if (contact == null)
            {
                return NotFound();
            }

            contactsDao.UpdateContact(contact, newContact);

            try
            {
                contactsDao.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!contactsDao.ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Contacts
        /// <summary>
        /// Creates a new Contact
        /// </summary>
        /// <param name="contact">The contact to create</param>
        /// <returns></returns>
        [SwaggerRequestExample(typeof(Contact), typeof(ContactRequestSample))]
        [SwaggerResponse(HttpStatusCode.OK, "Creates a new Contact", typeof(Contact))]
        public IHttpActionResult PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            contactsDao.CreateContact(contact);
            contactsDao.Commit();

            return CreatedAtRoute("DefaultApi", new { id = contact.ID }, contact);
        }

        // DELETE: api/Contacts/5
        /// <summary>
        /// Deletes an existing Contact
        /// </summary>
        /// <param name="id">The Id of the contact to delete</param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, "Deletes an existing Contact", typeof(Contact))]
        public IHttpActionResult DeleteContact(int id)
        {
            Contact contact = contactsDao.GetById(id);
            if (contact == null)
            {
                return NotFound();
            }

            contactsDao.DeleteContact(contact);
            contactsDao.Commit();

            return Ok(contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                SessionFactory.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}