using Mango.Services.OrderAPI.Models;

namespace Mango.Services.OrderAPI.Service
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}