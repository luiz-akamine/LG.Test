using System.Collections.Generic;

namespace LG.Test.Domain.Entities
{
    public class Product : EntityBase
    {
        //public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string Picture { get; set; }
        //
        public virtual Category Category { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual IList<StockMov> StockMovs { get; set; }
    }
}
