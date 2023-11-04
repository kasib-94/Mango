using Mango.ShoppingCartAPI.Models;

namespace Mango.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}