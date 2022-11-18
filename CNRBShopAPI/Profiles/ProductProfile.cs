using AutoMapper;

namespace CNRBShopAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Models.Product,Entities.Product>().ReverseMap();
            //CreateMap<Entities.Product,Models.Product>();
        }
    }
}

