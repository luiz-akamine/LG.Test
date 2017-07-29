using LG.Test.Domain.Entities;

namespace LG.Test.Domain.Interfaces.Services
{
    public interface IStockService : IDBServiceBase<Stock>
    {
        decimal IncStock(Product stock);
        decimal DecStock(Product stock);
    }
}
