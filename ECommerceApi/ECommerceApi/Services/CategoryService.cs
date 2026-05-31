using ECommerceApi.Entities;
using ECommerceApi.Repositories;

namespace ECommerceApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Category> AddAsync(Category category)
        {
            return await _repository.AddAsync(category);
        }

        public async Task UpdateAsync(Category category)
        {
            await _repository.UpdateAsync(category);
        }

        public async Task DeleteAsync(Category category)
        {
            await _repository.DeleteAsync(category);
        }
    }
}