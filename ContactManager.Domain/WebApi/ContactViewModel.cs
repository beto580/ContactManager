namespace ContactManager.Domain.WebApi
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ContactViewModel
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string ProfileImage { get; set; }
        public string Email { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string WorkPhone { get; set; }
        public string PersonalPhone { get; set; }
        public Address Address { get; set; }

        public ContactViewModel()
        {
            this.Address = new Address();
        }
    }
}
