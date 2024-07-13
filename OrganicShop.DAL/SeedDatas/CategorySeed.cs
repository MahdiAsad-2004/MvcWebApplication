using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.DAL.SeedDatas
{
    public class CategorySeed
    {

        #region BasicGoods

        //Id = 1
        public static readonly Category BasicGoods = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "کالاهای اساسی و خواربار",
            Type = CategoryType.Product,
            Picture = new Picture
            {
                IsMain = true,
                Name = "BasicGoods.png",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Bread ,ProductSeed.Sugar ,ProductSeed.RedBeans ,ProductSeed.Macaroni ,ProductSeed.Oil ,ProductSeed.Rice ,ProductSeed.Nabaat
            }
        };


        #region BasicGoods =>

        // Id = 14
        public static readonly Category BasicGoods_Bread = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "نان",
            Type = CategoryType.Product,
            Parent = BasicGoods,
            Picture = new Picture
            {
                IsMain = true,
                Name = "bread.png",
                SizeMB = (float)0.127,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Bread,
            }
        };

        // Id = 15
        public static readonly Category BasicGoods_Candy = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "قند و نبات",
            Type = CategoryType.Product,
            Parent = BasicGoods,
            Picture = new Picture
            {
                IsMain = true,
                Name = "candy.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Nabaat,
            }
        };

        // Id = 16
        public static readonly Category BasicGoods_Cereals = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "حبوبات",
            Type = CategoryType.Product,
            Parent = BasicGoods,
            Picture = new Picture
            {
                IsMain = true,
                Name = "cereals.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.RedBeans,
            }
        };

        // Id = 17
        public static readonly Category BasicGoods_Oil = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "روغن",
            Type = CategoryType.Product,
            Parent = BasicGoods,
            Picture = new Picture
            {
                IsMain = true,
                Name = "oil.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Oil,
            }
        };

        // Id = 18
        public static readonly Category BasicGoods_PastaAndNoodles = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "ماکارونی، پاستا، نودل",
            Type = CategoryType.Product,
            Parent = BasicGoods,
            Picture = new Picture
            {
                IsMain = true,
                Name = "pasta.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Macaroni,
            }
        };

        // Id = 19
        public static readonly Category BasicGoods_Rice = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "برنج",
            Type = CategoryType.Product,
            Parent = BasicGoods,
            Picture = new Picture
            {
                IsMain = true,
                Name = "rice.png",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Rice,
            }
        };

        // Id = 20
        public static readonly Category BasicGoods_Sugar = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "شکر",
            Type = CategoryType.Product,
            Parent = BasicGoods,
            Picture = new Picture
            {
                IsMain = true,
                Name = "sugare.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Sugar,
            }
        };



        #endregion


        #endregion


        #region Dairy

        // Id = 2
        public static readonly Category Dairy = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "لبنیات",
            Type = CategoryType.Product,
            Picture = new Picture
            {
                IsMain = true,
                Name = "dairy.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Cheese ,ProductSeed.Cream ,ProductSeed.Dough ,ProductSeed.Butter ,ProductSeed.Milk ,ProductSeed.Jam ,
                ProductSeed.Yogurt ,ProductSeed.Honey ,ProductSeed.BreakfastChocolate
            }
        };


        #region Dairy =>

        // Id = 21
        public static readonly Category Dairy_BreakfastChocolate = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "شکلات صبحانه",
            Type = CategoryType.Product,
            Parent = Dairy,
            Picture = new Picture
            {
                IsMain = true,
                Name = "breakfast-chocolate.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.BreakfastChocolate,
            }
        };

        // Id = 22
        public static readonly Category Dairy_Butter = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "کره",
            Type = CategoryType.Product,
            Parent = Dairy,
            Picture = new Picture
            {
                IsMain = true,
                Name = "butter.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Butter,
            }
        };

        // Id = 23
        public static readonly Category Dairy_Cheese = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "پنیر",
            Type = CategoryType.Product,
            Parent = Dairy,
            Picture = new Picture
            {
                IsMain = true,
                Name = "cheese.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Cheese,
            }
        };

        // Id = 24
        public static readonly Category Dairy_Cream = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "خامه",
            Type = CategoryType.Product,
            Parent = Dairy,
            Picture = new Picture
            {
                IsMain = true,
                Name = "cream.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Cream,
            }
        };

        // Id = 25
        public static readonly Category Dairy_Dough = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "دوغ",
            Type = CategoryType.Product,
            Parent = Dairy,
            Picture = new Picture
            {
                IsMain = true,
                Name = "dough.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Dough,
            }
        };

        // Id = 26
        public static readonly Category Dairy_Honey = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "عسل",
            Type = CategoryType.Product,
            Parent = Dairy,
            Picture = new Picture
            {
                IsMain = true,
                Name = "honey.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Honey,
            }
        };

        // Id = 27
        public static readonly Category Dairy_Jam = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "مربا",
            Type = CategoryType.Product,
            Parent = Dairy,
            Picture = new Picture
            {
                IsMain = true,
                Name = "jam.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Jam,
            }
        };

        // Id = 28
        public static readonly Category Dairy_Milk = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "شیر",
            Type = CategoryType.Product,
            Parent = Dairy,
            Picture = new Picture
            {
                IsMain = true,
                Name = "milk.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Milk,
            }
        };

        // Id = 29
        public static readonly Category Dairy_Yogurt = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "ماست",
            Type = CategoryType.Product,
            Parent = Dairy,
            Picture = new Picture
            {
                IsMain = true,
                Name = "yogurt.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Yogurt,
            }
        };

        #endregion


        #endregion


        #region Proteins

        // Id = 3
        public static readonly Category MeatAndProtein = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "گوشت و پروتئین",
            Type = CategoryType.Product,
            Picture = new Picture
            {
                IsMain = true,
                Name = "protein.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Beef ,ProductSeed.Meat ,ProductSeed.Checken ,ProductSeed.Fish ,ProductSeed.Sausage ,ProductSeed.Shrimp ,ProductSeed.Egg, ProductSeed.Caviar,
            }
        };


        #region Proteins =>

        // Id = 30
        public static readonly Category Proteins_Beef = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "گوشت گاو و گوساله و شتر",
            Type = CategoryType.Product,
            Parent = MeatAndProtein,
            Picture = new Picture
            {
                IsMain = true,
                Name = "beef.png",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Beef,
            }
        };

        // Id = 31
        public static readonly Category Proteins_BirdsEgg = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "تخم پرندگان",
            Type = CategoryType.Product,
            Parent = MeatAndProtein,
            Picture = new Picture
            {
                IsMain = true,
                Name = "birds-egg.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Egg
            }
        };

        // Id = 32
        public static readonly Category Proteins_Caviar = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "خاویار",
            Type = CategoryType.Product,
            Parent = MeatAndProtein,
            Picture = new Picture
            {
                IsMain = true,
                Name = "caviar.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Caviar,
            },
        };

        // Id = 33
        public static readonly Category Proteins_Checken = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "گوشت مرغ",
            Type = CategoryType.Product,
            Parent = MeatAndProtein,
            Picture = new Picture
            {
                IsMain = true,
                Name = "checken.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Checken,
            },
        };

        // Id = 34
        public static readonly Category Proteins_Fish = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "ماهی",
            Type = CategoryType.Product,
            Parent = MeatAndProtein,
            Picture = new Picture
            {
                IsMain = true,
                Name = "fish.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Fish,
            },
        };

        // Id = 35
        public static readonly Category Proteins_Sausages = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "سوسیس و کالباس",
            Type = CategoryType.Product,
            Parent = MeatAndProtein,
            Picture = new Picture
            {
                IsMain = true,
                Name = "sausages.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Sausage,
            },
        };

        // Id = 36
        public static readonly Category Proteins_SheapMeat = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "گوشت گوسفند",
            Type = CategoryType.Product,
            Parent = MeatAndProtein,
            Picture = new Picture
            {
                IsMain = true,
                Name = "sheep-meat.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Meat,
            },
        };

        // Id = 37
        public static readonly Category Proteins_Shrimp = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "میگو",
            Type = CategoryType.Product,
            Parent = MeatAndProtein,
            Picture = new Picture
            {
                IsMain = true,
                Name = "shrimp.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Shrimp,
            },
        };

        #endregion


        #endregion


        #region Beverages

        // Id = 4
        public static readonly Category Beverages = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "نوشیدنی‌های سرد",
            Type = CategoryType.Product,
            Picture = new Picture
            {
                IsMain = true,
                Name = "beverages.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.EnergyDrink ,ProductSeed.Coca ,ProductSeed.Golaab ,ProductSeed.Water ,ProductSeed.Juice ,ProductSeed.Delester,
            },
        };


        #region Beverages =>

        // Id = 38
        public static readonly Category Beverages_Distillates = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "عرقیات",
            Type = CategoryType.Product,
            Parent = Beverages,
            Picture = new Picture
            {
                IsMain = true,
                Name = "distillates.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Golaab,
            },
        };

        // Id = 39
        public static readonly Category Beverages_EnergyDrink = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "نوشیدنی ورزشی و انرژی‌زا",
            Type = CategoryType.Product,
            Parent = Beverages,
            Picture = new Picture
            {
                IsMain = true,
                Name = "energy-drink.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.EnergyDrink,
            },
        };

        // Id = 40
        public static readonly Category Beverages_NonAlcoholicBeer = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "ماءالشعیر",
            Type = CategoryType.Product,
            Parent = Beverages,
            Picture = new Picture
            {
                IsMain = true,
                Name = "non-alcoholic-beer.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Delester,
            },
        };

        // Id = 41
        public static readonly Category Beverages_SoftDrink = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "نوشابه",
            Type = CategoryType.Product,
            Parent = Beverages,
            Picture = new Picture
            {
                IsMain = true,
                Name = "soft-drink.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Coca,
            },
        };

        // Id = 42
        public static readonly Category Beverages_SyrupAndJuice = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "شربت و آبمیوه",
            Type = CategoryType.Product,
            Parent = Beverages,
            Picture = new Picture
            {
                IsMain = true,
                Name = "syrup-and-juice.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Juice,
            },
        };

        // Id = 43
        public static readonly Category Beverages_Water = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "آب و آب معدنی",
            Type = CategoryType.Product,
            Parent = Beverages,
            Picture = new Picture
            {
                IsMain = true,
                Name = "water.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Water,
            },
        };

        #endregion


        #endregion


        #region CannedFoodAndReadyMeals

        // Id = 5
        public static readonly Category CannedFoodAndReadyMeals = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "کنسرو و غذای آماده",
            Type = CategoryType.Product,
            Picture = new Picture
            {
                IsMain = true,
                Name = "canned-food-and-ready-meals.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.CannedBean ,ProductSeed.TunnaFish ,ProductSeed.Dessert ,ProductSeed.Soup ,ProductSeed.Compote ,ProductSeed.Stew,
            },
        };


        #region CannedFoodAndReadyMeals =>

        // Id = 44
        public static readonly Category CannedFoodAndReadyMeals_CannedBeansAndVegetables = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "کنسرو حبوبات و سبزیجات",
            Type = CategoryType.Product,
            Parent = CannedFoodAndReadyMeals,
            Picture = new Picture
            {
                IsMain = true,
                Name = "canned-beans-and-vegetables.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.CannedBean,
            },
        };

        // Id = 45
        public static readonly Category CannedFoodAndReadyMeals_Compote = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "کمپوت",
            Type = CategoryType.Product,
            Parent = CannedFoodAndReadyMeals,
            Picture = new Picture
            {
                IsMain = true,
                Name = "compote.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Compote,
            },
        };

        // Id = 46
        public static readonly Category CannedFoodAndReadyMeals_ReadyFood = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "غذای آماده",
            Type = CategoryType.Product,
            Parent = CannedFoodAndReadyMeals,
            Picture = new Picture
            {
                IsMain = true,
                Name = "ready-food.png",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Stew,
            },
        };

        // Id = 47
        public static readonly Category CannedFoodAndReadyMeals_SemiPreparedFood = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "غذای نیمه آماده",
            Type = CategoryType.Product,
            Parent = CannedFoodAndReadyMeals,
            Picture = new Picture
            {
                IsMain = true,
                Name = "semi-prepared-food.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.Soup,
            },
        };

        // Id = 48
        public static readonly Category CannedFoodAndReadyMeals_TunnaFish = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "کنسرو ماهی",
            Type = CategoryType.Product,
            Parent = CannedFoodAndReadyMeals,
            Picture = new Picture
            {
                IsMain = true,
                Name = "tunna-fish.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
            Products = new List<Product>
            {
                ProductSeed.TunnaFish,
            },
        };

        #endregion


        #endregion


        #region DriedFruitsAndSweets

        // Id = 6
        public static readonly Category DriedFruitsAndSweets = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "خشکبار و شیرینی",
            Type = CategoryType.Product,
            Picture = new Picture
            {
                IsMain = true,
                Name = "dried-fruits-and-sweets.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };


        #region DriedFruitsAndSweets => 

        // Id = 49
        public static readonly Category DriedFruitsAndSweets_Date = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "خرما",
            Type = CategoryType.Product,
            Parent = DriedFruitsAndSweets,
            Picture = new Picture
            {
                IsMain = true,
                Name = "date.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        // Id = 50
        public static readonly Category DriedFruitsAndSweets_Dessert = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "دسر",
            Type = CategoryType.Product,
            Parent = DriedFruitsAndSweets,
            Picture = new Picture
            {
                IsMain = true,
                Name = "dessert.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        // Id = 51
        public static readonly Category DriedFruitsAndSweets_DriedFruit = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "میوه خشک",
            Type = CategoryType.Product,
            Parent = DriedFruitsAndSweets,
            Picture = new Picture
            {
                IsMain = true,
                Name = "dried-fruit.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        // Id = 52
        public static readonly Category DriedFruitsAndSweets_Nuts = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "آجیل",
            Type = CategoryType.Product,
            Parent = DriedFruitsAndSweets,
            Picture = new Picture
            {
                IsMain = true,
                Name = "nuts.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        // Id = 53
        public static readonly Category DriedFruitsAndSweets_Raisins = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "کشمش و مویز",
            Type = CategoryType.Product,
            Parent = DriedFruitsAndSweets,
            Picture = new Picture
            {
                IsMain = true,
                Name = "raisins.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        // Id = 54
        public static readonly Category DriedFruitsAndSweets_Sweet = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "شیرینی",
            Type = CategoryType.Product,
            Parent = DriedFruitsAndSweets,
            Picture = new Picture
            {
                IsMain = true,
                Name = "sweet.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        #endregion


        #endregion


        #region Fruits

        // Id = 7
        public static readonly Category Fruits = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "میوه",
            Type = CategoryType.Product,
            Picture = new Picture
            {
                IsMain = true,
                Name = "fruit.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        #endregion


        #region Vegetables

        // Id = 8
        public static readonly Category Vegetables = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "سبزیجات",
            Type = CategoryType.Product,
            Picture = new Picture
            {
                IsMain = true,
                Name = "vegetables.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        #endregion


        #region Snacks

        // Id = 9
        public static readonly Category Snacks = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "تنقلات",
            Type = CategoryType.Product,
            Picture = new Picture
            {
                IsMain = true,
                Name = "snacks.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            }
        };


        #region Snakcs => 

        // Id = 55
        public static readonly Category Snacks_BiscuitsAndWafers = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "بیسکویت و ویفر",
            Type = CategoryType.Product,
            Parent = Snacks,
            Picture = new Picture
            {
                IsMain = true,
                Name = "biscuits-and-wafers.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            }
        };

        // Id = 56
        public static readonly Category Snacks_CakesAndCookies = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "کیک و کلوچه",
            Type = CategoryType.Product,
            Parent = Snacks,
            Picture = new Picture
            {
                IsMain = true,
                Name = "cak-and-cookies.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            }
        };

        // Id = 57
        public static readonly Category Snacks_CandyAndToffee = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "آبنبات و تافی",
            Type = CategoryType.Product,
            Parent = Snacks,
            Picture = new Picture
            {
                IsMain = true,
                Name = "candy-and-toffee.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            }
        };

        // Id = 58
        public static readonly Category Snacks_ChewingGum = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "آدامس",
            Type = CategoryType.Product,
            Parent = Snacks,
            Picture = new Picture
            {
                IsMain = true,
                Name = "chewing-gum.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            }
        };

        // Id = 59
        public static readonly Category Snacks_ChipsAndPopcorn = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "چیپس و پاپ کورن",
            Type = CategoryType.Product,
            Parent = Snacks,
            Picture = new Picture
            {
                IsMain = true,
                Name = "chips-and-popcorn.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            }
        };

        // Id = 60
        public static readonly Category Snacks_ChocolateAndCocoa = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "شکلات و کاکائو",
            Type = CategoryType.Product,
            Parent = Snacks,
            Picture = new Picture
            {
                IsMain = true,
                Name = "hocolate-and-cocoa.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            }
        };

        // Id = 61
        public static readonly Category Snacks_GummiCandy = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "پاستیل",
            Type = CategoryType.Product,
            Parent = Snacks,
            Picture = new Picture
            {
                IsMain = true,
                Name = "gummi-candy.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            }
        };

        // Id = 62
        public static readonly Category Snacks_FlavoredSeedsAndKernels = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "تخمه و مغز طعم‌دار",
            Type = CategoryType.Product,
            Parent = Snacks,
            Picture = new Picture
            {
                IsMain = true,
                Name = "flavored-seed-and-kernels.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            }
        };

        // Id = 63
        public static readonly Category Snacks_Lavashak = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "لواشک، برگه و آلوچه",
            Type = CategoryType.Product,
            Parent = Snacks,
            Picture = new Picture
            {
                IsMain = true,
                Name = "lavashak.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            }
        };

        // Id = 64
        public static readonly Category Snacks_PuffsAndSnacks = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "پفک و اسنک",
            Type = CategoryType.Product,
            Parent = Snacks,
            Picture = new Picture
            {
                IsMain = true,
                Name = "puffs-and-snacks.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            }
        };

        #endregion


        #endregion


        #region WarmDrinks

        // Id = 10
        public static readonly Category WarmDrinks = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "نوشیدنی‌های گرم",
            Type = CategoryType.Product,
            Picture = new Picture
            {
                IsMain = true,
                Name = "warm-drinks.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };


        #region WarmDrinks => 

        // Id = 65
        public static readonly Category WarmDrinks_Cappuccino = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "کاپوچینو",
            Type = CategoryType.Product,
            Parent = WarmDrinks,
            Picture = new Picture
            {
                IsMain = true,
                Name = "cappuccino.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        // Id = 66
        public static readonly Category WarmDrinks_Coffee = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "قهوه",
            Type = CategoryType.Product,
            Parent = WarmDrinks,
            Picture = new Picture
            {
                IsMain = true,
                Name = "coffee.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        // Id = 67
        public static readonly Category WarmDrinks_HerbalTea = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "دمنوش",
            Type = CategoryType.Product,
            Parent = WarmDrinks,
            Picture = new Picture
            {
                IsMain = true,
                Name = "herbal-tea.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        // Id = 68
        public static readonly Category WarmDrinks_HotChocolate = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "هات چاکلت",
            Type = CategoryType.Product,
            Parent = WarmDrinks,
            Picture = new Picture
            {
                IsMain = true,
                Name = "hot-chocolate.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        // Id = 69
        public static readonly Category WarmDrinks_InstantCoffee = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "قهوه فوری",
            Type = CategoryType.Product,
            Parent = WarmDrinks,
            Picture = new Picture
            {
                IsMain = true,
                Name = "instant-coffee.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        // Id = 70
        public static readonly Category WarmDrinks_Tea = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "چای",
            Type = CategoryType.Product,
            Parent = WarmDrinks,
            Picture = new Picture
            {
                IsMain = true,
                Name = "tea.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        #endregion


        #endregion


        #region FrozenProducts

        // Id = 11
        public static readonly Category FrozenProducts = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "فراورده های منجمد",
            Type = CategoryType.Product,
            Picture = new Picture
            {
                IsMain = true,
                Name = "frozen-products.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };


        #region FrozenProducts => 

        // Id = 71
        public static readonly Category FrozenProducts_DoughAndBread = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "خمیر و نان پیتزا",
            Type = CategoryType.Product,
            Parent = FrozenProducts,
            Picture = new Picture
            {
                IsMain = true,
                Name = "dough-and-bread.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        // Id = 72
        public static readonly Category FrozenProducts_FrozenFruit = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "میوه منجمد",
            Type = CategoryType.Product,
            Parent = FrozenProducts,
            Picture = new Picture
            {
                IsMain = true,
                Name = "frozen-food.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        // Id = 73
        public static readonly Category FrozenProducts_FrozenReadyFood = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "غذای آماده منجمد",
            Type = CategoryType.Product,
            Parent = FrozenProducts,
            Picture = new Picture
            {
                IsMain = true,
                Name = "frozen-ready-food.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        // Id = 74
        public static readonly Category FrozenProducts_FrozenVegetables = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "سبزیجات منجمد",
            Type = CategoryType.Product,
            Parent = FrozenProducts,
            Picture = new Picture
            {
                IsMain = true,
                Name = "frozen-vegetables.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        // Id = 75
        public static readonly Category FrozenProducts_SemiFrozenFood = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "غذای نیمه آماده منجمد",
            Type = CategoryType.Product,
            Parent = FrozenProducts,
            Picture = new Picture
            {
                IsMain = true,
                Name = "semi-frozen-food.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        #endregion


        #endregion


        #region Pickles

        // Id = 12
        public static readonly Category Pickles = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "ترشیجات",
            Type = CategoryType.Product,
            Picture = new Picture
            {
                IsMain = true,
                Name = "pickles.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };


        #region Pickles =>

        // Id = 76
        public static readonly Category Pickles_Olive = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "زیتون",
            Type = CategoryType.Product,
            Parent = Pickles,
            Picture = new Picture
            {
                IsMain = true,
                Name = "olive.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        // Id = 77
        public static readonly Category Pickles_Pickle = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "ترشی",
            Type = CategoryType.Product,
            Parent = Pickles,
            Picture = new Picture
            {
                IsMain = true,
                Name = "pickle.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        // Id = 78
        public static readonly Category Pickles_PickledCucumber = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "خیارشور",
            Type = CategoryType.Product,
            Parent = Pickles,
            Picture = new Picture
            {
                IsMain = true,
                Name = "pickled-cucamber.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        // Id = 79
        public static readonly Category Pickles_Salty = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "شور",
            Type = CategoryType.Product,
            Parent = Pickles,
            Picture = new Picture
            {
                IsMain = true,
                Name = "salty.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        #endregion


        #endregion


        #region Additives

        // Id = 13
        public static readonly Category Additives = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "افزودنی ها",
            Type = CategoryType.Product,
            Picture = new Picture
            {
                IsMain = true,
                Name = "additives.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };


        #region Additives =>

        // Id = 80
        public static readonly Category Additives_DriedVegetablesAndSproutPowder = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "سبزی خشک و پودر جوانه",
            Type = CategoryType.Product,
            Parent = Additives,
            Picture = new Picture
            {
                IsMain = true,
                Name = "dried-vegetables-and-sprout-powder.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        // Id = 81
        public static readonly Category Additives_FoodDesign = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "زعفران، زرشک و تزئینات غذا",
            Type = CategoryType.Product,
            Parent = Additives,
            Picture = new Picture
            {
                IsMain = true,
                Name = "food-design.png",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        // Id = 82
        public static readonly Category Additives_LiquidCondiments = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "چاشنی‌های مایع",
            Type = CategoryType.Product,
            Parent = Additives,
            Picture = new Picture
            {
                IsMain = true,
                Name = "liquid-condiments.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        // Id = 83
        public static readonly Category Additives_Sauce = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "سس",
            Type = CategoryType.Product,
            Parent = Additives,
            Picture = new Picture
            {
                IsMain = true,
                Name = "sauce.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        // Id = 84
        public static readonly Category Additives_SpicesAndSeasonings = new Category
        {
            BaseEntity = new BaseEntity(true),
            Title = "ادویه و چاشنی",
            Type = CategoryType.Product,
            Parent = Additives,
            Picture = new Picture
            {
                IsMain = true,
                Name = "spices-and-seasonsings.jpg",
                SizeMB = (float)0.645,
                BaseEntity = new BaseEntity(true),
                Type = PictureType.Category,
            },
        };

        #endregion


        #endregion





        public static readonly List<Category> Categories = new List<Category>
        {
            BasicGoods,BasicGoods_Bread,BasicGoods_Candy,BasicGoods_Cereals,BasicGoods_Oil,BasicGoods_PastaAndNoodles,BasicGoods_Rice,BasicGoods_Sugar,
            Dairy, Dairy_BreakfastChocolate ,Dairy_Butter ,Dairy_Cheese ,Dairy_Cream ,Dairy_Dough ,Dairy_Honey ,Dairy_Jam ,Dairy_Milk ,Dairy_Yogurt,
            MeatAndProtein ,Proteins_Beef ,Proteins_BirdsEgg ,Proteins_Shrimp ,Proteins_Caviar ,Proteins_Checken ,Proteins_Fish ,Proteins_Sausages ,Proteins_SheapMeat,
            Beverages ,Beverages_Distillates ,Beverages_EnergyDrink ,Beverages_NonAlcoholicBeer ,Beverages_SoftDrink ,Beverages_SyrupAndJuice ,Beverages_Water,
            CannedFoodAndReadyMeals ,CannedFoodAndReadyMeals_CannedBeansAndVegetables ,CannedFoodAndReadyMeals_Compote ,CannedFoodAndReadyMeals_ReadyFood ,CannedFoodAndReadyMeals_SemiPreparedFood ,CannedFoodAndReadyMeals_TunnaFish,
            DriedFruitsAndSweets ,DriedFruitsAndSweets_Date ,DriedFruitsAndSweets_Dessert ,DriedFruitsAndSweets_DriedFruit ,DriedFruitsAndSweets_Nuts ,DriedFruitsAndSweets_Raisins ,DriedFruitsAndSweets_Sweet,
            Fruits,Vegetables,
            Snacks ,Snacks_BiscuitsAndWafers ,Snacks_CakesAndCookies ,Snacks_CandyAndToffee ,Snacks_ChewingGum ,Snacks_ChipsAndPopcorn ,Snacks_ChocolateAndCocoa ,Snacks_FlavoredSeedsAndKernels ,Snacks_GummiCandy ,Snacks_Lavashak ,Snacks_PuffsAndSnacks,
            WarmDrinks ,WarmDrinks_Cappuccino ,WarmDrinks_Coffee ,WarmDrinks_HerbalTea ,WarmDrinks_HotChocolate ,WarmDrinks_InstantCoffee ,WarmDrinks_Tea,
            FrozenProducts ,FrozenProducts_DoughAndBread ,FrozenProducts_FrozenFruit ,FrozenProducts_FrozenReadyFood ,FrozenProducts_FrozenVegetables ,FrozenProducts_SemiFrozenFood,
            Pickles ,Pickles_Olive ,Pickles_Pickle ,Pickles_PickledCucumber ,Pickles_Salty,
            Additives ,Additives_DriedVegetablesAndSproutPowder ,Additives_FoodDesign ,Additives_LiquidCondiments ,Additives_Sauce ,Additives_SpicesAndSeasonings,
        };

    }
}
