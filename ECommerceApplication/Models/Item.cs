using System.ComponentModel.DataAnnotations;

namespace ECommerceApplication.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string? Category { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int WasPrice { get; set; }
        public string? Color { get; set; }
        [Display(Name = "Image URL")]
        public string? Image { get; set; }
    }
}
