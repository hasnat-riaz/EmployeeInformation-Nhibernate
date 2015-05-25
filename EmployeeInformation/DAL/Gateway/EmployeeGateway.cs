using System;
using System.Collections.Generic;
using EmployeeInformation.DAL.Entities;
using NHibernate;
using NHibernate.Criterion;

namespace EmployeeInformation.DAL.Gateway
{
    public class EmployeeGateway
    {
        private ISessionFactory createDataBaseSession = DatabaseConfigure.CreateDbSessionFactory();

        public IList<Employee> GetAll()
        {
            using (ISession session = createDataBaseSession.OpenSession())
            {
                return session.CreateCriteria(typeof (Employee)).List<Employee>();
            }
        }

        public IList<Employee> GetEmployeesWithMatchingWord(string nameWord)
        {
            using (ISession session = createDataBaseSession.OpenSession())
            {
                return
                    session.CreateCriteria<Employee>().Add(Expression.Like("Name", nameWord, MatchMode.Anywhere)).List
                        <Employee>();
            }
        }
    }
}