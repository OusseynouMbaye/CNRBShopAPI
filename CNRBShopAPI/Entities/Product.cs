using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CNRBShopAPI.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsProductOfTheWeek { get; set; }
        public bool InStock { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; } /*= default!;*/

    }
}
