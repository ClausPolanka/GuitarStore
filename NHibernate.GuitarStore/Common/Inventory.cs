using System;

namespace NHibernate.GuitarStore.Common
{
    public class Inventory
    {
        public Inventory()
        {
        }

        public virtual Guid Id { get; set; }
        public virtual Guid TypeId { get; set; }
        public virtual string Builder { get; set; }
        public virtual string Model { get; set; }
        public virtual int? QOH { get; set; }
        public virtual decimal? Cost { get; set; }
        public virtual decimal? Price { get; set; }
        public virtual DateTime? Received { get; set; }
    }
}