using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Dtos.BankCardDtos;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Response;
using OrganicShop.Domain.Dtos.AddressDtos;
using AutoMapper;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Enums.SortTypes;
using FluentValidation;

namespace OrganicShop.BLL.Services
{
    public class BankCardService : Service<BankCard> , IBankCardService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IBankCardRepository _BankCardRepository;
        private readonly IValidator<CreateBankCardDto> _ValidatorCreateBankCard;
        private readonly IValidator<UpdateBankCardDto> _ValidatorUpdateBankCard;

        public BankCardService(IApplicationUserProvider provider, IMapper mapper, IBankCardRepository BankCardRepository,
            IValidator<CreateBankCardDto> validatorCreateBankCard, IValidator<UpdateBankCardDto> validatorUpdateBankCard) : base(provider)
        {
            _Mapper = mapper;
            _BankCardRepository = BankCardRepository;
            _ValidatorCreateBankCard = validatorCreateBankCard;
            _ValidatorUpdateBankCard = validatorUpdateBankCard;
        }

        #endregion



        public async Task<ServiceResponse<PageDto<BankCard, BankCardListDto, long>>> GetAll(FilterBankCardDto?filter = null, PagingDto? paging = null)
        {
            var query = _BankCardRepository.GetQueryable();

            if (filter == null) filter = new FilterBankCardDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.UserId > 0)
                query = query.Where(q => q.UserId == filter.UserId);

            #endregion

            #region sort

            query = filter.ApplySortType(filter.SortBy, query);

            #endregion

            PageDto<BankCard, BankCardListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<BankCardListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);


            return new ServiceResponse<PageDto<BankCard, BankCardListDto, long>>(ResponseResult.Success,pageDto);
        }



        public async Task<ServiceResponse<Empty>> Create(CreateBankCardDto create)
        {
            var validationResult = await _ValidatorCreateBankCard.ValidateAsync(create);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(create, validationResult);

            if (await _BankCardRepository.GetQueryable().Where(a => a.UserId == create.UserId).CountAsync() > 8)
                return new ServiceResponse<Empty>(ResponseResult.Failed , _Message.MaxCreate(8));

            BankCard BankCard = _Mapper.Map<BankCard>(create);
            await _BankCardRepository.Add(BankCard, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }

            

        public async Task<ServiceResponse<Empty>> Update(UpdateBankCardDto update)
        {
            var validationResult = await _ValidatorUpdateBankCard.ValidateAsync(update);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(update, validationResult);

            BankCard? BankCard = await _BankCardRepository.GetAsTracking(update.Id);

            if (BankCard == null)
                return new ServiceResponse<Empty>(ResponseResult.Success, _Message.NotFound());

            if (BankCard.UserId != update.UserId)
                return new ServiceResponse<Empty>(ResponseResult.Success, _Message.NoAccess());

            await _BankCardRepository.Update(_Mapper.Map<BankCard>(update), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(long delete)
        {

            BankCard? BankCard = await _BankCardRepository.GetAsTracking(delete);

            if (BankCard == null)
                return new ServiceResponse<Empty>(ResponseResult.Success, _Message.NotFound());

            await _BankCardRepository.SoftDelete(BankCard, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }
    }
}
