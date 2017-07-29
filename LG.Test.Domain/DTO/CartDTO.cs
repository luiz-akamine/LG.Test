using LG.Test.Domain.Entities;
using System.Collections.Generic;

namespace LG.Test.Domain.DTO
{
    public class ProductCartDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }        
        //
        public int Qty { get; set; } //Qtd no carrinho       
    }

    public class CartDTO
    {
        public Product Product { get; set; } //produto q será adicionado
        public IList<ProductCartDTO> Cart; //lista de produtos ja adicionados        

        public CartDTO()
        {
            Cart = new List<ProductCartDTO>();
        }
    }
}
