using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeInformaiton.DAL.Model;

namespace EmployeeInformaiton.DAL
{
    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Address { get; set; }
        public virtual Designation ThisDesignation { get; set; }
    }
}
