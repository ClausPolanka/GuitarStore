using System;
using System.Collections.Generic;

namespace NHibernate.GuitarStore.Common
{
    public class Guitar
    {
        public virtual Guid Id { get; set; }
        public virtual string Type { get; set; }
        private IList<Inventory> Inventory { get; set; }
    }
}