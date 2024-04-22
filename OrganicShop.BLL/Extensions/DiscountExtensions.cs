﻿using Microsoft.Identity.Client;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.BLL.Extensions
{
    public static class DiscountExtensions
    {
        public static int GetDiscountedPrice(this Discount discount, int price)
        {
            if (discount.IsFixDiscount)
            {
                if (discount.FixValue != null)
                    return price - discount.FixValue.Value;
                throw new Exception("Discount is not valid .");
            }
            else
            {
                if (discount.Percent != null)
                    return price - (price * discount.Percent.Value / 100);
                throw new Exception("Discount is not valid .");
            }
        }


        public static int? GetDefaultDiscountedPrice(this Product product)
        {
            Discount? discount;
            discount = product.DiscountProducts.Select(a => a.Discount).OrderByDescending(a => a.BaseEntity.LastModified)
                .FirstOrDefault(a => a.IsDefault == true);

            if (discount != null)
                return discount.GetDiscountedPrice(product.Price);

            discount = product.Category.DiscountCategories.Select(a => a.Discount).OrderByDescending(a => a.BaseEntity.LastModified)
                .FirstOrDefault(a => a.IsDefault == true);

            if (discount != null)
                return discount.GetDiscountedPrice(product.Price);

            return null;
        }

        public static Discount? GetDefaultDiscount(this Product product)
        {
            Discount? discount;
            discount = product.DiscountProducts.Select(a => a.Discount).OrderByDescending(a => a.BaseEntity.LastModified)
                .FirstOrDefault(a => a.IsDefault == true);

            if (discount != null)
                return discount;

            discount = product.Category.DiscountCategories.Select(a => a.Discount).OrderByDescending(a => a.BaseEntity.LastModified)
                .FirstOrDefault(a => a.IsDefault == true);

            if (discount != null)
                return discount;

            return null;
        }


        public static int? GetDefaultDiscountedPriceProduct(this Product product)
        {
            Discount? discount;
            discount = product.DiscountProducts.Select(a => a.Discount).OrderByDescending(a => a.BaseEntity.LastModified)
                .FirstOrDefault(a => a.IsDefault == true);

            if (discount != null)
                return discount.GetDiscountedPrice(product.Price);

            return null;
        }

        public static Discount? GetDefaultDiscountProduct(this Product product)
        {
            Discount? discount;
            discount = product.DiscountProducts.Select(a => a.Discount).OrderByDescending(a => a.BaseEntity.LastModified)
                .FirstOrDefault(a => a.IsDefault == true);

            if (discount != null)
                return discount;

            return null;
        }

    }
}
