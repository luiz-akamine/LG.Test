using System;
using LG.Test.Domain.DTO;
using LG.Test.Domain.Entities;
using LG.Test.Domain.Interfaces.Applications;
using LG.Test.Domain.Interfaces.Services;

namespace LG.Test.Application
{
    public class StockMovApplication : ApplicationBase<StockMov>, IStockMovApplication
    {
        private readonly IStockMovService _StockMovService;
        private readonly IUnitOfWorkService _uow;

        public StockMovApplication(IUnitOfWorkService uow)
            : base(uow)
        {
            _uow = uow;
            _StockMovService = uow.Service<IStockMovService>();
        }

        public void RequestOrder(CartDTO cart)
        {
            _StockMovService.RequestOrder(cart);
        }
    }
}
