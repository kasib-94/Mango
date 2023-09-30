
using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IProductService
    {
        Task<ResponseDto?> GetProductAsync(string ProductName);
        Task<ResponseDto?> GetAllProductsAsync();
        Task<ResponseDto?> DeleteProductAsync(int id);
        Task<ResponseDto?> GetProductByIdAsync(int id);
        Task<ResponseDto?> CreateProductAsync(ProductDto couponDto);
        Task<ResponseDto?> UpdateProductAsync(ProductDto couponDto);
    }
}
