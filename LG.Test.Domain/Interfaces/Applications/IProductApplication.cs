using LG.Test.Domain.DTO;
using LG.Test.Domain.Entities;

namespace LG.Test.Domain.Interfaces.Applications
{
    public interface IProductApplication : IApplicationBase, IDBApplicationBase<Product>
    {
        CartDTO AddToCart(CartDTO cart);
        CartDTO RemoveFromCart(CartDTO cart);
    }
}
