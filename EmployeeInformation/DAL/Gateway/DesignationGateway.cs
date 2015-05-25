using System.Collections.Generic;
using EmployeeInformation.DAL.Entities;
using NHibernate;

namespace EmployeeInformation.DAL.Gateway
{
    public class DesignationGateway
    {
        ISessionFactory createDataBaseSession = DatabaseConfigure.CreateDbSessionFactory();

        public IList<Designation> GetAll()
        {
            using(ISession session = createDataBaseSession.OpenSession())
            {
                return session.CreateCriteria(typeof (Designation)).List<Designation>();
            }
        }
    }
}