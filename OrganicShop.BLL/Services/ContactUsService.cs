using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.ContactUsDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Enums.Response;

namespace OrganicShop.BLL.Services
{
    public class ContactUsService : Service<ContactUs>, IContactUsService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IContactUsRepository _ContactUsRepository;

        public ContactUsService(IApplicationUserProvider provider,IMapper mapper,IContactUsRepository ContactUsRepository) : base(provider)
        {
            _Mapper = mapper;
            this._ContactUsRepository = ContactUsRepository;
        }

        #endregion



        public async Task<ServiceResponse<UpdateContactUsDto>> Get()
        {
            var contactUs = await _ContactUsRepository.GetQueryable().FirstAsync(a => a.Id == 1);            
            return new ServiceResponse<UpdateContactUsDto>(ResponseResult.Success, _Mapper.Map<UpdateContactUsDto>(contactUs));
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateContactUsDto update)
        {
            ContactUs? ContactUs = await _ContactUsRepository.GetQueryableTracking()
                .FirstAsync();

            if (ContactUs == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            var x = _Mapper.Map(update, ContactUs);

            await _ContactUsRepository.Update(x, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }

    }
}
