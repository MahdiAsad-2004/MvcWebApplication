using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;

namespace OrganicShop.DAL.SeedDatas
{
    public static class TagSeed
    {

        public static readonly Tag tag = new Tag
        {
            Title = "",
            BaseEntity = new BaseEntity(true),
        };





        public static readonly Tag Cooking = new Tag
        {
            Title = "آشپزی",
            BaseEntity = new BaseEntity(true),
        };

        public static readonly Tag HowToPrepare = new Tag
        {
            Title = "طرز تهیه",
            BaseEntity = new BaseEntity(true),
        };

        public static readonly Tag Diet = new Tag
        {
            Title = "رژیم",
            BaseEntity = new BaseEntity(true),
        };

        public static readonly Tag DietPlan = new Tag
        {
            Title = "برنامه رژیم",
            BaseEntity = new BaseEntity(true),
        };

        public static readonly Tag Fruit = new Tag
        {
            Title = "میوه",
            BaseEntity = new BaseEntity(true),
        };

        public static readonly Tag FoodProperties = new Tag
        {
            Title = "خواص مواد غذایی",
            BaseEntity = new BaseEntity(true),
        };

        public static readonly Tag BodyHealth = new Tag
        {
            Title = "سلامت بدن",
            BaseEntity = new BaseEntity(true),
        };

        public static readonly Tag IntroduceFood = new Tag
        {
            Title = "معرفی غذا",
            BaseEntity = new BaseEntity(true),
        };
        
        public static readonly Tag Exercise = new Tag
        {
            Title = "ورزش",
            BaseEntity = new BaseEntity(true),
        };
        
        public static readonly Tag Baby = new Tag
        {
            Title = "کودک",
            BaseEntity = new BaseEntity(true),
        };






















    }
}
