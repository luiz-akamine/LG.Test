﻿using LG.Test.Domain.DTO;
using LG.Test.Domain.Entities;

namespace LG.Test.Domain.Interfaces.Services
{
    public interface IStockMovService : IDBServiceBase<StockMov>
    {
        void RequestOrder(CartDTO cart);
    }
}
