
using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IProductService
    {
        Task<ResponseDto?> GetAllProductsAsync();
        Task<ResponseDto?> DeleteProductsAsync(int id);
        Task<ResponseDto?> GetProductsByIdAsync(int id);
        Task<ResponseDto?> CreateProductsAsync(ProductDto couponDto);
        Task<ResponseDto?> UpdateProductsAsync(ProductDto couponDto);
    }
}
