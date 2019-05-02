using ContactManager.Domain.WebApi;
using Swashbuckle.Examples;
using System;

namespace ContactManager.SwaggerAssets.SampleRequest
{
    public class ContactRequestSample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new ContactViewModel()
            {
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
            };
        }
    }
}