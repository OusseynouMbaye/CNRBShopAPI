using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CNRBShopAPI.Models
{
    public class Category 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; } 
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<Product>? Products { get; set; } = new List<Product>();

    }
}