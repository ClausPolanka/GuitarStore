using System;
using System.Collections.Generic;
using System.Data;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.GuitarStore.Common;
using NHibernate.Mapping.ByCode;

namespace NHibernate.GuitarStore.DataAccess
{
    public class NHibernateBase
    {
        private static Configuration Configuration { get; set; }
        protected static ISessionFactory SessionFactory { get; set; }
        private static ISession session = null;
        private static IStatelessSession statelessSession = null;

        public static Configuration ConfigureNHibernate_App_Config(string assembly)
        {
            Configuration = new Configuration();
            Configuration.AddAssembly(assembly);
            return Configuration;
        }

        public static Configuration ConfigureNHibernate(string assembly)
        {
            Configuration = new Configuration();
            Configuration.DataBaseIntegration(dbi =>
            {
                dbi.Dialect<MsSql2008Dialect>();
                dbi.Driver<SqlClientDriver>();
                dbi.ConnectionProvider<DriverConnectionProvider>();
                dbi.IsolationLevel = IsolationLevel.ReadCommitted;
                dbi.LogSqlInConsole = true;
                dbi.Timeout = 15;
            });

//            ModelMapper mapper = new ModelMapper();
//            mapper.AddMapping<InventoryMap>();
//            HbmMapping mapping = mapper.CompileMappingFor(new[] {typeof (Inventory)});
//            Configuration.AddDeserializedMapping(mapping, "GuitarStore");

            Configuration.AddAssembly(assembly);
            return Configuration;
        }

        public void Initialize(string assembly)
        {
            Configuration = ConfigureNHibernate(assembly);
            SessionFactory = Configuration.BuildSessionFactory();
        }

        public static ISession Session
        {
            get
            {
                if (session == null)
                {
                    session = SessionFactory.OpenSession();
                }
                return session;
            }
        }

        public static IStatelessSession StatelessSession
        {
            get
            {
                if (statelessSession == null)
                {
                    statelessSession = SessionFactory.OpenStatelessSession();
                }
                return statelessSession;
            }
        }

        public IList<T> ExecuteICriteria<T>()
        {
            using (ITransaction transaction = Session.BeginTransaction())
            {
                try
                {
                    IList<T> result = Session.CreateCriteria(typeof (T)).List<T>();
                    transaction.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}