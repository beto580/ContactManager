using Providers.Dao.Interface;
using System;
using System.Web.Http;

namespace ContactManager.Controllers
{
    public class BaseApiController : ApiController
    {
        protected ISessionFactory SessionFactory { get; set; }

        public BaseApiController(ISessionFactory sessionFactory)
        {
            SessionFactory = sessionFactory;
        }

        protected T CatchException<T>(Func<T> func)
        {
            try
            {
                using (var ses = SessionFactory.CreateSession())
                {
                    return func();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}