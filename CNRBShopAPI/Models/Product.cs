using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CNRBShopAPI.Models
{
    public class Product 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        //public string? ShortDescription { get; set; }
        //public string? LongDescription { get; set; }
        public decimal Price { get; set; }
        //public string? ImageUrl { get; set; }
        //public string? ImageThumbnailUrl { get; set; }
        public bool IsProductOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = default!; 

    }
}
