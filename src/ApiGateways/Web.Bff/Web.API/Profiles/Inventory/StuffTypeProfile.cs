using AutoMapper;
using GrpcInventory;
using Web.API.Models.Inventory;

namespace Web.API.Profiles.Inventory
{
    public class StuffTypeProfile : Profile
    {
        public StuffTypeProfile()
        {
            CreateMap<StuffTypeResponse, StuffTypeModel>().ReverseMap();
            CreateMap<AddStuffTypeRequest, StuffTypeModel>().ReverseMap();
        }
    }
}
