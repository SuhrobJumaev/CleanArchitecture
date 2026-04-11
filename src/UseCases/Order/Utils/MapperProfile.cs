using AutoMapper;
using Domain.Entities;

namespace UseCases;

public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<Domain.Entities.Order, OrderDto>();
		CreateMap<CreateOrderDto, Domain.Entities.Order>();
		CreateMap<OrderItemDto, OrderItem>();
	}
}