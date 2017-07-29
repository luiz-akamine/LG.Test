using System;
using LG.Test.Domain.Entities;
using LG.Test.Domain.Interfaces.Applications;
using LG.Test.Domain.Interfaces.Services;

namespace LG.Test.Application
{
    public class StockApplication : ApplicationBase<Stock>, IStockApplication
    {
        private readonly IStockService _StockService;
        private readonly IUnitOfWorkService _uow;

        public StockApplication(IUnitOfWorkService uow)
            : base(uow)
        {
            _uow = uow;
            _StockService = uow.Service<IStockService>();
        }

        public decimal DecStock(Product product)
        {
            return _StockService.DecStock(product);
        }

        public decimal IncStock(Product product)
        {
            return _StockService.IncStock(product);
        }
    }
}
