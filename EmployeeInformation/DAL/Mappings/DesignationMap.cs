using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace EmployeeInformaiton.DAL.Mappings
{
    class DesignationMap:ClassMap<Designation>
    {
       public DesignationMap()
       {
           Id(x => x.Id);
           Map(x => x.Code);
           Map(x => x.Title);
       }
    }
}
