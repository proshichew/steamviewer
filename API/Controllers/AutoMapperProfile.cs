using API.DTO;
using AutoMapper;
using DAL.DbEntities;

namespace API.Controllers
{
    public class AutoMapperProfile : Profile
    {
		public AutoMapperProfile()
		{			
			CreateMap<Game, GameDto>();
			CreateMap<GameDto, Game>();
		}   
    }
}