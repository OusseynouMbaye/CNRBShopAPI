using CNRBShopAPI.Models;

namespace CNRBShopAPI
{
    public class CategoriesDataStore
    {
        public List<Category> Categories { get; set; }

        public static CategoriesDataStore categoriesData { get; } = new CategoriesDataStore();
        //private readonly ProductsDataStore _productsDataStore = new ProductsDataStore();

        public CategoriesDataStore()
        {
            Categories = new List<Category>()
            {
                new Category()
                {
                    CategoryId = 1,
                    CategoryName= "chandails",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's " +
                    "standard dummy text ever since the 1500s",
                    //Products = _productsDataStore.Products
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName= "Paddle",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's " +
                    "standard dummy text ever since the 1500s",
                    //Products = _productsDataStore.Products
                }
            };
        }
    }
}
