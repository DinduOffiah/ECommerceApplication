using ECommerceApplication.Models;

namespace ECommerceApplication.Services
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetAllAsync();

        Task AddAsync(Item item);

        Task<Item> GetDetailsAsync(int id);

        Task<Item> UpdateAsync(int id, Item item);

        Task DeleteAsync(int id);

        Task<IEnumerable<Category>> GetCategoryAsync();

    }
}
