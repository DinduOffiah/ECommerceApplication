using ECommerceApplication.Data;
using ECommerceApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context) 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        //GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Categories/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("CategoryName")] Category category)
        {
            if(ModelState.IsValid)
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));

        }

        //GET: Categories/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var catName = await _context.Categories.FirstOrDefaultAsync(result => result.CategoryId == id);
            return View(catName);
        }

        //POST: Categories/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId, CategoryName")] Category category)
        {
            if(ModelState.IsValid && category != null)
            {
                var existingCategory = await _context.Categories.FindAsync(id);
                existingCategory.CategoryName = category.CategoryName;
                _context.Update(existingCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        //GET: Categories/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var deleteRecord = await _context.Categories.FirstOrDefaultAsync(result => result.CategoryId == id);
            return View(deleteRecord);
        }

        //POST: Categories/Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
