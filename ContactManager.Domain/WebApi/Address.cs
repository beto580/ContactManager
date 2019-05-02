namespace ContactManager.Domain.WebApi
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Address class for the contact
    /// </summary>
    [ComplexType]
    public class Address
    {
        /// <summary>
        /// City where the contact resides
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// State where the contact resides
        /// </summary>
        public string State { get; set; }
    }
}
