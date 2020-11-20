using AutoMapper;

namespace Inventory.API.Profiles
{
    public class StuffTypeProfile : Profile
    {
        public StuffTypeProfile()
        {
            CreateMap<StuffType, Core.Entities.StuffType>().ReverseMap();
            CreateMap<AddStuffTypeRequest, Core.Entities.StuffType>().ReverseMap();
            CreateMap<StuffTypeResponse, Core.Entities.StuffType>().ReverseMap();
            CreateMap<UpdateStuffTypeRequest, Core.Entities.StuffType>().ReverseMap();
        }
    }
}
