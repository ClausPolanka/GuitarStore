using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate.GuitarStore.Common;
using NHibernate.GuitarStore.DataAccess;    
using NHibernate.Linq;

namespace NHibernate.GuitarStore.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                NHibernateBase NHB = new NHibernateBase();
                NHB.Initialize("NHibernate.GuitarStore");
                System.Console.WriteLine("NHibernate.GuitarStore assembly initialized.");
                System.Console.ReadLine();

                IList<Inventory> list1 = NHibernateBase.StatelessSession.CreateQuery("from Inventory").List<Inventory>();
                IList<Inventory> list2 = NHibernateBase.Session.CreateCriteria(typeof (Inventory)).List<Inventory>();
                IQueryable<Inventory> linq = (from l in NHibernateBase.Session.Query<Inventory>() select l);
            }
            catch (Exception ex)
            {
                string Message = ex.Message;
                if (ex.InnerException != null)
                {
                    Message += " - InnerException: " + ex.InnerException.Message;
                }
                System.Console.WriteLine();
                System.Console.WriteLine("***** ERROR *****");
                System.Console.WriteLine(Message);
                System.Console.WriteLine();
                System.Console.ReadLine();
            }
        }
    }
}