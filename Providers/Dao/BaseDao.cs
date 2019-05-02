namespace Providers.Dao
{
    using Providers.Dao.Interface;

    public abstract class BaseDao
    {
        private readonly ISessionFactory sessionFactory;

        public BaseDao(ISessionFactory sf)
        {
            sessionFactory = sf;
        }
    }
}
