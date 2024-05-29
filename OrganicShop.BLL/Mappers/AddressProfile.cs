using AutoMapper;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.ComplexTypes;

namespace OrganicShop.BLL.Mappers
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {

            CreateMap<Address,AddressListDto>();


            CreateMap<CreateAddressDto,Address>();
            

            CreateMap<UpdateAddressDto,Address>();
        

            CreateMap<Address,OrderAddress>();

        }
    }

    public static class AddressMappers
    {
        public static OrderAddress ToOrderAddress(this Address address)
        {
            return new OrderAddress
            {
                AddressId = address.Id,
                PhoneNumber = address.PhoneNumber,
                PostCode = address.PostCode,
                Province = address.Province,
                ReceiverName = address.ReceiverName,
                Text = address.Text,
            };
        }
    }

}
