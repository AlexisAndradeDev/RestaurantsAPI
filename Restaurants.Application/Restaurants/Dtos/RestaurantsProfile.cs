using AutoMapper;
using Restaurants.Application.Restaurants.Commands;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Dtos;

public class RestaurantsProfile: Profile
{
    public RestaurantsProfile()
    {
        CreateMap<CreateRestaurantCommand, Restaurant>()
            .ForMember(r => r.Address, opt => opt.MapFrom(
                dto => new Address
                {
                    City = dto.City,
                    Street = dto.Street,
                    PostalCode = dto.PostalCode,
                }));

        CreateMap<Restaurant, RestaurantDto>()
            .ForMember(dto => dto.City, opt =>
                opt.MapFrom(entity => entity.Address == null ? null : entity.Address.City))
            .ForMember(dto => dto.Street, opt =>
                opt.MapFrom(entity => entity.Address == null ? null : entity.Address.Street))
            .ForMember(dto => dto.PostalCode, opt =>
                opt.MapFrom(entity => entity.Address == null ? null : entity.Address.PostalCode))
            .ForMember(dto => dto.Dishes, opt => opt.MapFrom(entity => entity.Dishes));
    }
}
