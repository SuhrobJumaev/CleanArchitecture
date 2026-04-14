using AutoMapper;
using Entities;

namespace Mobile.UseCases;

public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<Entities.Order, OrderDto>();
		CreateMap<CreateOrderDto, Entities.Order>();
		CreateMap<OrderItemDto, OrderItem>();
	}
}