namespace Providers.Dao
{
    using ContactManager.Domain.WebApi;
    using System.Data.Entity;

    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=DbConnection")
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
