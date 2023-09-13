using ECommerceApplication.Models;
using ECommerceApplication.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;

namespace ECommerceApplication.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemService _service;

        public ItemsController(IItemService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //GET: Items/Create
        public async Task<IActionResult> Create()
        {
            var catList = await _service.GetCategoryAsync();
            ViewBag.CatList = new SelectList(catList, "CategoryId", "CategoryName");
            return View();
        }

        //POST: Items/Create
        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            if(ModelState.IsValid)
            {
                await _service.AddAsync(item);
                return RedirectToAction(nameof(Index));
            }

            return View(item);
        }

        //GET:Items/Details
        public async Task<IActionResult> Details(int id)
        {
            var deatails = await _service.GetDetailsAsync(id);
            return View(deatails);
        }

        //GET:Items/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var catList = await _service.GetCategoryAsync();
            ViewBag.CatList = new SelectList(catList, "CategoryId", "CategoryName");
            var data = await _service.GetDetailsAsync(id);
            return View(data);
        }

        //POST: Items/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Category, Name, Description, Image, Price, WasPrice, color")] Item item)
        {
            if (ModelState.IsValid)
            {
                var existingItem = await _service.GetDetailsAsync(id);

                existingItem.Category = item.Category;
                existingItem.Name = item.Name;
                existingItem.Description = item.Description;
                existingItem.Image = item.Image;
                existingItem.Price = item.Price;
                existingItem.WasPrice = item.WasPrice;
                existingItem.Color = item.Color;

                await _service.UpdateAsync(id, existingItem);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        
        //GET: Items/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var deatails = await _service.GetDetailsAsync(id);
            return View(deatails);
        }

        //POST: Items/Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        
    }
}
