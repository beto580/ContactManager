namespace Providers.Dao.Implementation
{
    using Providers.Dao.Interface;

    public class SessionFactory : ISessionFactory
    {
        public DatabaseContext Db { get; set; }

        public DatabaseContext CreateSession()
        {
            if (Db == null)
            {
                return new DatabaseContext();
            }
            else
            {
                return Db;
            }
        }

        public void Dispose()
        {
            if (Db != null)
            {
                Db.Dispose();
            }
        }
    }
}
