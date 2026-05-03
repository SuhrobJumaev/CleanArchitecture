using AutoMapper;
using Entities.Models;

namespace Mobile.UseCases;

public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<Entities.Models.Order, OrderDto>();
		CreateMap<CreateOrderDto, Entities.Models.Order>();
		CreateMap<OrderItemDto, OrderItem>();
	}
}