using AutoMapper;

namespace CNRBShopAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Models.Product, Entities.Product>().ReverseMap();
            CreateMap<Models.ProductToCreate, Entities.Product>().ReverseMap();
            CreateMap<Models.ProductForUpdate, Entities.Product>().ReverseMap();
        }
    }
}

