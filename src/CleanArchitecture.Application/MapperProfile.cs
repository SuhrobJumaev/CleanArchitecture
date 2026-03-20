using AutoMapper;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application;

public class MapperProfile : Profile
{
	public MapperProfile ()
	{
		CreateMap<Order, OrderDto>();
	}
}