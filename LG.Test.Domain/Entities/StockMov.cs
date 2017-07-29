using System;

namespace LG.Test.Domain.Entities
{
    public class StockMov : EntityBase
    {
        //public virtual int Id { get; set; }
        public virtual DateTime DateTimeStamp { get; set; }
        public virtual decimal Qty { get; set; }
        //
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
