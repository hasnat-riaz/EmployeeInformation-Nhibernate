using NHibernate;

namespace EmployeeInformation.DAL.Gateway
{
    public class CommonGateway
    {
        ISessionFactory createDataBaseSession = DatabaseConfigure.CreateDbSessionFactory();
        
        public void SaveOrUpdate(object entity)
        {
          using (ISession session= createDataBaseSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(entity);
                    transaction.Commit();
                }
            }
        }

        public void Delete(object entity)
        {
            using (ISession session = createDataBaseSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(entity);
                    transaction.Commit();
                }
            }
        }
    }
}
