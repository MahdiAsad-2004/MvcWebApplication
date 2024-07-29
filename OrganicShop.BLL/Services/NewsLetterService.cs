using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.NewsLetterDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Enums;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.Combo;
using FluentValidation;

namespace OrganicShop.BLL.Services
{
    public class NewsLetterService : Service<NewsLetter>, INewsLetterService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly INewsLetterRepository _NewsLetterRepository;
        private readonly IValidator<CreateNewsLetterDto> _ValidatorCreateNewsLetter;
        private readonly IValidator<UpdateNewsLetterDto> _ValidatorUpdateNewsLetter;

        public NewsLetterService(IApplicationUserProvider provider, IMapper mapper, INewsLetterRepository NewsLetterRepository, IValidator<CreateNewsLetterDto> validatorCreateNewsLetter, IValidator<UpdateNewsLetterDto> validatorUpdateNewsLetter) : base(provider)
        {
            _Mapper = mapper;
            _NewsLetterRepository = NewsLetterRepository;
            _ValidatorCreateNewsLetter = validatorCreateNewsLetter;
            _ValidatorUpdateNewsLetter = validatorUpdateNewsLetter;
        }

        #endregion



        public async Task<ServiceResponse<PageDto<NewsLetter, NewsLetterListDto, int>>> GetAll(FilterNewsLetterDto? filter = null,PagingDto? paging = null)
        {
            var query = _NewsLetterRepository.GetQueryable();

            if (filter == null) filter = new FilterNewsLetterDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Title != null)
                query = query.Where(q => EF.Functions.Like(q.Title, $"%{filter.Title}%"));

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<NewsLetter, NewsLetterListDto,int> pageDto = new();
            pageDto.List = pageDto.SetPaging(query , paging).Select(a => _Mapper.Map<NewsLetterListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<NewsLetter, NewsLetterListDto, int>>(ResponseResult.Success,pageDto);
        }


        public async Task<ServiceResponse<UpdateNewsLetterDto>> Get(int Id)
        {
            if(Id < 1)
                return new ServiceResponse<UpdateNewsLetterDto>(ResponseResult.NotFound,null);
            
            var NewsLetter = await _NewsLetterRepository.GetAsNoTracking(Id);
            
            if(NewsLetter == null)
                return new ServiceResponse<UpdateNewsLetterDto>(ResponseResult.NotFound,null);

            return new ServiceResponse<UpdateNewsLetterDto>(ResponseResult.Success, _Mapper.Map<UpdateNewsLetterDto>(NewsLetter));
        }


        public async Task<ServiceResponse<Empty>> Create(CreateNewsLetterDto create)
        {
            var validationResult = await _ValidatorCreateNewsLetter.ValidateAsync(create);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(create, validationResult);

            NewsLetter NewsLetter = _Mapper.Map<NewsLetter>(create);

            if (await _NewsLetterRepository.GetQueryable().AnyAsync(a => EF.Functions.Like(a.Title , create.Title)))
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.EntityExist(create,a => nameof(a.Title)));

            await _NewsLetterRepository.Add(NewsLetter,_AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateNewsLetterDto update)
        {
            var validationResult = await _ValidatorUpdateNewsLetter.ValidateAsync(update);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(update, validationResult);

            NewsLetter? NewsLetter = await _NewsLetterRepository.GetAsTracking(update.Id);
            
            if (NewsLetter == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            if (await _NewsLetterRepository.GetQueryable().AnyAsync(a => EF.Functions.Like(a.Title , update.Title) && a.Id != update.Id))
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.EntityExist(update, a => nameof(a.Title)));

            await _NewsLetterRepository.Update(_Mapper.Map(update,NewsLetter), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(int delete)
        {
            NewsLetter? NewsLetter = await _NewsLetterRepository.GetAsTracking(delete);

            if (NewsLetter == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _NewsLetterRepository.SoftDelete(NewsLetter, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }

    }
}
