using System.Collections.Generic;

namespace LG.Test.Domain.Entities
{
    public class User : EntityBase
    {
        // public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Password { get; set; }
        //
        public virtual IList<StockMov> StockMovs { get; set; }
    }
}
