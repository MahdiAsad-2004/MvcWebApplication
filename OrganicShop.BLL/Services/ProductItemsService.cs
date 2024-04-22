using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.ProductItemDtos;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Enums.Response;

namespace OrganicShop.BLL.Services
{
    public class ProductItemService : Service<ProductItem>, IProductItemService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IProductItemRepository _ProductItemRepository;
        private readonly ICartRepository _CartRepository;

        public ProductItemService(IApplicationUserProvider provider,IMapper mapper,IProductItemRepository ProductItemRepository, ICartRepository CartRepository)
            : base(provider)
        {
            _Mapper = mapper;
            _ProductItemRepository = ProductItemRepository;
            _CartRepository = CartRepository;
        }

        #endregion


        public async Task<ServiceResponse<PageDto<ProductItem, ProductItemListDto, long>>> GetAll(FilterProductItemDto? filter = null, PagingDto? paging = null)
        {
            var query = _ProductItemRepository.GetQueryable();

            if (filter == null) filter = new FilterProductItemDto();
            if (paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.ProductId > 0)
                query = query.Where(q => q.ProductId == filter.ProductId);

            if (filter.CartId > 0)
                query = query.Where(q => q.CartId == filter.CartId);

            if (filter.OrderId > 0)
                query = query.Where(q => q.OrderId == filter.OrderId);

            if (filter.IsOrdered != null)
                query = query.Where(q => q.IsOrdered == filter.IsOrdered.Value);

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<ProductItem, ProductItemListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<ProductItemListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<ProductItem, ProductItemListDto, long>>(ResponseResult.Success,pageDto);
        }



        public async Task<ServiceResponse<Empty>> Create(CreateProductItemDto create)
        {
            ProductItem? ProductItem = new();

            ProductItem = await _ProductItemRepository.GetQueryable()
                .AsTracking()
                .Include(a => a.Product)
                .FirstOrDefaultAsync(a => a.ProductId == create.ProductId && a.CartId == create.CartId);
            if (ProductItem != null)
            {
                ProductItem.Count += create.Count;
                if (ProductItem.Count > ProductItem.Product.Stock)
                {
                    ProductItem.Count = ProductItem.Product.Stock; ;
                }
                ProductItem.IsOrdered = false;
                await _ProductItemRepository.Update(ProductItem, _AppUserProvider.User.Id);
            }
            else
            {
                ProductItem = _Mapper.Map<ProductItem>(create);
                ProductItem.IsOrdered = false;
                await _ProductItemRepository.Add(ProductItem, _AppUserProvider.User.Id);


            }

            #region update Cart

            var Cart = await _CartRepository.GetQueryable()
                .Include(a => a.ProductItems)
                .AsTracking()
                .FirstAsync(a => a.Id == create.CartId);
            Cart.TotalPrice = 0;
            foreach (var coP in Cart.ProductItems)
            {
                Cart.TotalPrice += coP.UpdatedPrice == null ? coP.Price : coP.UpdatedPrice.Value;
            }
            await _CartRepository.Update(Cart, _AppUserProvider.User.Id);

            #endregion

            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateProductItemDto update)
        {
            ProductItem? ProductItem = await _ProductItemRepository.GetAsTracking(update.Id);

            if (ProductItem == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            if (update.OrderId != null && update.CartId == null)
            {
                update.IsOrdered = true;
            }
            else if (update.CartId != null && update.OrderId == null)
            {
                update.IsOrdered = false;
            }
            else
            {
                throw new Exception("Change ProductItem Cart And Order State Exception");
            }
            await _ProductItemRepository.Update(_Mapper.Map<ProductItem>(update), _AppUserProvider.User.Id);


            #region update Cart

            var Cart = await _CartRepository.GetQueryable()
               .Include(a => a.ProductItems)
               .AsTracking()
               .FirstAsync(a => a.Id == update.CartId);
            Cart.TotalPrice = 0;
            foreach (var coP in Cart.ProductItems)
            {
                Cart.TotalPrice += coP.UpdatedPrice == null ? coP.Price : coP.UpdatedPrice.Value;
            }
            await _CartRepository.Update(Cart, _AppUserProvider.User.Id);

            #endregion


            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(long id)
        {

            ProductItem? ProductItem = await _ProductItemRepository.GetAsTracking(id);

            if (ProductItem == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            ProductItem.CartId = null;

            await _ProductItemRepository.SoftDelete(ProductItem, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }
    }
}
