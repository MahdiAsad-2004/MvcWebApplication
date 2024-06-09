using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.PropertyDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.Combo;

namespace OrganicShop.BLL.Mappers
{
    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {

            CreateMap<Property, PropertyListDto>();


            CreateMap<CreatePropertyDto, Property>();


            CreateMap<UpdatePropertyDto, Property>()
                .ReverseMap();




            //CreateMap<Property, ComboDto<Property>>()
            //  .ForMember(m => m.Value, a => a.MapFrom(b => b.Id))
            //  .ForMember(m => m.Text, a => a.MapFrom(b => ""));

        }

    }


    public static class ProperyMappers
    {
        public static PropertyListDto ToListDto(this Property property)
        {
            return new PropertyListDto
            {
                Id = property.Id,
                Value = property.Value,
                Title = property.PropertyType.Title,
                Priority = property.PropertyType.Priority,
            };
        }

    }

}
