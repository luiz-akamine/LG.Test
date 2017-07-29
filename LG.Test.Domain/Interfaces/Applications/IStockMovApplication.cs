using LG.Test.Domain.DTO;
using LG.Test.Domain.Entities;

namespace LG.Test.Domain.Interfaces.Applications
{
    public interface IStockMovApplication : IApplicationBase, IDBApplicationBase<StockMov>
    {
        void RequestOrder(CartDTO cart);
    }
}
