using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace LG.Test.Infra.Data
{
    public class NHibernateHelper
    {
        private static ISessionFactory factory = GetSessionFactory();

        public static ISessionFactory GetSessionFactory()
        {
            Configuration cfg = GetConfiguration();
            return cfg.BuildSessionFactory();
        }

        public static Configuration GetConfiguration()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(Assembly.GetExecutingAssembly());            

            return cfg;
        }

        public static void GenerateSchema()
        {
            Configuration cfg = GetConfiguration();
            new SchemaExport(cfg).Create(true, true);
        }        
    }
}
