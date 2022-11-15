using System.ComponentModel.DataAnnotations.Schema;

namespace CNRBShopAPI.Entities
{
    //[Table("Categories")]
    public class Category 
    {
        public int CategoryId { get; set; }  //CategoryId
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ICollection<Product>? Products { get; set; } = new List<Product>();

    }
}