using API.DTO;
using AutoMapper;
using Domain.Entities;

namespace API.Controllers
{
    public class AutoMapperProfile : Profile
    {
		public AutoMapperProfile()
		{			
			CreateMap<Game, GameDto>();
		}   
    }
}