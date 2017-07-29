using LG.Test.Domain.Entities;
using LG.Test.Domain.Interfaces.Services;
using LG.Test.Domain.DTO;
using System;

namespace LG.Test.Services
{
    public class StockMovService : DBServiceBase<StockMov>, IStockMovService
    {
        private readonly IUnitOfWorkService _uow;

        public StockMovService(IUnitOfWorkService uow) : base(uow)
        {
            _uow = uow;
        }

        public void RequestOrder(CartDTO cart)
        {
            IStockService stockService = _uow.Service<StockService>();
            IProductService productService = _uow.Service<ProductService>();            
            IUserService userService = _uow.Service<UserService>();
            
            _uow.BeginTransaction();            

            //Descontar itens do estoque
            foreach (var requestedProduct in cart.Cart)
            {
                //Loop na qtd (sim, poderia ser melhor pensando em performance, mas para o teste vou deixar assim mesmo..)
                for (int i = 1; i <= requestedProduct.Qty; i++)
                {
                    //Checando se há saldo
                    var product = productService.Get(_ => _.Id == requestedProduct.Id);
                    var stock = stockService.Get(_ => _.Id == product.Stock.Id);

                    if (stock.Qty <= 0)
                    {
                        _uow.RollBack();
                        throw new Exception(String.Format("Produto {0} com falta de estoque", product.Name));
                    }

                    stockService.DecStock(product);
                }

                //Adicionando movimentação de estoque
                _repository.Add(new StockMov()
                {
                    DateTimeStamp = DateTime.Now,
                    Product = productService.Get(_ => _.Id == requestedProduct.Id),
                    Qty = requestedProduct.Qty * -1,
                    User = userService.Get(_ => _.Id == 1) //usuário qualquer para o teste
                });
            }            

            _uow.Commit();
        }
    }
}
