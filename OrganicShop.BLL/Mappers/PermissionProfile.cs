using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.PermissionDtos;
using OrganicShop.Domain.Dtos.Combo;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;

namespace OrganicShop.BLL.Mappers
//ParentTitle = Permission.Parent == null ? null : $"{Permission.Parent.Title}({Permission.Parent.EnTitle})",
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {

            CreateMap<Permission, PermissionListDto>()
                .ForMember(m => m.ParentTitle, a => a.MapFrom(b => b.Parent != null ? $"{b.Parent.Title}({b.Parent.EnTitle})" : null));


            CreateMap<CreatePermissionDto, Permission>();


            CreateMap<UpdatePermissionDto, Permission>();


            CreateMap<Permission, ComboDto<Permission>>()
                .ForMember(m => m.Text, a => a.MapFrom(b => $"{b.Title}({b.EnTitle})"))
                .ForMember(m => m.Value, a => a.MapFrom(b => b.Id));

        }


    }
}
