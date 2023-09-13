using ECommerceApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Controllers
{
    public class SavedItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SavedItemsController(ApplicationDbContext context)
        { 
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Like()
        {
            return View();
        }
    }
}
