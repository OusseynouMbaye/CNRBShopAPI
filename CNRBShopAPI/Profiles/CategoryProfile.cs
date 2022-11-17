using AutoMapper;

namespace CNRBShopAPI.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Models.Category, Entities.Category>().ReverseMap();
        }
    }
}
