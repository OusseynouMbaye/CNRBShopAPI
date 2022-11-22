namespace CNRBShopAPI.Models
{
    public class ProductForUpdateDto
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsProductOfTheWeek { get; set; }
        public bool InStock { get; set; }

        /* Do i need to specify this verification in the models */
        //[ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; } /*= default!; */
    }
}
