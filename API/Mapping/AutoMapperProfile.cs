using API.DTO;
using AutoMapper;

namespace API.Mapping
{
    public class AutoMapperProfile : Profile
    {
		public AutoMapperProfile()
		{			
			CreateMap<Domain.Entities.Game, GameDto>();
			CreateMap<GameDto, Domain.Entities.Game>();

            CreateMap<Domain.Entities.Wishlist, WishlistDto>();
            CreateMap<WishlistDto, Domain.Entities.Wishlist>();

            CreateMap<Domain.Entities.Inventory, InventoryDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<InventoryDto, Domain.Entities.Inventory>();

            CreateMap<Domain.Entities.Item, ItemDto>();
            CreateMap<ItemDto, Domain.Entities.Item>();
        }   
    }
}