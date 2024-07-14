using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Extensions;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.ProductDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.DiscountDtos;
using FluentValidation;

namespace OrganicShop.BLL.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IProductRepository _ProductRepository;
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IPropertyRepository _PropertyRepository;
        private readonly IDiscountRepository _DiscountRepository;
        private readonly IValidator<CreateProductDto> _ValidatorCreateProduct;
        private readonly IValidator<UpdateProductDto> _ValidatorUpdateProduct;

        public ProductService(IApplicationUserProvider provider, IMapper mapper, IProductRepository ProductRepository, ICategoryRepository categoryRepository,
            IPropertyRepository propertyRepository, IDiscountRepository discountRepository, IValidator<CreateProductDto> validatorCreateProduct,
            IValidator<UpdateProductDto> validatorUpdateProduct) : base(provider)
        {
            _Mapper = mapper;
            _ProductRepository = ProductRepository;
            _CategoryRepository = categoryRepository;
            _PropertyRepository = propertyRepository;
            _DiscountRepository = discountRepository;
            _ValidatorCreateProduct = validatorCreateProduct;
            _ValidatorUpdateProduct = validatorUpdateProduct;
        }

        #endregion

        private IQueryable<Product> FilterAndSort(IQueryable<Product> query, FilterProductDto? filter = null, PagingDto? paging = null)
        {
            if (filter == null) filter = new FilterProductDto();
            if (paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Id != null)
                query = query.Where(q => q.Id == filter.Id);

            if (filter.Ids != null)
                query = query.Where(a => filter.Ids.Contains(a.Id));

            if (filter.Title != null)
                query = query.Where(q => EF.Functions.Like(q.Title, $"%{filter.Title}%"));

            if (filter.MaxPrice != null)
                query = query.Where(q => q.Price <= filter.MaxPrice);

            if (filter.MinPrice != null)
                query = query.Where(q => q.Price >= filter.MinPrice);

            if (filter.CategoryId != null)
            {
                query = query.Where(q => q.Categories.Any(a => a.Id.Equals(filter.CategoryId)));
                //query = query.Where(q => q.CategoryId.Equals(filter.CategoryId));
            }

            if (filter.CategoryIds != null)
            {
                query = query.Where(q => q.Categories.Any(a => filter.CategoryIds.Contains(a.Id)));
                //query = query.Where(q => filter.CategoryIds.Contains(q.CategoryId));
            }

            if (filter.Rate != null)
            {
                query = query.Where(q =>
                ((float)q.Comments.Sum(b => b.Rate) / q.Comments.Count == 0 ? int.MaxValue : q.Comments.Count) >= filter.Rate &&
                   ((float)q.Comments.Sum(b => b.Rate) / q.Comments.Count == 0 ? int.MaxValue : q.Comments.Count) < filter.Rate + 1);
            }

            //query = query.Where(q => q)




            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            return query;
        }


        public async Task<ServiceResponse<PageDto<Product, ProductListDto, long>>> GetAll(FilterProductDto? filter = null, PagingDto? paging = null)
        {
            var query = _ProductRepository.GetQueryable()
                .Include(a => a.Pictures)
                .Include(a => a.Categories)
                .AsQueryable();

            if (filter == null) filter = new FilterProductDto();
            if (paging == null) paging = new PagingDto();

            query = FilterAndSort(query, filter, paging);

            PageDto<Product, ProductListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<ProductListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Product, ProductListDto, long>>(ResponseResult.Success, pageDto);
        }



        public async Task<ServiceResponse<PageDto<Product, ProductSummaryDto, long>>> GetAllSummary(FilterProductDto? filter = null, PagingDto? paging = null)
        {
            var query = _ProductRepository.GetQueryable();

            #region includes

            var x = query
                .Include(a => a.Pictures)
                .Include(a => a.Categories)
                .Include(a => a.DiscountProducts)
                    .ThenInclude(a => a.Discount)
                .Include(a => a.Comments)
                .Include(a => a.Properties)
                 .ThenInclude(a => a.PropertyType)
                .Include(a => a.ProductVarients)
                .Select(a => a.ToModel())
                .AsParallel();

            query = x
                .AsQueryable();

            #endregion

            if (filter == null) filter = new FilterProductDto();
            if (paging == null) paging = new PagingDto();

            query = FilterAndSort(query, filter, paging);

            PageDto<Product, ProductSummaryDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<ProductSummaryDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Product, ProductSummaryDto, long>>(ResponseResult.Success, pageDto);
        }



        public async Task<ServiceResponse<UpdateProductDto>> Get(long Id)
        {
            if (Id < 1)
                return new ServiceResponse<UpdateProductDto>(ResponseResult.NotFound, null);

            var product = await _ProductRepository.GetQueryableTracking()
                .Include(a => a.TagProducts)
                .Include(a => a.Properties)
                .Include(a => a.Pictures)
                .Include(a => a.Categories)
                .Include(a => a.DiscountProducts)
                    .ThenInclude(a => a.Discount)
                .FirstOrDefaultAsync(a => a.Id.Equals(Id));

            if (product != null)
                return new ServiceResponse<UpdateProductDto>(ResponseResult.Success, _Mapper.Map<UpdateProductDto>(product));

            return new ServiceResponse<UpdateProductDto>(ResponseResult.NotFound, null);
        }



        public async Task<ServiceResponse<ProductDetailDto>> GetDetail(long? id = null, string? barcode = null, string? title = null)
        {
            if (id == null && barcode == null && title == null)
                throw new ArgumentNullException("Id and barcode and title are null in ProductService => GetDetail()");

            #region includes

            var query = _ProductRepository.GetQueryable()
                .Include(a => a.Pictures)
                .Include(a => a.Categories)
                .Include(a => a.DiscountProducts)
                    .ThenInclude(a => a.Discount)
                .Include(a => a.Comments.Where(b => b.Status == CommentStatus.Accepted))
                    .ThenInclude(a => a.User)
                .Include(a => a.Properties)
                    .ThenInclude(a => a.PropertyType)
                .Include(a => a.ProductVarients)
                .Include(a => a.Seller)
                    .ThenInclude(a => a.Address)
                .Include(a => a.Seller)
                    .ThenInclude(a => a.Picture)
                .Include(a => a.Seller)
                    .ThenInclude(a => a.Comments.Where(b => b.Status == CommentStatus.Accepted))
                .AsQueryable();

            #endregion

            Product? product = null;

            if (id != null && id > 1)
            {
                product = await query.FirstOrDefaultAsync(a => a.Id.Equals(id));
            }
            else if (string.IsNullOrWhiteSpace(barcode) == false)
            {
                product = await query.FirstOrDefaultAsync(a => a.Barcode == barcode);
            }
            else if (string.IsNullOrWhiteSpace(title) == false)
            {
                product = await query.FirstOrDefaultAsync(a => a.Title == title);
            }

            if (product == null)
                return new ServiceResponse<ProductDetailDto>(ResponseResult.NotFound, null);

            return new ServiceResponse<ProductDetailDto>(ResponseResult.Success, _Mapper.Map<ProductDetailDto>(product.ToModel()));
        }





        public async Task<ServiceResponse<Empty>> Create(CreateProductDto create)
        {
            var validationResult = await _ValidatorCreateProduct.ValidateAsync(create);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(create, validationResult);

            Product Product = _Mapper.Map<Product>(create);

            #region discounts

            if (create.UpdatedPrice < create.Price)
            {
                var discount = new Discount
                {
                    Title = "WhenCreateProduct",
                    Price = create.Price - create.UpdatedPrice,
                    BaseEntity = new BaseEntity(true),
                };

                if (create.DiscountCount > 0)
                    discount.Count = create.DiscountCount;

                Product.DiscountProducts = new List<DiscountProducts> { new DiscountProducts
                    {
                        Discount = discount,
                        Product = Product,
                        BaseEntity = new BaseEntity(true),
                    }
                };
            }

            #endregion

            #region pictures

            var pictures = new List<Picture>();
            var pictureMain = await create.MainImageFile.SavePictureAsync(PathKey.ProductImages, PictureType.Product);
            pictureMain.IsMain = true;
            pictures.Add(pictureMain);
            if (create.PictureFiles != null)
            {
                foreach (var pictureFile in create.PictureFiles)
                {
                    pictures.Add(await pictureFile.SavePictureAsync(PathKey.ProductImages, PictureType.Product));
                }
            }
            Product.Pictures = pictures;

            #endregion

            #region tags

            if (create.TagIds != null)
            {
                var tagProducts = new List<TagProducts>();
                foreach (var tagId in create.TagIds)
                {
                    tagProducts.Add(new TagProducts
                    {
                        TagId = tagId,
                        BaseEntity = new BaseEntity(true),
                    });
                }
                Product.TagProducts = tagProducts;
            }

            #endregion

            #region properties

            if (create.PropertiesDictionary != null)
            {
                Property? property = null;
                var properties = new List<Property>();
                foreach (var propertyDic in create.PropertiesDictionary)
                {
                    property = await _PropertyRepository.GetAsNoTracking(propertyDic.Key);
                    if (property == null)
                        return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.NotFound(typeof(Property)));

                    properties.Add(new Property
                    {
                        //Title = property.Title,
                        //Priority = property.Priority,
                        Value = propertyDic.Value,
                        //IsBase = false,
                        //BaseId = propertyDic.Key,
                        TypeId = 1,
                        BaseEntity = new BaseEntity(true),
                    });
                }
                Product.Properties = properties;
            }

            #endregion

            #region categories

            var category = await _CategoryRepository.GetQueryable().Include(a => a.Parent).FirstOrDefaultAsync(a => a.Id == create.CategoryId);
            if (category == null)
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.NotFound(typeof(Category)));
            Product.Categories = category.GetWithAllParents().OrderBy(a => a.Id).ToList();

            #endregion

            Product.Barcode = TextExtensions.GenerateProductBarcode();

            await _ProductRepository.Add(Product, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateProductDto update)
        {
            var validationResult = await _ValidatorUpdateProduct.ValidateAsync(update);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(update, validationResult);

            Product? Product = await _ProductRepository.GetQueryableTracking()
                .Include(a => a.TagProducts)
                .Include(a => a.Properties)
                .Include(a => a.Pictures)
                .Include(a => a.Categories)
                .Include(a => a.DiscountProducts)
                    .ThenInclude(a => a.Discount)
                .FirstOrDefaultAsync(a => a.Id.Equals(update.Id));

            if (Product == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            #region discounts

            Discount discount;
            DiscountProducts discountProduct;
            if (update.DiscountId > 0)
            {
                discountProduct = Product.DiscountProducts.First(a => a.DiscountId == update.DiscountId);
                if (update.UpdatedPrice < update.Price)
                {
                    discountProduct.Discount.Price = update.UpdatedPrice;
                    discountProduct.Discount.BaseEntity.LastModified = DateTime.Now;
                    if (update.DiscountCount > 0)
                        discountProduct.Discount.Count = update.DiscountCount;
                }
                else
                {
                    Product.DiscountProducts.Remove(discountProduct);
                }

            }
            else
            {
                if (update.UpdatedPrice < update.Price)
                {
                    discount = new Discount
                    {
                        Title = "Basic",
                        Price = update.Price - update.UpdatedPrice,
                        BaseEntity = new BaseEntity(true),
                    };
                    discountProduct = new DiscountProducts
                    {
                        Discount = discount,
                        Product = Product,
                        BaseEntity = new BaseEntity(true),
                    };
                    Product.DiscountProducts.Add(discountProduct);
                }
            }


            #endregion

            #region pictures

            if (update.MainPictureFile != null)
            {
                Product.Pictures.First(a => a.IsMain).BaseEntity.IsDelete = true;
                var mainPicture = await update.MainPictureFile.SavePictureAsync(PathKey.ProductImages, PictureType.Product);
                mainPicture.IsMain = true;
                Product.Pictures.Add(mainPicture);
            }

            if (update.OldPicturesDic == null)
            {
                foreach (var picture in Product.Pictures.Where(a => a.IsMain == false))
                {
                    picture.BaseEntity.IsDelete = true;
                }
            }
            else
            {
                foreach (var picture in Product.Pictures.Where(a => a.IsMain == false).ExceptBy(update.OldPicturesDic.Keys, a => a.Id))
                {
                    picture.BaseEntity.IsDelete = true;
                }
            }

            if (update.NewPictureFiles != null)
            {
                foreach (var file in update.NewPictureFiles)
                {
                    Product.Pictures.Add(await file.SavePictureAsync(PathKey.ProductImages, PictureType.Product));
                }
            }

            #endregion

            #region tags

            if (update.TagIds != null)
            {
                foreach (var tagId in update.TagIds.ExceptBy(Product.TagProducts.Select(a => a.TagId), a => a))
                {
                    Product.TagProducts.Add(new TagProducts
                    {
                        ProductId = update.Id,
                        TagId = tagId,
                        BaseEntity = new BaseEntity(true),
                    });
                }
                foreach (var tag in Product.TagProducts.ExceptBy(update.TagIds, a => a.TagId))
                {
                    Product.TagProducts.Remove(tag);
                }
            }

            #endregion

            #region properties

            //if (update.PropertiesDic != null)
            //{
            //    Property? baseProperty = null;
            //    foreach (var propperty in Product.Properties.ExceptBy(update.PropertiesDic.Select(a => a.Value.Id), a => a.Id))
            //    {
            //        propperty.BaseEntity.IsDelete = true;
            //        //Product.Properties.Remove(propperty);
            //    }

            //    foreach (var propperty in Product.Properties.IntersectBy(update.PropertiesDic.Select(a => a.Value.Id), a => a.Id))
            //    {
            //        propperty.Value = update.PropertiesDic[propperty.BaseId.Value].Value;
            //        propperty.BaseEntity.LastModified = DateTime.Now;
            //    }

            //    foreach (var propertyDic in update.PropertiesDic.Where(a => a.Value.Id <= 0))
            //    {
            //        baseProperty = await _PropertyRepository.GetAsNoTracking(propertyDic.Key);
            //        if (baseProperty == null)
            //            return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.NotFound(typeof(Property)));

            //        Product.Properties.Add(new Property
            //        {
            //            ProductId = update.Id,
            //            Title = baseProperty.Title,
            //            Priority = baseProperty.Priority,
            //            Value = propertyDic.Value.Value,
            //            IsBase = false,
            //            BaseId = baseProperty.Id,
            //            BaseEntity = new BaseEntity(true),
            //        });
            //    }


            //}

            #endregion

            #region categories

            if (Product.Categories.Last().Id != update.CategoryId)
            {
                var category = await _CategoryRepository.GetQueryable().Include(a => a.Parent).FirstOrDefaultAsync(a => a.Id == update.CategoryId);
                if (category == null)
                    return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.NotFound(typeof(Category)));
                Product.Categories.Clear();
                Product.Categories = category.GetWithAllParents().OrderBy(a => a.Id).ToList();
            }

            #endregion

            await _ProductRepository.Update(_Mapper.Map(update, Product), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }




        public async Task<ServiceResponse<Empty>> Delete(long delete)
        {
            Product? Product = await _ProductRepository.GetAsTracking(delete);

            if (Product == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _ProductRepository.SoftDelete(Product, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }



        public async Task<ServiceResponse<List<ComboDto<Product>>>> GetCombos()
        {
            var comboDtos = _ProductRepository
              .GetQueryable()
              .Select(a => _Mapper.Map<ComboDto<Product>>(a))
              .ToList();
            return new ServiceResponse<List<ComboDto<Product>>>(ResponseResult.Success, comboDtos);
        }



        public async Task<ServiceResponse<List<ComboDto<Product>>>> GetCombos(long[] productIds)
        {
            var comboDtos = _ProductRepository
              .GetQueryable()
              .Where(a => productIds.Contains(a.Id))
              .Select(a => _Mapper.Map<ComboDto<Product>>(a))
              .ToList();
            return new ServiceResponse<List<ComboDto<Product>>>(ResponseResult.Success, comboDtos);
        }



        public async Task<ServiceResponse<List<ProductSummaryDto>>> HotDiscountProducts()
        {
            var discounts = _DiscountRepository.GetQueryable()
                .Include(a => a.DiscountProducts).ThenInclude(a => a.Product).ThenInclude(a => a.Pictures)
                .Include(a => a.DiscountProducts).ThenInclude(a => a.Product).ThenInclude(a => a.Categories)
                .Include(a => a.DiscountProducts).ThenInclude(a => a.Product).ThenInclude(a => a.Comments)
                .Include(a => a.DiscountProducts).ThenInclude(a => a.Product).ThenInclude(a => a.Properties)
                .Include(a => a.DiscountProducts).ThenInclude(a => a.Product).ThenInclude(a => a.TagProducts)
                .Where(a => a.Count! < 0);

            var products1 = discounts.AsEnumerable().Where(a => a.IsDiscountValid()).SelectMany(a => a.DiscountProducts).Select(a => a.Product).ToArray();

            if (products1 == null)
            {
                return new ServiceResponse<List<ProductSummaryDto>>(ResponseResult.Success, _Mapper.Map<List<ProductSummaryDto>>(products1.ToList()));
            }
            return new ServiceResponse<List<ProductSummaryDto>>(ResponseResult.Success, _Mapper.Map<List<ProductSummaryDto>>(products1.ToList()));

            //return new ServiceResponse<List<ProductSummaryDto>>(ResponseResult.Success,  new List<ProductSummaryDto>());
            //var products = products1.Union(products2);
        }

    }
}
