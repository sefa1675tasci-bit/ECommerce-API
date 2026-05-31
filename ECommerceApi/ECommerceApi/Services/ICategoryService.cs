using ECommerceApi.Entities;

namespace ECommerceApi.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();

        Task<Category?> GetByIdAsync(int id);

        Task<Category> AddAsync(Category category);

        Task UpdateAsync(Category category);

        Task DeleteAsync(Category category);
    }
}
