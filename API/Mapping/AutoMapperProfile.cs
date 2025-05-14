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
        }   
    }
}