using AutoMapper;
using JapPlatformBackend.Core.Dtos.Item;
using JapPlatformBackend.Core.Entities.Base;
using JapPlatformBackend.Core.Interfaces.Repositories;
using JapPlatformBackend.Database;

namespace JapPlatformBackend.Repositories
{
    public class ItemRepository : BaseRepository<Item, CreateItemDto, UpdateItemDto, GetItemDto>, IItemRepository
    {
        public ItemRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
