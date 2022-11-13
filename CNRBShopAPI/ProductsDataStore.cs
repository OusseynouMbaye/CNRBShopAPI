using CNRBShopAPI.Models;

namespace CNRBShopAPI
{
    public class ProductsDataStore
    {
        public List<Product> Products { get; set; }
        public static ProductsDataStore productsData { get; } = new ProductsDataStore();
        private readonly CategoriesDataStore _categoriesDataStore = new CategoriesDataStore();
        public ProductsDataStore()
        {
            /*Products = new List<Product>()
            {
                new Product()
                {
                    ProductId = 1,
                    ProductName="Dry fit man",
                    Price = 25.25M,
                    ShortDescription = "Lorem Ipsum",
                    LongDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    CategoryId = 1,
                    Category = _categoriesDataStore.Categories.ToList()[0],
                    ImageUrl="",
                    ImageThumbnailUrl ="",
                    InStock =true,
                    IsProductOfTheWeek=false
                },new Product()
                {
                    ProductId = 2,
                    ProductName="Paddle MP",
                    Price = 15.15M,
                    ShortDescription = "Lorem Ipsum",
                    LongDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    CategoryId = 2,
                    Category = _categoriesDataStore.Categories.ToList()[0],
                    ImageUrl="",
                    ImageThumbnailUrl ="",
                    InStock =true,
                    IsProductOfTheWeek=false
                }
            };*/
        }



    }
}
