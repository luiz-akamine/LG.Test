using LG.Test.Domain.Entities;
using LG.Test.Domain.Interfaces.Services;
using LG.Test.Domain.Interfaces.Infra;
using System;
using LG.Test.Domain.Interfaces.Repositories;
using LG.Test.Infra.Repositories;

namespace LG.Test.Services
{
    public class StockService : DBServiceBase<Stock>, IStockService
    {
        private readonly IUnitOfWorkService _uow;        

        public StockService(IUnitOfWorkService uow) : base(uow)
        {
            _uow = uow;
        }

        public decimal DecStock(Product product)
        {
            Stock stockUpdate = _repository.Get(_ => _.Id == product.Stock.Id);
            stockUpdate.Qty--;
            _repository.Update(stockUpdate);
            return stockUpdate.Qty;
        }

        public decimal IncStock(Product product)
        {
            Stock stockUpdate = _repository.Get(_ => _.Id == product.Stock.Id);
            stockUpdate.Qty++;
            _repository.Update(stockUpdate);
            return stockUpdate.Qty;
        }
    }
}
