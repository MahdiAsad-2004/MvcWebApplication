﻿using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Extensions;
using OrganicShop.BLL.Mappers;
using OrganicShop.BLL.Providers;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.Dtos.ArticleDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Models;
using OrganicShop.Domain.Response;

namespace OrganicShop.BLL.Services
{
    public class ArticleService : Service<Article>, IArticleService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IArticleRepository _ArticleRepository;
        private readonly IValidator<CreateArticleDto> _ValidatorCreateArticle;
        private readonly IValidator<UpdateArticleDto> _ValidatorUpdateArticle;

        public ArticleService(IApplicationUserProvider applicationUserProvider, IMapper mapper, IArticleRepository ArticleRepository,
            IValidator<CreateArticleDto> validatorCreateArticle, IValidator<UpdateArticleDto> validatorUpdateArticle) : base(applicationUserProvider)
        {
            _ArticleRepository = ArticleRepository;
            _Mapper = mapper;
            _ValidatorCreateArticle = validatorCreateArticle;
            _ValidatorUpdateArticle = validatorUpdateArticle;
        }

        #endregion


        public async Task<ServiceResponse<PageDto<Article, ArticleListDto, int>>> GetAll(FilterArticleDto? filter = null, PagingDto? paging = null)
        {
            var query = _ArticleRepository.GetQueryable()
                .Include(a => a.User)
                .Include(a => a.Category)
                .Include(a => a.Pictures)
                .AsQueryable();

            if (filter == null) filter = new FilterArticleDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Title != null)
                query = query.Where(a => EF.Functions.Like(filter.Title, $"%{a.Title}%"));

            if (filter.AuthorName != null)
                query = query.Where(a => EF.Functions.Like(filter.AuthorName, $"%{a.User.Name}%"));

            if (filter.UserId > 0)
                query = query.Where(a => a.UserId == filter.UserId.Value);

            if (filter.CategoryId > 0)
                query = query.Where(a => a.CategoryId.Equals(filter.CategoryId.Value));

            if (filter.MinCreateDate != null)
                query = query.Where(a => a.BaseEntity.CreateDate > filter.MinCreateDate.Value);

            if (filter.TagIds != null)
            {
                //query = query.Where(q => q.TagArticles.Any(a => filter.TagIds.Any(b => b == a.ArticleId)));
                query = query.Where(q => q.TagArticles.Any(a => filter.TagIds.Contains(a.Id)));
            }


            #endregion

            #region sort

            query = filter.ApplySortType(filter.SortBy, query);

            #endregion

            PageDto<Article, ArticleListDto, int> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<ArticleListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Article, ArticleListDto, int>>(ResponseResult.Success, pageDto);
        }


        public async Task<ServiceResponse<UpdateArticleDto>> Get(int Id)
        {
            if (Id < 1)
                return new ServiceResponse<UpdateArticleDto>(ResponseResult.NotFound, null);

            var product = await _ArticleRepository.GetQueryable()
                .AsNoTracking()
                .Include(a => a.Pictures)
                .Include(a => a.User)
                .Include(a => a.Category)
                .Include(a => a.TagArticles)
                    .ThenInclude(a => a.Tag)
                .FirstOrDefaultAsync(a => a.Id.Equals(Id));

            if (product != null)
                return new ServiceResponse<UpdateArticleDto>(ResponseResult.Success, _Mapper.Map<UpdateArticleDto>(product));

            return new ServiceResponse<UpdateArticleDto>(ResponseResult.NotFound, null);
        }



        public async Task<ServiceResponse<ArticleDetailDto>> GetDetail(int? id = null, string? title = null)
        {
            Article article;
            if (id == null && string.IsNullOrEmpty(title))
                throw new ArgumentNullException("Article Id and Article Title");
            var query = _ArticleRepository.GetQueryable();

            #region includes

            query = query
                .Include(a => a.User)
                .Include(a => a.Pictures)
                .Include(a => a.Category)
                .Include(a => a.Comments)
                    .ThenInclude(a => a.User)
                        .ThenInclude(a => a.Picture)
                .Include(a => a.TagArticles)
                .AsQueryable();

            #endregion

            if (id != null)
            {
                if (id < 1)
                    return new ServiceResponse<ArticleDetailDto>(ResponseResult.NotFound, null);

                article = await query.FirstOrDefaultAsync(a => a.Id == id);
            }
            else
            {
                article = await query.FirstOrDefaultAsync(a => a.Title == title);
            }

            if (article == null)
                return new ServiceResponse<ArticleDetailDto>(ResponseResult.NotFound, null);

            return new ServiceResponse<ArticleDetailDto>(ResponseResult.Success, _Mapper.Map<ArticleDetailDto>(article));
        }



        public async Task<ServiceResponse<Empty>> Create(CreateArticleDto create)
        {
            var validationResult = await _ValidatorCreateArticle.ValidateAsync(create);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(create, validationResult);

            if (await _ArticleRepository.GetQueryable().AnyAsync(a => a.Title == create.Title))
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.EntityExist(create, a => nameof(a.Title)));

            Article Article = _Mapper.Map<Article>(create);
            await _ArticleRepository.Add(Article, _AppUserProvider.User.Id);

            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateArticleDto update)
        {
            var validationResult = await _ValidatorUpdateArticle.ValidateAsync(update);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(update, validationResult);

            if (await _ArticleRepository.GetQueryable().AnyAsync(a => a.Id != update.Id && a.Title == update.Title))
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.EntityExist(update, a => nameof(a.Title)));

            Article? Article = await _ArticleRepository.GetQueryableTracking()
                .Include(a => a.Pictures)
                .Include(a => a.TagArticles)
                    .ThenInclude(a => a.Tag)
                .FirstOrDefaultAsync(a => a.Id.Equals(update.Id));

            if (Article == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            if (Article.UserId != _AppUserProvider.User.Id)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NoAccess());

            #region Tags

            if (update.TagIds != null)
            {
                foreach (var tagArticle in Article.TagArticles.ExceptBy(update.TagIds, a => a.TagId))
                {
                    Article.TagArticles.Remove(tagArticle);
                }

                foreach (var tagId in update.TagIds.ExceptBy(Article.TagArticles.Select(a => a.TagId), a => a))
                {
                    Article.TagArticles.Add(new TagArticles
                    {
                        ArticleId = Article.Id,
                        TagId = tagId,
                        BaseEntity = new BaseEntity(true),
                    });
                }
            }

            #endregion

            #region Picture

            if (update.MainPictureFile != null)
            {
                var oldMainPicture = Article.Pictures.FirstOrDefault(a => a.IsMain);
                if (oldMainPicture != null)
                {
                    oldMainPicture.BaseEntity.IsActive = false;
                }
                var mainPicture = await update.MainPictureFile.SavePictureAsync(PathKey.ArticleImages, PictureType.Article);
                mainPicture.IsMain = true;
                Article.Pictures.Add(mainPicture);
            }

            #endregion

            await _ArticleRepository.Update(_Mapper.Map(update, Article), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(int delete)
        {
            Article? Article = await _ArticleRepository.GetAsTracking(delete);

            if (Article == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _ArticleRepository.SoftDelete(Article, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }



    }
}
