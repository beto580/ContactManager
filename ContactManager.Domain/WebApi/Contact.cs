namespace ContactManager.Domain.WebApi
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contact class
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Id of the contact
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Name of the contact
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Name of the company this contact works for
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// Path to the profile image in the server
        /// </summary>
        public string ProfileImage { get; set; }
        /// <summary>
        /// Email of the contact
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Birthdate of the contact
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Workphone of the contact
        /// </summary>
        public string WorkPhone { get; set; }
        /// <summary>
        /// Personal phone of the contact
        /// </summary>
        public string PersonalPhone { get; set; }
        /// <summary>
        /// Address of the contact
        /// </summary>
        public Address Address { get; set; }

        public Contact()
        {
            this.Address = new Address();
        }
    }
}
