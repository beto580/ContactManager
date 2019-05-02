namespace Providers.Dao.Interface
{
    public interface ISessionFactory
    {
        DatabaseContext CreateSession();

        void Dispose();
    }
}
