﻿using OrganicShop.Domain.Enums.SortTypes;
using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Domain.Enums.EnumValues
{
    public static class EnumValue
    {
        public static string ToStringValue(this CategoryType categoryType)
        {
            switch (categoryType)
            {
                case CategoryType.All:
                    return "سایت";

                case CategoryType.Product:
                    return "محصولات";

                case CategoryType.Article:
                    return "مطالب";

                default:
                    throw new Exception("Enum value not found");
            }
        }
        public static string ToStringValue(this Gender gender)
        {
            switch (gender)
            {
                case Gender.Man:
                    return "مرد";

                case Gender.Woman:
                    return "زن";

                default:
                    throw new Exception("Enum value not found");
            }
        }

        public static string ToStringValue(this CommentStatus commentStatus)
        {
            switch (commentStatus)
            {
                case CommentStatus.Unread:
                    return "بررسی نشده";

                case CommentStatus.NotAccepted:
                    return "رد شده";

                case CommentStatus.Accepted:
                    return "تایید شده";

                default:
                    throw new Exception("Enum value not found");
            }


        }

        public static string ToStringValue(this IsActiveFilter activeFilter)
        {
            switch (activeFilter)
            {
                case IsActiveFilter.All:
                    return "همه";

                case IsActiveFilter.Active:
                    return "فعال";

                case IsActiveFilter.NotActive:
                    return "غیر فعال";

                default:
                    throw new Exception("Enum value not found");
            }
        }

        public static string ToStringValue(this Role role)
        {
            switch (role)
            {
                case Role.Manager:
                    return "مدیر";

                case Role.Admin:
                    return "ادمین";

                case Role.Customer:
                    return "مشتری";
                default:
                    throw new Exception("Enum value not found");

            }
        }

        public static string ToStringValue(this BaseSortType sortType)
        {
            switch (sortType)
            {
                case BaseSortType.None:
                    return " بدون مرتب سازی ";

                case BaseSortType.Newest:
                    return "جدیدترین";

                case BaseSortType.LatestChange:
                    return "آخرین تغییر";

                case BaseSortType.Oldest:
                    return "قدیمی ترین";

                default:
                    throw new Exception("Enum value not found");
            }
        }

        public static string ToStringValue(this CartSortType sortType)
        {
            switch (sortType)
            {
                case CartSortType.None:
                    return " بدون مرتب سازی ";

                case CartSortType.Newest:
                    return "جدیدترین";

                case CartSortType.LatestChange:
                    return "آخرین تغییر";

                case CartSortType.Oldest:
                    return "قدیمی ترین";

                case CartSortType.TotalPrice:
                    return "ارزش کمترین";

                case CartSortType.TotalPriceDesc:
                    return "ارزش بیشترین";

                default:
                    throw new Exception("Enum value not found");
            }
        }

        public static string ToStringValue(this CategorySortType sortType)
        {
            switch (sortType)
            {
                case CategorySortType.None:
                    return " بدون مرتب سازی ";

                case CategorySortType.Newest:
                    return "جدیدترین";

                case CategorySortType.LatestChange:
                    return "آخرین تغییر";

                case CategorySortType.Oldest:
                    return "قدیمی ترین";

                case CategorySortType.Title:
                    return "عنوان صعودی";

                case CategorySortType.TitleDesc:
                    return "عنوان نزولی";

                default:
                    throw new Exception("Enum value not found");
            }
        }


        public static string ToStringValue(this CommentSortType sortType)
        {
            switch (sortType)
            {
                case CommentSortType.None:
                    return " بدون مرتب سازی ";

                case CommentSortType.Newest:
                    return "جدیدترین";

                case CommentSortType.LatestChange:
                    return "آخرین تغییر";

                case CommentSortType.Oldest:
                    return "قدیمی ترین";

                case CommentSortType.Rate:
                    return "امتیاز کمترین";

                case CommentSortType.RateDesc:
                    return "امتیاز بیشترین";

                default:
                    throw new Exception("Enum value not found");
            }
        }


        public static string ToStringValue(this ProductItemSortType sortType)
        {
            switch (sortType)
            {
                case ProductItemSortType.None:
                    return " بدون مرتب سازی ";

                case ProductItemSortType.Newest:
                    return "جدیدترین";

                case ProductItemSortType.LatestChange:
                    return "آخرین تغییر";

                case ProductItemSortType.Oldest:
                    return "قدیمی ترین";

                case ProductItemSortType.PurchasedPrice:
                    return "قیمت کمترین";

                case ProductItemSortType.PurchasedPriceDesc:
                    return "قیمت بیشترین";

                case ProductItemSortType.Count:
                    return "تعداد کمترین";

                case ProductItemSortType.CountDesc:
                    return "تعداد بیشترین";

                default:
                    throw new Exception("Enum value not found");
            }
        }


        public static string ToStringValue(this DiscountSortType sortType)
        {
            switch (sortType)
            {
                case DiscountSortType.None:
                    return " بدون مرتب سازی ";

                case DiscountSortType.Newest:
                    return "جدیدترین";

                case DiscountSortType.LatestChange:
                    return "آخرین تغییر";

                case DiscountSortType.Oldest:
                    return "قدیمی ترین";

                case DiscountSortType.Percent:
                    return "درصد کمترین";

                case DiscountSortType.PercentDesc:
                    return "درصد بیشترین";

                case DiscountSortType.FixedValue:
                    return "مقدار ثابت کمترین";

                case DiscountSortType.FixedValueDesc:
                    return "مقدار ثابت بیشترین";

                case DiscountSortType.Count:
                    return "تعداد کمترین";

                case DiscountSortType.CountDesc:
                    return "تعداد بیشترین";

                default:
                    throw new Exception("Enum value not found");
            }
        }


        public static string ToStringValue(this DoneStatus doneStatus)
        {
            switch (doneStatus)
            {
                case DoneStatus.Done:
                    return "انجام شد";

                case DoneStatus.Doing:
                    return "در حال انجام";

                case DoneStatus.Waiting:
                    return "در انتظار";

                default:
                    throw new Exception("Enum value not found");
            }
        }


        public static string ToStringValue(this PaymentMethod paymentMethod)
        {
            switch (paymentMethod)
            {
                case PaymentMethod.Cash:
                    return "پرداخت نقد";

                case PaymentMethod.PaymentGeteway:
                    return "درگاه پرداخت";

                case PaymentMethod.Wallet:
                    return "کیف پول";

                case PaymentMethod.CartToCart:
                    return "کارت به کارت";

                default:
                    throw new Exception("Enum value not found");
            }
        }


        public static string ToStringValue(this PermissionSortType sortType)
        {
            switch (sortType)
            {
                case PermissionSortType.None:
                    return " بدون مرتب سازی ";

                case PermissionSortType.Newest:
                    return "جدیدترین";

                case PermissionSortType.LatestChange:
                    return "آخرین تغییر";

                case PermissionSortType.Oldest:
                    return "قدیمی ترین";

                case PermissionSortType.Title:
                    return "عنوان کمترین";

                case PermissionSortType.TitleDesc:
                    return "عنوان بیشترین";

                case PermissionSortType.EnTitle:
                    return "عنوان انگلیسی کمترین";

                case PermissionSortType.EnTitleDesc:
                    return "عنوان انگلیسی بیشترین";

                default:
                    throw new Exception("Enum value not found");
            }
        }


        public static string ToStringValue(this PictureSortType sortType)
        {
            switch (sortType)
            {
                case PictureSortType.None:
                    return " بدون مرتب سازی ";

                case PictureSortType.Newest:
                    return "جدیدترین";

                case PictureSortType.LatestChange:
                    return "آخرین تغییر";

                case PictureSortType.Oldest:
                    return "قدیمی ترین";

                case PictureSortType.Size:
                    return "حجم کمترین";

                case PictureSortType.SizeDesc:
                    return "حجم بیشترین";

                default:
                    throw new Exception("Enum value not found");
            }
        }


        public static string ToStringValue(this ProductSortType sortType)
        {
            switch (sortType)
            {
                case ProductSortType.None:
                    return " بدون مرتب سازی ";

                case ProductSortType.Newest:
                    return "جدیدترین";

                case ProductSortType.LatestChange:
                    return "آخرین تغییر";

                case ProductSortType.Oldest:
                    return "قدیمی ترین";

                case ProductSortType.Price:
                    return "قیمت کمترین";

                case ProductSortType.PriceDesc:
                    return "قیمت بیشترین";

                case ProductSortType.Title:
                    return "عنوان صعودی";

                case ProductSortType.TitleDesc:
                    return "عنوان نزولی";

                case ProductSortType.SoldCount:
                    return "فروش کمترین";

                case ProductSortType.SoldCountDesc:
                    return "فروش بیشترین";

                case ProductSortType.Stock:
                    return "موجودی کمترین";

                case ProductSortType.StockDesc:
                    return "موجودی بیشترین";

                case ProductSortType.Discount:
                    return "تخفیف کمترین";

                case ProductSortType.DiscountDesc:
                    return "تخفیف بیشترین";

                case ProductSortType.Rate:
                    return "امتیاز بیشترین";

                case ProductSortType.RateDesc:
                    return "امتیاز بیشترین";

                default:
                    throw new Exception("Enum value not found");
            }
        }


        public static string ToStringValue(this OrderStep orderStep)
        {
            switch (orderStep)
            {
                case OrderStep.Processing:
                    return "پردازش";

                case OrderStep.Packing:
                    return "بسته بندی";

                case OrderStep.DeliveredToPost:
                    return "تحویل به شرکت حمل و نقل";

                case OrderStep.Transporting:
                    return "ارسال محصول";

                case OrderStep.DeliveredToCustomer:
                    return "تحویل مشتری";

                default:
                    throw new Exception("Enum value not found");
            }
        }
        
        public static string ToStringValue(this OrderStatus orderStatus)
        {
            switch (orderStatus)
            {
                case OrderStatus.Success:
                    return "موفق";

                case OrderStatus.AwaitingPayment:
                    return "در انتظار پرداخت";

                case OrderStatus.Unsuccessful:
                    return "نا موفق";

                default:
                    throw new Exception("Enum value not found");
            }
        }


        public static string ToStringValue(this TagSortType sortType)
        {
            switch (sortType)
            {
                case TagSortType.None:
                    return " بدون مرتب سازی ";

                case TagSortType.Newest:
                    return "جدیدترین";

                case TagSortType.LatestChange:
                    return "آخرین تغییر";

                case TagSortType.Oldest:
                    return "قدیمی ترین";

                case TagSortType.Title:
                    return "عنوان صعودی";

                case TagSortType.TitleDesc:
                    return "عنوان نزولی";

                default:
                    throw new Exception("Enum value not found");
            }


        }


        public static string ToStringValue(this TrackingDescriptionSortType sortType)
        {
            switch (sortType)
            {
                case TrackingDescriptionSortType.None:
                    return " بدون مرتب سازی ";

                case TrackingDescriptionSortType.Newest:
                    return "جدیدترین";

                case TrackingDescriptionSortType.LatestChange:
                    return "آخرین تغییر";

                case TrackingDescriptionSortType.Oldest:
                    return "قدیمی ترین";

                case TrackingDescriptionSortType.Title:
                    return "عنوان صعودی";

                case TrackingDescriptionSortType.TitleDesc:
                    return "عنوان نزولی";

                default:
                    throw new Exception("Enum value not found");
            }
        }


        public static string ToStringValue(this UserSortType sortType)
        {
            switch (sortType)
            {
                case UserSortType.None:
                    return " بدون مرتب سازی ";

                case UserSortType.Newest:
                    return "جدیدترین";

                case UserSortType.LatestChange:
                    return "آخرین تغییر";

                case UserSortType.Oldest:
                    return "قدیمی ترین";

                case UserSortType.Name:
                    return "نام صعودی";

                case UserSortType.NameDesc:
                    return "نام نزولی";

                case UserSortType.Email:
                    return "ایمیل صعودی";

                case UserSortType.EmailDesc:
                    return "ایمیل نزولی";

                case UserSortType.PhoneNumber:
                    return "شماره همراه صعودی";

                case UserSortType.PhoneNumberDesc:
                    return "شماره همراه نزولی";

                default:
                    throw new Exception("Enum value not found");
            }
        }


        public static string ToStringValue(this PictureType pictureType)
        {
            switch (pictureType)
            {
                case PictureType.Product:
                    return "محصول";

                case PictureType.Category:
                    return "دسته بندی";

                case PictureType.User:
                    return "کاربر";

                default:
                    throw new Exception("Enum value not found");
            }
        }


        public static string ToStringValue(this VarientType varientType)
        {
            switch (varientType)
            {
                case VarientType.Color:
                    return "رنگ";

                case VarientType.Size:
                    return "سایز";

                case VarientType.Weight:
                    return "وزن";

                case VarientType.Volume:
                    return "حجم";

                default:
                    throw new Exception("Enum value not found");
            }
        }


        public static string ToStringValue(this Province province)
        {
            switch (province)
            {
                case Province.Alborz: return "البرز";

                case Province.Ardebil: return "اردبیل";

                case Province.AzarbayjanGharbi: return "آذربایجان غربی";

                case Province.AzarbayjanSharghi: return "آذربایجان شرقی";

                case Province.Boushehr: return "بوشهر";

                case Province.ChaharMahal: return "چهارمحال و بختیاری";

                case Province.Esfahan: return "اصفهان";

                case Province.Fars: return "فارس";

                case Province.Gilan: return "گیلان";

                case Province.Golestan: return "گلستان";

                case Province.Hamedan: return "همدان";

                case Province.Hormozgan: return "هرمزگان";

                case Province.Ilam: return "ایلام";

                case Province.Kerman: return "کرمان";

                case Province.Kermanshah: return "کرمانشاه";

                case Province.Khoozestan: return "خوزستان";

                case Province.KhorasanJonoubi: return "خراسان جنوبی";

                case Province.KhorasanRazavi: return "خراسان رضوی";

                case Province.KhorasanShomali: return "خراسان شمالی";

                case Province.Kohgilouye: return "کهگیلویه و بویراحمد";

                case Province.Kordestan: return "کردستان";

                case Province.Lorestan: return "لرستان";

                case Province.Markazi: return "مرکزی";

                case Province.Mazandaran: return "مازندران";

                case Province.Qazvin: return "قزوین";

                case Province.Qom: return "قم";

                case Province.Semnan: return "سمنان";

                case Province.Sistan: return "سیستان";

                case Province.Tehran: return "تهران";

                case Province.Yazd: return "یزد";

                case Province.Zanjan: return "زنجان";

                default:
                    throw new Exception("Enum value not found");
            }
        }







    }
}
