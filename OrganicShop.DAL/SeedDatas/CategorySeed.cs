using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.DAL.SeedDatas
{
    public class CategorySeed
    {

        #region BasicGoods

        public static readonly Category BasicGoods = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "کالاهای اساسی و خواربار",
            Type = CategoryType.Product,
        };


        #region BasicGoods =>


        public static readonly Category BasicGoods_Bread = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "نان",
            Type = CategoryType.Product,
            Parent = BasicGoods,
        };

        public static readonly Category BasicGoods_Candy = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "قند و نبات",
            Type = CategoryType.Product,
            Parent = BasicGoods,
        };

        public static readonly Category BasicGoods_Sugar = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "شکر",
            Type = CategoryType.Product,
            Parent = BasicGoods,
        };

        public static readonly Category BasicGoods_Cereals = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "حبوبات",
            Type = CategoryType.Product,
            Parent = BasicGoods,
        };

        public static readonly Category BasicGoods_PastaAndNoodles = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "ماکارونی، پاستا، نودل",
            Type = CategoryType.Product,
            Parent = BasicGoods,
        };

        public static readonly Category BasicGoods_Oil = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "روغن",
            Type = CategoryType.Product,
            Parent = BasicGoods,
        };

        public static readonly Category BasicGoods_Rice = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "برنج",
            Type = CategoryType.Product,
            Parent = BasicGoods,
        };


        #endregion


        #endregion


        #region Dairy

        public static readonly Category Dairy = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "لبنیات",
            Type = CategoryType.Product,
        };


        #region Dairy =>

        public static readonly Category Dairy_Cheese = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "پنیر",
            Type = CategoryType.Product,
            Parent = Dairy,
        };

        public static readonly Category Dairy_Cream = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "خامه",
            Type = CategoryType.Product,
            Parent = Dairy,
        };

        public static readonly Category Dairy_Dough = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "دوغ",
            Type = CategoryType.Product,
            Parent = Dairy
        };

        public static readonly Category Dairy_Milk = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "شیر",
            Type = CategoryType.Product,
            Parent = Dairy
        };

        public static readonly Category Dairy_Butter = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "کره",
            Type = CategoryType.Product,
            Parent = Dairy,
        };

        public static readonly Category Dairy_Yogurt = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "ماست",
            Type = CategoryType.Product,
            Parent = Dairy,
        };

        public static readonly Category Dairy_Honey = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "عسل",
            Type = CategoryType.Product,
            Parent = Dairy,
        };

        public static readonly Category Dairy_Jam = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "مربا",
            Type = CategoryType.Product,
            Parent = Dairy,
        };

        public static readonly Category Dairy_BreakfastChocolate = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "شکلات صبحانه",
            Type = CategoryType.Product,
            Parent = Dairy,
        };

        #endregion


        #endregion


        #region Proteins

        public static readonly Category MeatAndProtein = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "گوشت و پروتئین",
            Type = CategoryType.Product,
        };


        #region Proteins =>

        public static readonly Category Proteins_Beef = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "گوشت گاو و گوساله و شتر",
            Type = CategoryType.Product,
            Parent = MeatAndProtein,
        };

        public static readonly Category Proteins_Checken = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "گوشت مرغ",
            Type = CategoryType.Product,
            Parent = MeatAndProtein,
        };

        public static readonly Category Proteins_Fish = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "ماهی",
            Type = CategoryType.Product,
            Parent = MeatAndProtein,
        };

        public static readonly Category Proteins_Sausages = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "سوسیس و کالباس",
            Type = CategoryType.Product,
            Parent = MeatAndProtein,
        };

        public static readonly Category Proteins_SheapMeat = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "گوشت گوسفند",
            Type = CategoryType.Product,
            Parent = MeatAndProtein,
        };

        public static readonly Category Proteins_BirdsMeat = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "گوشت پرندگان",
            Type = CategoryType.Product,
            Parent = MeatAndProtein,
        };

        public static readonly Category Proteins_Caviar = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "خاویار",
            Type = CategoryType.Product,
            Parent = MeatAndProtein,
        };

        public static readonly Category Proteins_BirdsEgg = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "تخم پرندگان",
            Type = CategoryType.Product,
            Parent = MeatAndProtein,
        };


        #endregion



        #endregion


        #region Beverages

        public static readonly Category Beverages = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "نوشیدنی‌های سرد",
            Type = CategoryType.Product,
        };


        #region Beverages =>

        public static readonly Category Beverages_EnergyDrink = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "نوشیدنی ورزشی و انرژی‌زا",
            Type = CategoryType.Product,
            Parent = Beverages,
        };

        public static readonly Category Beverages_SoftDrink = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "نوشابه",
            Type = CategoryType.Product,
            Parent = Beverages,
        };

        public static readonly Category Beverages_NonAlcoholicBeer = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "ماءالشعیر",
            Type = CategoryType.Product,
            Parent = Beverages,
        };

        public static readonly Category Beverages_Water = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "آب و آب معدنی",
            Type = CategoryType.Product,
            Parent = Beverages,
        };

        public static readonly Category Beverages_Distillates = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "عرقیات",
            Type = CategoryType.Product,
            Parent = Beverages,
        };


        public static readonly Category Beverages_SyrupAndJuice = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "شربت و آبمیوه",
            Type = CategoryType.Product,
            Parent = Beverages,
        };

        #endregion


        #endregion


        #region CannedFoodAndReadyMeals


        public static readonly Category CannedFoodAndReadyMeals = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "کنسرو و غذای آماده",
            Type = CategoryType.Product,
        };


        #region CannedFoodAndReadyMeals =>

        public static readonly Category CannedFoodAndReadyMeals_SemiPreparedFood = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "غذای نیمه آماده",
            Type = CategoryType.Product,
            Parent = CannedFoodAndReadyMeals,
        };

        public static readonly Category CannedFoodAndReadyMeals_TunnaFish = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "کنسرو ماهی",
            Type = CategoryType.Product,
            Parent = CannedFoodAndReadyMeals,
        };

        public static readonly Category CannedFoodAndReadyMeals_Compote = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "کمپوت",
            Type = CategoryType.Product,
            Parent = CannedFoodAndReadyMeals,
        };

        public static readonly Category CannedFoodAndReadyMeals_ReadyFood = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "غذای آماده",
            Type = CategoryType.Product,
            Parent = CannedFoodAndReadyMeals,
        };

        public static readonly Category CannedFoodAndReadyMeals_CannedBeansAndVegetables = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "کنسرو حبوبات و سبزیجات",
            Type = CategoryType.Product,
            Parent = CannedFoodAndReadyMeals,
        };

        #endregion


        #endregion


        #region DriedFruitsAndSweets

        public static readonly Category DriedFruitsAndSweets = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "خشکبار و شیرینی",
            Type = CategoryType.Product,
        };


        #region DriedFruitsAndSweets => 

        public static readonly Category DriedFruitsAndSweets_Sweet = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "شیرینی",
            Type = CategoryType.Product,
            Parent = DriedFruitsAndSweets,
        };

        public static readonly Category DriedFruitsAndSweets_Date = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "خرما",
            Type = CategoryType.Product,
            Parent = DriedFruitsAndSweets,
        };

        public static readonly Category DriedFruitsAndSweets_Nuts = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "آجیل",
            Type = CategoryType.Product,
            Parent = DriedFruitsAndSweets,
        };

        public static readonly Category DriedFruitsAndSweets_DriedFruit = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "میوه خشک",
            Type = CategoryType.Product,
            Parent = DriedFruitsAndSweets,
        };

        public static readonly Category DriedFruitsAndSweets_Raisins = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "کشمش و مویز",
            Type = CategoryType.Product,
            Parent = DriedFruitsAndSweets,
        };

        public static readonly Category DriedFruitsAndSweets_Dessert = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "دسر",
            Type = CategoryType.Product,
            Parent = DriedFruitsAndSweets,
        };

        #endregion


        #endregion


        #region Fruits

        public static readonly Category Fruits = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "میوه",
            Type = CategoryType.Product,
        };

        #endregion


        #region Vegetables

        public static readonly Category Vegetables = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "سبزیجات",
            Type = CategoryType.Product,
        };

        #endregion


        #region Snacks

        public static readonly Category Snacks = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "تنقلات",
            Type = CategoryType.Product,
        };


        #region Snakcs => 

        public static readonly Category Snakcs_BiscuitsAndWafers = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "بیسکویت و ویفر",
            Type = CategoryType.Product,
            Parent = Snacks,
        };

        public static readonly Category CandyAndToffee = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "آبنبات و تافی",
            Type = CategoryType.Product,
            Parent = Snacks,
        };

        public static readonly Category Snakcs_PuffsAndSnacks = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "پفک و اسنک",
            Type = CategoryType.Product,
            Parent = Snacks,
        };

        public static readonly Category Snakcs_ChipsAndPopcorn = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "چیپس و پاپ کورن",
            Type = CategoryType.Product,
            Parent = Snacks,
        };

        public static readonly Category Snakcs_GummiCandy = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "پاستیل",
            Type = CategoryType.Product,
            Parent = Snacks,
        };

        public static readonly Category Snakcs_FlavoredSeedsAndKernels = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "تخمه و مغز طعم‌دار",
            Type = CategoryType.Product,
            Parent = Snacks,
        };

        public static readonly Category Snakcs_Lavashk = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "لواشک، برگه و آلوچه",
            Type = CategoryType.Product,
            Parent = Snacks,
        };

        public static readonly Category Snakcs_ChewingGum = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "آدامس",
            Type = CategoryType.Product,
            Parent = Snacks,
        };

        public static readonly Category Snakcs_CakesAndCookies = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "کیک و کلوچه",
            Type = CategoryType.Product,
            Parent = Snacks,
        };

        public static readonly Category Snakcs_ChocolateAndCocoa = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "شکلات و کاکائو",
            Type = CategoryType.Product,
            Parent = Snacks,
        };

        #endregion



        #endregion


        #region WarmDrinks

        public static readonly Category WarmDrinks = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "نوشیدنی‌های گرم",
            Type = CategoryType.Product,
        };



        #region WarmDrinks => 

        public static readonly Category WarmDrinks_Tea = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "چای",
            Type = CategoryType.Product,
            Parent = WarmDrinks,
        };

        public static readonly Category WarmDrinks_Coffee = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "قهوه",
            Type = CategoryType.Product,
            Parent = WarmDrinks,
        };

        public static readonly Category WarmDrinks_InstantCoffee = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "قهوه فوری",
            Type = CategoryType.Product,
            Parent = WarmDrinks,
        };

        public static readonly Category WarmDrinks_HotChocolate = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "هات چاکلت",
            Type = CategoryType.Product,
            Parent = WarmDrinks,
        };

        public static readonly Category WarmDrinks_Cappuccino = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "کاپوچینو",
            Type = CategoryType.Product,
            Parent = WarmDrinks,
        };

        public static readonly Category WarmDrinks_HerbalTea = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "دمنوش",
            Type = CategoryType.Product,
            Parent = WarmDrinks,
        };

        #endregion



        #endregion


        #region FrozenProducts

        public static readonly Category FrozenProducts = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "فراورده های منجمد",
            Type = CategoryType.Product,
        };


        #region FrozenProducts => 

        public static readonly Category FrozenProducts_SemiFrozenFood = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "غذای نیمه آماده منجمد",
            Type = CategoryType.Product,
            Parent = FrozenProducts,
        };

        public static readonly Category FrozenProducts_FrozenFruit = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "میوه منجمد",
            Type = CategoryType.Product,
            Parent = FrozenProducts,
        };

        public static readonly Category FrozenProducts_FrozenVegetables = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "سبزیجات منجمد",
            Type = CategoryType.Product,
            Parent = FrozenProducts,
        };

        public static readonly Category FrozenProducts_FrozenReadyFood = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "غذای آماده منجمد",
            Type = CategoryType.Product,
            Parent = FrozenProducts,
        };

        public static readonly Category FrozenProducts_DoughAndBread = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "خمیر و نان پیتزا",
            Type = CategoryType.Product,
            Parent = FrozenProducts,
        };

        #endregion


        #endregion


        #region Pickles

        public static readonly Category Pickles = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "ترشیجات",
            Type = CategoryType.Product,
        };


        #region Pickles =>

        public static readonly Category Pickles_PickledCucumber = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "خیارشور",
            Type = CategoryType.Product,
            Parent = Pickles,
        };

        public static readonly Category Pickles_Olive = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "زیتون",
            Type = CategoryType.Product,
            Parent = Pickles,
        };

        public static readonly Category Pickles_Salty = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "شور",
            Type = CategoryType.Product,
            Parent = Pickles,
        };

        public static readonly Category Pickles_Pickle = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "ترشی",
            Type = CategoryType.Product,
            Parent = Pickles,
        };

        #endregion


        #endregion


        #region Additives

        public static readonly Category Additives = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "افزودنی ها",
            Type = CategoryType.Product,
        };


        #region Additives =>

        public static readonly Category Additives_LiquidCondiments = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "چاشنی‌های مایع",
            Type = CategoryType.Product,
            Parent = Additives,
        };

        public static readonly Category Additives_FoodDesign = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "زعفران، زرشک و تزئینات غذا",
            Type = CategoryType.Product,
            Parent = Additives,
        };

        public static readonly Category Additives_SpicesAndSeasonings = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "ادویه و چاشنی",
            Type = CategoryType.Product,
            Parent = Additives,
        };

        public static readonly Category Additives_Sauce = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "سس",
            Type = CategoryType.Product,
            Parent = Additives,
        };

        public static readonly Category Additives_DriedVegetablesAndSproutPowder = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "سبزی خشک و پودر جوانه",
            Type = CategoryType.Product,
            Parent = Additives,
        };

        #endregion


        #endregion


    }
}
