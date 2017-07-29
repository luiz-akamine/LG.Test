namespace LG.Test.Domain.Entities
{
    public class Stock : EntityBase
    {
        //public virtual int Id { get; set; }        
        public virtual decimal Qty { get; set; }
        //
        public virtual Product Product { get; set; }
    }
}
