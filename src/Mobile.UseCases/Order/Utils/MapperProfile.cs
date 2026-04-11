using AutoMapper;
using Domain.Entities;

namespace Mobile.UseCases;

public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<Domain.Entities.Order, OrderDto>();
		CreateMap<CreateOrderDto, Domain.Entities.Order>();
		CreateMap<OrderItemDto, OrderItem>();
	}
}