using System;
using System.Collections.Generic;
using EmployeeInformation.DAL.Entities;
using EmployeeInformation.DAL.Gateway;

namespace EmployeeInformation.BLL
{
    public class DesignationManager
    {
        private DesignationGateway designationGateway = new DesignationGateway();
        private CommonGateway commonGateway = new CommonGateway();

        public IList<Designation> GetAll()
        {
            return designationGateway.GetAll();
        }

        public void SaveOrUpdate(Designation aDesignation)
        {
            commonGateway.SaveOrUpdate(aDesignation);
        }
    }
}