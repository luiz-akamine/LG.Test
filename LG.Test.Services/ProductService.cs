using System;
using LG.Test.Domain.DTO;
using LG.Test.Domain.Entities;
using LG.Test.Domain.Interfaces.Services;
using System.Linq;

namespace LG.Test.Services
{
    public class ProductService : DBServiceBase<Product>, IProductService
    {
        private readonly IUnitOfWorkService _uow;

        public ProductService(IUnitOfWorkService uow) : base(uow)
        {
            _uow = uow;
        }

        public CartDTO AddToCart(CartDTO cart)
        {
            //Checando se já existe produto no carrinho
            if (cart.Cart.Count(_ => _.Id == cart.Product.Id) <= 0)
            {
                cart.Cart.Add(new ProductCartDTO() {
                    Id = cart.Product.Id,
                    Name = cart.Product.Name,
                    Description = cart.Product.Description,
                    Picture = cart.Product.Picture,
                    Price = cart.Product.Price,
                    Qty = 1 //Primeira vez q coloca no carrinho                    
                });
            }
            else
            {
                //Adquirindo produto existente no carrinho
                var prodInCart = cart.Cart.Where(_ => _.Id == cart.Product.Id).First();
                int newQty = prodInCart.Qty + 1;
                cart.Cart.Remove(prodInCart);

                //Readicionando com a qtd certa
                cart.Cart.Add(new ProductCartDTO()
                {
                    Id = cart.Product.Id,
                    Name = cart.Product.Name,
                    Description = cart.Product.Description,
                    Picture = cart.Product.Picture,
                    Price = cart.Product.Price,
                    Qty = newQty //Nova qtd                    
                });
            }

            return cart;
        }

        public CartDTO RemoveFromCart(CartDTO cart)
        {
            //Checando se já existe produto no carrinho
            if (cart.Cart.Count(_ => _.Id == cart.Product.Id) > 0)
            {
                //Adquirindo produto existente no carrinho
                var prodInCart = cart.Cart.Where(_ => _.Id == cart.Product.Id).First();

                int newQty = prodInCart.Qty - 1;
                if (newQty < 0)
                    newQty = 0;

                cart.Cart.Remove(prodInCart);
                
                //Readicionando com a qtd certa
                cart.Cart.Add(new ProductCartDTO()
                {
                    Id = cart.Product.Id,
                    Name = cart.Product.Name,
                    Description = cart.Product.Description,
                    Picture = cart.Product.Picture,
                    Price = cart.Product.Price,
                    Qty = newQty //Nova qtd
                });
            }

            return cart;
        }
    }
}
