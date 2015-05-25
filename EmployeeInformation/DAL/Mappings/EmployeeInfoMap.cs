using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace EmployeeInformaiton.DAL.Mappings
{
    class EmployeeInfoMap:ClassMap<Employee>
    {
       public EmployeeInfoMap()
       {
           Id(x => x.Id);
           Map(x => x.Name);
           Map(x => x.Email);
           Map(x => x.Address);
           HasOne(x => x.ThisDesignation);

       }
    }
}
