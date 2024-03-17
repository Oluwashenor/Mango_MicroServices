using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IProductService
    {
        Task<ResponseDto?> GetProductAsync(string ProductId);
        Task<ResponseDto?> GetAllProductAsync();
        Task<ResponseDto?> GetProductByIdAsync(int id);
        Task<ResponseDto?> CreateProductsAsync(ProductDto product);
        Task<ResponseDto?> UpdateProductsAsync(ProductDto product);
        Task<ResponseDto?> DeleteProductsAsync(int id);
    }
}
