using LG.Test.Domain.Entities;
using LG.Test.Domain.Interfaces.Repositories;
using LG.Test.Domain.Interfaces.Infra;
using System;

namespace LG.Test.Infra.Repositories
{
    public class StockRepository : RepositoryBase<Stock>, IStockRepository
    {
        public StockRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }        
    }
}
