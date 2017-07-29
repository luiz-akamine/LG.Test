using LG.Test.Domain.DTO;
using LG.Test.Domain.Entities;

namespace LG.Test.Domain.Interfaces.Services
{
    public interface IProductService : IDBServiceBase<Product>
    {
        CartDTO AddToCart(CartDTO cart);
        CartDTO RemoveFromCart(CartDTO cart);
    }
}
