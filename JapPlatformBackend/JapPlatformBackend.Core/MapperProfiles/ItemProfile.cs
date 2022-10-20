using AutoMapper;
using JapPlatformBackend.Common;
using JapPlatformBackend.Core.Dtos.Item;

namespace JapPlatformBackend.Core.MapperProfiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<BaseSearch, ItemSearchDto>().ReverseMap();
        }
    }
}
