using NHibernate.AdoNet.Util;

namespace NHibernate.GuitarStore.DataAccess
{
    public class Utils
    {
        public static string NHibernateGeneratedSQL { get; set; }
        public static int QueryCounter { get; set; }

        public static string FormatSQL()
        {
            var basicFormatter = new BasicFormatter();
            return basicFormatter.Format(NHibernateGeneratedSQL.ToUpper());
        }
    }
}
