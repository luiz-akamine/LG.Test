using LG.Test.Domain.Entities;

namespace LG.Test.Domain.Interfaces.Applications
{
    public interface IStockApplication : IApplicationBase, IDBApplicationBase<Stock>
    {
        decimal IncStock(Product stock);
        decimal DecStock(Product stock);
    }
}
