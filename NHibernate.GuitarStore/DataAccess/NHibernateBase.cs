using System;
using System.Collections.Generic;
using System.Data;
using NHibernate.Cfg;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace NHibernate.GuitarStore.DataAccess
{
    public class NHibernateBase
    {
        private static ISession session;
        private static IStatelessSession statelessSession;
        protected static ISessionFactory SessionFactory { get; set; }
        private static Configuration Configuration { get; set; }

        public static ISession Session
        {
            get
            {
                if (session == null)
                    session = SessionFactory.OpenSession();
                return session;
            }
        }

        public static IStatelessSession StatelessSession
        {
            get
            {
                if (statelessSession == null)
                    statelessSession = SessionFactory.OpenStatelessSession();
                return statelessSession;
            }
        }

        public NHibernateBase()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public void Initialize(string assembly)
        {
            Configuration = ConfigureNHibernate(assembly);
            SessionFactory = Configuration.BuildSessionFactory();
        }

        private static Configuration ConfigureNHibernate(string assembly)
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
            Configuration.AddAssembly(assembly);
            return Configuration;
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