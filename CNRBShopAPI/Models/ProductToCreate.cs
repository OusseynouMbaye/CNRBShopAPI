namespace CNRBShopAPI.Models
{
    public class ProductToCreate
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsProductOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
    }
}
