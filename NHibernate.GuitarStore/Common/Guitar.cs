using System;
using System.Collections.Generic;

namespace NHibernate.GuitarStore.Common
{
    public class Guitar
    {
        public Guitar()
        {
        }

        public Guitar(Guid id, string guitarType)
        {
            Id = id;
            Type = guitarType;
        }

        public virtual Guid Id { get; set; }
        public virtual string Type { get; set; }
        private IList<Inventory> Inventory { get; set; }
    }
}