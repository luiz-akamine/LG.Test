using System.Collections.Generic;

namespace LG.Test.Domain.Entities
{
    public class Category : EntityBase
    {
        //public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        //
        public virtual IList<Product> Products { get; set; }
    }
}
