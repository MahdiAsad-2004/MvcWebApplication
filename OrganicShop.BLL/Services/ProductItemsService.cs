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
using OrganicShop.Domain.Entities.Base;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Enums.EnumValues;
using Microsoft.AspNetCore.Http.HttpResults;

namespace OrganicShop.BLL.Services
{
    public class ProductItemService : Service<ProductItem>, IProductItemService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IProductItemRepository _ProductItemRepository;
        private readonly ICartRepository _CartRepository;
        private readonly IProductRepository _ProductRepository;

        public ProductItemService(IApplicationUserProvider provider, IMapper mapper, IProductItemRepository ProductItemRepository, ICartRepository CartRepository, IProductRepository productRepository)
            : base(provider)
        {
            _Mapper = mapper;
            _ProductItemRepository = ProductItemRepository;
            _CartRepository = CartRepository;
            _ProductRepository = productRepository;
        }

        #endregion


        public async Task<ServiceResponse<List<ProductItemListDto>>> GetAll(FilterProductItemDto? filter = null)
        {
            var query = _ProductItemRepository.GetQueryable();

            #region includes 

            query = query
                .Include(a => a.Product)
                    .ThenInclude(a => a.Pictures)
                .Include(a => a.Product)
                    .ThenInclude(a => a.Categories)
                .Include(a => a.Product)
                    .ThenInclude(a => a.DiscountProducts)
                        .ThenInclude(a => a.Discount)
                .Include(a => a.Product)
                    .ThenInclude(a => a.ProductVarients)
                .Select(a => new ProductItem
                {
                    Order = a.Order,
                    BaseEntity = a.BaseEntity,
                    IsOrdered = a.IsOrdered,
                    Id = a.Id,
                    Count = a.Count,
                    Cart = a.Cart,
                    CartId = a.CartId,
                    OrderId = a.OrderId,
                    Price = a.Price,
                    Product = a.Product.ToModel(),
                    ProductId = a.ProductId,
                    ProductVarientId = a.ProductVarientId,
                    Title = a.Title,
                })
                .AsQueryable();

            #endregion

            if (filter == null) filter = new FilterProductItemDto();

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

            var productsQuery = query.Select(a => a.Product.ToModel());

            List<ProductItemListDto> list = new();
            list = await query.Select(a => _Mapper.Map<ProductItemListDto>(a)).ToListAsync();

            return new ServiceResponse<List<ProductItemListDto>>(ResponseResult.Success, list);
        }



        public async Task<ServiceResponse<Empty>> Create(CreateProductItemDto create)
        {
            ProductItem? ProductItem = new();

            long? userCartId = _CartRepository.GetQueryable()
                .FirstOrDefaultAsync(a => a.UserId.Equals(_AppUserProvider.User.Id)).Result?.UserId;

            if (userCartId == null)
            {
                ProductItem = await _ProductItemRepository.GetQueryable()
                .AsTracking()
                .Include(a => a.Product)
                .FirstOrDefaultAsync(a => a.ProductId == create.ProductId && a.CartId == userCartId);
            }

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

            //var Cart = await _CartRepository.GetQueryable()
            //    .Include(a => a.ProductItems)
            //    .AsTracking()
            //    .FirstAsync(a => a.Id == create.CartId);
            //Cart.TotalPrice = 0;
            //foreach (var coP in Cart.ProductItems)
            //{
            //    Cart.TotalPrice += coP.UpdatedPrice == null ? coP.Price : coP.UpdatedPrice.Value;
            //}
            //await _CartRepository.Update(Cart, _AppUserProvider.User.Id);

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



        public async Task<ServiceResponse<List<ProductItemListDto>>> GetAll(List<ProductItemCookieDto> productItemCookieDtos)
        {
            var productIds = productItemCookieDtos.Select(a => a.ProductId);
            var productsQuery = _ProductRepository.GetQueryable();

            #region includes

            productsQuery = productsQuery
              .Include(a => a.Pictures)
              .Include(a => a.Categories)
              .Include(a => a.DiscountProducts)
                  .ThenInclude(a => a.Discount)
              .Include(a => a.ProductVarients);

            #endregion

            var products = await productsQuery
                .Where(a => productIds.Contains(a.Id))
                .Select(a => a.ToModel())
                .ToArrayAsync();

            var list = new List<ProductItemListDto>();
            Product product;

            foreach (var create in productItemCookieDtos)
            {
                product = products.First(a => a.Id == create.ProductId);
                list.Add(new ProductItemListDto
                {
                    Title = product.Title,
                    Count = create.Count,
                    Price = product.Price,
                    ProductId = product.Id,
                    DiscountedPrice = product.DiscountedPrice,
                    Stock = product.Stock,
                    MainImageName = product.Pictures.GetMainPictureName() ?? PathExtensions.ProductDefaultImage,
                    VarientType = create.ProductVarientId > 0 ? product.ProductVarients.First(a => a.Id == create.ProductVarientId).Type.ToStringValue() : null,
                    VarientValue = create.ProductVarientId > 0 ? product.ProductVarients.First(a => a.Id == create.ProductVarientId).Value : null,
                });
            }
            return new ServiceResponse<List<ProductItemListDto>>(ResponseResult.Success, list);
        }




        public async Task<ServiceResponse<List<ProductItemCookieDto>>> CreateForCookie(CreateProductItemDto create, List<ProductItemCookieDto> previousProductItems)
        {
            var productStock = 0;

            if (create.ProductVarientId > 0)
            {
                productStock = _ProductRepository.GetQueryable()
                .Include(a => a.ProductVarients)
                .FirstAsync(a => a.Id == create.ProductId).Result.ProductVarients
                .First(a => a.Id == create.ProductVarientId).Stock;
            }
            else
            {
                productStock = _ProductRepository.GetQueryable()
                .FirstAsync(a => a.Id == create.ProductId).Result.Stock;
            }

            var previousProductItem = previousProductItems.FirstOrDefault(a => a.ProductId == create.ProductId);

            if (previousProductItem == null)
            {
                if (create.Count > productStock)
                {
                    create.Count = productStock;
                }
                previousProductItems.Add(_Mapper.Map<ProductItemCookieDto>(create));
            }
            else
            {
                previousProductItem.Count += create.Count;
                if (previousProductItem.Count > productStock)
                {
                    previousProductItem.Count = productStock;
                }
            }

            return new ServiceResponse<List<ProductItemCookieDto>>(ResponseResult.Success, previousProductItems);
        }






        public async Task<ServiceResponse<List<ProductItemCookieDto>>> UpdateForCookie(long productItemId , int count, List<ProductItemCookieDto> previousProductItems)
        {
            var productItem = previousProductItems.FirstOrDefault(a => a.Id == productItemId);
            
            if (productItem == null)
                return new ServiceResponse<List<ProductItemCookieDto>>(ResponseResult.NotFound, _Message.NotFound());
            var productStock = 0;

            if (productItem.ProductVarientId > 0)
            {
                productStock = _ProductRepository.GetQueryable()
                    .Include(a => a.ProductVarients)
                    .FirstAsync(a => a.Id == productItem.ProductId).Result.ProductVarients
                    .First(a => a.Id == productItem.ProductVarientId).Stock;
            }
            else
            {
                productStock = _ProductRepository.GetQueryable()
                    .FirstAsync(a => a.Id == productItem.ProductId).Result.Stock;
            }
            productItem.Count += count;
            if(productItem.Count > productStock)
            {
                productItem.Count = productStock;
            }

            return new ServiceResponse<List<ProductItemCookieDto>>(ResponseResult.Success, _Message.SuccessUpdate(), previousProductItems);
        }


    }
}
