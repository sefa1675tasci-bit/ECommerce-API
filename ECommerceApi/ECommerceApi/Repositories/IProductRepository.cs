using ECommerceApi.Entities;

namespace ECommerceApi.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(int id);

        Task<Product> AddAsync(Product product);

        Task UpdateAsync(Product product);

        Task DeleteAsync(Product product);

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<List<Product>> SearchAsync(string search);
    }
}