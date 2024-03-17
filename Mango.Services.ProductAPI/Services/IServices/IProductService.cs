using Mango.Services.ProductAPI.Models.Dto;

namespace Mango.Services.ProductAPI.Services.IServices
{
    public interface IProductService
    {
        Task<bool> CreateProductAsync(ProductDto model);
        Task<bool> GetProductAsync(int id);
        Task<bool> GetAllProductAsync();
        Task<bool> DeleteProductAsync(int id);
    }
}
