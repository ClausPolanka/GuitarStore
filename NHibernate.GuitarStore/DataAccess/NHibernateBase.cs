using System;
using System.Collections.Generic;
using System.Data;
using NHibernate.Cfg;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Event;
using NHibernate.SqlCommand;
using log4net;
using log4net.Config;

namespace NHibernate.GuitarStore.DataAccess
{
    public class NHibernateBase
    {
        private static ISession session;
        private static IStatelessSession statelessSession;

        public NHibernateBase()
        {
            XmlConfigurator.Configure();
            ConsoleManager.Show();
        }

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
            Configuration.SetInterceptor(new SQLInterceptor());
            Configuration.EventListeners.PostDeleteEventListeners = new IPostDeleteEventListener[] {new AuditDeleteEvent()};
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

    public class SQLInterceptor : EmptyInterceptor
    {
        public override SqlString OnPrepareStatement(SqlString sql)
        {
            Utils.NHibernateGeneratedSQL = sql.ToString();
            Utils.QueryCounter++;
            return sql;
        }
    }

    public class AuditDeleteEvent : IPostDeleteEventListener
    {
        private static readonly ILog log = LogManager.GetLogger("NHBase.SQL.Delete");

        #region IPostDeleteEventListener Members

        public void OnPostDelete(PostDeleteEvent @event)
        {
            log.Info(@event.Id + "has been deleted.");
        }

        #endregion
    }
}