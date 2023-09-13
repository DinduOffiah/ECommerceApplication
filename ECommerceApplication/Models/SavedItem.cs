using System.ComponentModel.DataAnnotations;

namespace ECommerceApplication.Models
{
    public class SavedItem
    {
        [Key]
        public int Id { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }

        public DateTime DateSaved { get; set; }
    }
}
