using NHibernate.Cfg;

namespace NHibernate.Example.Domain
{
    public class NHibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath = @"hibernate.cfg.xml";
            configuration.Configure(configurationPath);
            var employeeConfigurationFile = @"Mappings\Employee.hbm.xml";
            configuration.AddFile(employeeConfigurationFile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
