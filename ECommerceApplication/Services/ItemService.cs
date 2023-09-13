using ECommerceApplication.Data;
using ECommerceApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Services
{
    public class ItemService : IItemService
    {
        private readonly ApplicationDbContext _context;

        public ItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Item item)
        {

            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item =  _context.Items.FirstOrDefault(result => result.ItemId == id);
            _context.Items.Remove(item);
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            var items = await _context.Items.OrderByDescending(item => item.ItemId).ToListAsync();
            return items;
        }

        public async Task<Item> GetDetailsAsync(int id)
        {
            var details = await _context.Items.FirstOrDefaultAsync(item => item.ItemId == id);
            return details;
        }

        public async Task<Item> UpdateAsync(int id, Item item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<IEnumerable<Category>> GetCategoryAsync()
        {
            var catList = await _context.Categories.ToListAsync();
            return catList;
        }
    }
}
