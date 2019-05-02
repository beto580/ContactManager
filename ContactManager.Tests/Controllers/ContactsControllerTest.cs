using ContactManager.Controllers;
using ContactManager.Domain.WebApi;
using Moq;
using NUnit.Framework;
using Providers.Dao.Interface;
using System;
using System.Web.Http.Results;

namespace ContactManager.Tests.Controllers
{
    [TestFixture]
    public class ContactsControllerTest
    {
        private ContactsController controller;
        private Mock<IContactsDao> mockDao;
        private Mock<ISessionFactory> mockSessionFactory;

        [SetUp]
        void Setup()
        {
            mockSessionFactory = new Mock<ISessionFactory>();
            mockDao = new Mock<IContactsDao>();
            controller = new ContactsController(
                mockDao.Object, 
                mockSessionFactory.Object);
        }

        [Test]
        public void GetContactTestShouldReturnOk()
        {
            mockDao
                .Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(GetMockContact);

            var response = controller.GetContact(1);

            Assert.IsNotNull(response);
            Assert.IsInstanceOf<OkNegotiatedContentResult<Contact>>(response);
        }

        [Test]
        public void GetContactTestShouldReturnNotFound()
        {
            var response = controller.GetContact(1);

            Assert.IsNotNull(response);
            Assert.IsInstanceOf<NotFoundResult>(response);
        }

        Contact GetMockContact()
        {
            return new Contact()
            {
                ID = 1,
                Name = "Alberto Rojas",
                Company = "Solstice",
                ProfileImage = "https://contactmanagerstorage.blob.core.windows.net/profileimages/default_avatar.png",
                Email = "albertorojas580@hotmail.com",
                BirthDate = DateTime.Parse("1991-11-01"),
                PersonalPhone = "1132984698",
                Address = new Address
                {
                    City = "CABA",
                    State = "Buenos Aires"
                }
            };
        }
    }
}
