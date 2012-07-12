using System;
using NHibernate.Mapping.ByCode.Conformist;

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

//    public class InventoryMap : ClassMapping<Inventory>
//    {
//        public InventoryMap()
//        {
//            Id<Guid>(x => x.Id, map => { map.Column("ID"); });
//            Property<Guid>(x => x.TypeId, map => map.Column("TYPEID"));
//            Property<string>(x => x.Builder, map => map.Column("BUILDER"));
//            Property<string>(x => x.Model, map => map.Column("MODEL"));
//            Property<int?>(x => x.QOH, map => map.Column("QOH"));
//            Property<decimal?>(x => x.Cost, map => map.Column("COST"));
//            Property<decimal?>(x => x.Price, map => map.Column("PRICE"));
//            Property<DateTime?>(x => x.Received, map => map.Column("RECEIVED"));
//        }
//    }