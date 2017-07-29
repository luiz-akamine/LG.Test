using System;
using LG.Test.Domain.DTO;
using LG.Test.Domain.Entities;
using LG.Test.Domain.Interfaces.Applications;
using LG.Test.Domain.Interfaces.Services;

namespace LG.Test.Application
{
    public class ProductApplication : ApplicationBase<Product>, IProductApplication
    {
        private readonly IProductService _productService;
        private readonly IUnitOfWorkService _uow;

        public ProductApplication(IUnitOfWorkService uow)
            : base(uow)
        {
            _uow = uow;
            _productService = uow.Service<IProductService>();
        }

        public CartDTO AddToCart(CartDTO cart)
        {
            return _productService.AddToCart(cart);
        }

        public CartDTO RemoveFromCart(CartDTO cart)
        {
            return _productService.RemoveFromCart(cart);
        }
    }
}
