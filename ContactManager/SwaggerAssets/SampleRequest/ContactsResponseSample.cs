using ContactManager.Domain.WebApi;
using Swashbuckle.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManager.SwaggerAssets.SampleRequest
{
    public class ContactsResponseSample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new List<Contact>()
            {
                new Contact()
                {
                    ID = 1,
                    Name = "Alberto Rojas",
                    Company = "Solstice",
                    ProfileImage = "https://contactmanagerstorage.blob.core.windows.net/profileimages/default_avatar.png",
                    Email = "albertorojas580@hotmail.com",
                    BirthDate = DateTime.Parse("1991-11-01"),
                    PersonalPhone = "+541132984698",
                    Address = new Address
                    {
                        City = "CABA",
                        State = "Buenos Aires"
                    }
                },
                new Contact()
                {
                    ID = 2,
                    Name = "Fernando Escalona",
                    Company = "Solstice",
                    ProfileImage = "https://contactmanagerstorage.blob.core.windows.net/profileimages/default_avatar.png",
                    Email = "fernando.escalona@gmail.com",
                    BirthDate = DateTime.Parse("1990-05-02"),
                    PersonalPhone = "+541112345678",
                    Address = new Address
                    {
                        City = "Cordoba",
                        State = "Cordoba"
                    }
                }
            };
        }
    }
}