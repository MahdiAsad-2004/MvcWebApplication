using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.BLL.Providers;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Models;
using OrganicShop.Domain.Response;
using System.Reflection;
using System.Threading.Channels;

namespace OrganicShop.BLL.Services
{
    public class AddressService : Service<Address>, IAddressService
    {
        #region ctor
        
        private readonly IAddressRepository _AddressRepository;
        private readonly IMapper _Mapper;

        public AddressService(ApplicationUserProvider applicationUserProvider, IMapper mapper, IAddressRepository AddressRepository) : base(applicationUserProvider)
        {
            _AddressRepository = AddressRepository;
            _Mapper = mapper;
        }

        #endregion


        public async Task<ServiceResponse<PageDto<Address, AddressListDto, long>>> GetAll(FilterAddressDto? filter = null, PagingDto? paging = null)
        {
            var query = _AddressRepository.GetQueryable();
            
            if (filter == null) filter = new FilterAddressDto();
            if(paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.UserId > 0)
                query = query.Where(a => a.UserId == filter.UserId);

            #endregion

            #region sort

            query = filter.ApplySortType(filter.SortBy, query);

            #endregion

            PageDto<Address, AddressListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<AddressListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Address, AddressListDto, long>>(ResponseResult.Success, pageDto);
        }


     


        public async Task<ServiceResponse<Empty>> Create(CreateAddressDto create)
        {
            if (await _AddressRepository.GetQueryable().Where(a => a.UserId == create.UserId).CountAsync() > 4)
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.MaxCreate(4));

            Address Address = _Mapper.Map<Address>(create);
            await _AddressRepository.Add(Address, _AppUserProvider.User.Id);

            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateAddressDto update)
        {
            Address? Address = await _AddressRepository.GetAsTracking(update.Id);

            if (Address == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            if (Address.UserId != update.UserId)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NoAccess());

            await _AddressRepository.Update(_Mapper.Map<Address>(update), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(long delete)
        {

            Address? Address = await _AddressRepository.GetAsTracking(delete);

            if (Address == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _AddressRepository.SoftDelete(Address, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }

       
     
    }
}
