using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace EmployeeInformation.DAL.Gateway
{
    class DatabaseConfigure
    {

        public static ISessionFactory CreateDbSessionFactory()
        {
            AutoPersistenceModel model = CreateMappings();

            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                              .ConnectionString(c => c.FromAppSetting("EmployeeConnectionString")))
                .Mappings(m => m.AutoMappings.Add(model))
                .BuildSessionFactory();
        }

        public static ISessionFactory BuildSessionFactory()
        {
            //This method build our session factory -
            //the most important part of our ORM application
            AutoPersistenceModel model = CreateMappings();

            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                              .ConnectionString(c => c.FromAppSetting("EmployeeConnectionString")))
                .Mappings(m => m.AutoMappings.Add(model))
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        public static AutoPersistenceModel CreateMappings()
        {
            //This method will create our auto-mappings model
            return AutoMap
                .Assembly(System.Reflection.Assembly.GetCallingAssembly())
                .Where(t => t.Namespace == "EmployeeInformation.DAL.Entities");
        }

        public static void BuildSchema(Configuration config)
        {
            //This method will create/recreate our database
            //This method should be called only once when
            //we want to create our database
            new SchemaExport(config).Create(true, true);
        }

    }
}
