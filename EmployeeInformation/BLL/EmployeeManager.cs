using System.Collections.Generic;
using EmployeeInformation.DAL.Entities;
using EmployeeInformation.DAL.Gateway;

namespace EmployeeInformation.BLL
{
    public class EmployeeManager
    {
        private EmployeeGateway employeeGateway = new EmployeeGateway();
        CommonGateway commonGateway = new CommonGateway();

        public void SaveOrUpdate(Employee anEmployee)
        {
            commonGateway.SaveOrUpdate(anEmployee);
        }

        public IList<Employee> GetEmployeesWithMatchingWord(string nameWord)
        {
            return employeeGateway.GetEmployeesWithMatchingWord(nameWord);
        }

        public void DeleteEmployee(Employee selectedEmployee)
        {
            commonGateway.Delete(selectedEmployee);
        }

        public IList<Employee> GetAll()
        {
            return employeeGateway.GetAll();
            
        }
    }
}