
using MD.PersianDateTime;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.Enums;

namespace OrganicShop.DAL.SeedDatas
{
    public static class SellerSeed
    {
        public static string GeneratePhoneNumber()
        {
            return $"09{Random.Shared.Next(10, 40)}{Random.Shared.Next(100, 999)}{Random.Shared.Next(Random.Shared.Next(1000, 9999))}";
        }


        private static DateTime UserCreateDate = DateTime.Now;

        private static readonly List<string> Name_LastNames = new List<string>
        {
            "اربابی" ,"احدی" ,"آزادی" ,"آقایی" ,"اقبالی" ,"اعظمی" ,"اکبری" ,"آرمانی" ,"اسدی" ,"بانی" ,"براتی" ,"بهشتی" ,"بهرامی" ,"باقری" ,"پور محمدی" ,

            "پاکزاد" ,"پورحسین" ,"پناهی" ,"تاجیک" ,"تبریزی" ,"تیموری" ,"توحیدی" ,"جاویدی" ,"جوادی" ,"جواھری" ,"جهرمی" ,"جابری" ,"چنگیزی" ,"چمنی" ,"چمرانی" ,

            "حمیدی" ,"حیاتی" ,"حسینی" ,"حاتمی" ,"خمینی" ,"خطیبی" ,"خوانساری" ,"خوشبخت" , "خادم" ,"ریاحی" ,"رضایی" ,"رسایی" ,"رشیدی" ,"قنبری" ,"فدوی" ,"فتحی" ,

            "فرھادی","ضرغامی" ,"ضیاالدینی" ,"ضرابی" ,"ضیایی" ,"عباسی" ,"عبدی" ,"یعقوبی" ,"یاوری" ,"یاسینی" ,"نوروزی" ,"قادری" ,"قائدی" ,"قاصدی" ,"قاسمی" ,"فرخی" ,

            "غفوری" ,"غلام‌زاده" ,"غلامی" ,"غضنفری" ,"غفرانی" ,"نظری" ,"یادگاری" ,
        };

        private static readonly List<string> Name_FirstNames_Man = new List<string>
        {
            "بھنام" ,"بابک" ,"اصغر" ,"اشکان" ,"اردلان" ,"امیر" ,"احمد" ,"ایوب" ,"بیژن" ,"حمید" ,"حسین" ,"حسن" ,"حسام" ,"حامد" ,"پارسا" ,"پرھام" ,"پدرام" ,"پرویز" ,

            "داوود" ,"دانیال" ,"داریوش" ,"دارا" ,"رضا" ,"رهام" ,"رامین" ,"رامتین" ,"رامبد" ,"صدرا" ,"صالح" ,"صادق" ,"صابر" ,"عرفان" ,"عرشیا" ,"عباس" , "عارف" ,

            "کسرا" ,"کامیار" ,"کامران" ,"مهران" ,"مهراد" ,"مانی" ,"هومن" ,"همایون" ,"یاسین" ,"یکتا" ,"یزدان",
        };

        private static readonly List<string> Name_FirstNames_Woman = new List<string>
        {
            "آزاده" ,"اکرم" ,"آمنه" ,"ارغوان" ,"آرزو" ,"آوا" ,"بارانا" ,"بیتا" ,"بهاره" ,"بھناز" ,"پریسا" ,"پروانه" ,"پرنیان" ,"حورا" ,"حنا" ,"حمیرا" ,"دنیا" ,

            "دیبا" ,"دریا" ,"درسا" ,"روناک" ,"روژان" ,"رها" ,"رستا" ,"رونیکا" ,"صدف" ,"صحرا" ,"صبا" ,"عسل" ,"عاطفه" ,"هلما" ,"هدیه" ,"هلیا" ,"یاسمین" ,"یگانه" ,

            "فاطمه" ,"زهرا" ,"ریحانه" ,"هانیه" ,"دیانا" ,"مریم" ,"کیانا" ,"آیلین" ,"آتنا" ,"النا" ,"محیا" ,"مهسا" ,"نرگس" ,"سوگند" ,"پرنیا" ,"آیدا" ,"ملیکا" ,"یلدا" ,
        };


        private static string LoremIpsum = "لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است. چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد. کتابهای زیادی در شصت و سه درصد گذشته، حال و آینده شناخت فراوان جامعه و متخصصان را می طلبد تا با نرم افزارها شناخت بیشتری را برای طراحان رایانه ای علی الخصوص طراحان خلاقی و فرهنگ پیشرو در زبان فارسی ایجاد کرد. در این صورت می توان امید داشت که تمام و دشواری موجود در ارائه راهکارها و شرایط سخت تایپ به پایان رسد وزمان مورد نیاز شامل حروفچینی دستاوردهای اصلی و جوابگوی سوالات پیوسته اهل دنیای موجود طراحی اساسا مورد استفاده قرار گیرد.";

        private static List<string> Name_Sellers = new List<string>
        {
            "سیتی مارکت" ," کندو کده" ,"لوتوس" ," مارکت آنلاین" ," ستاره شهر" ,"آمیتیس" ,"نچرال فود" ,"آفتاب" ,"چهار فصل" ,"آپادانا" ,"سبلان" ,"مدرن استور" ,"" ,"" ,"" ,"" ,"" ,"" ,
        };


        private static User GetRandomUserForSeller()
        {
            User? user = null;
            bool isMan = Random.Shared.Next(1, 6) > 2;
            string userFirstName = isMan ?
                Name_FirstNames_Man[Random.Shared.Next(0, Name_FirstNames_Man.Count)] :
                Name_FirstNames_Woman[Random.Shared.Next(0, Name_FirstNames_Woman.Count)];
            string userLastName = Name_LastNames[Random.Shared.Next(0, Name_LastNames.Count)];
            string userPassword = $"user{Random.Shared.Next(1000, 10_000)}";
            DateTime userCreateDate = UserSeed.GetRandomPastDate();
            UserCreateDate = userCreateDate;
            user = new User()
            {
                Name = $"{userFirstName} {userLastName}",
                Password = userPassword,
                Email = $"{userPassword}@organicshop-seller.ir",
                IsEmailVerified = false,
                PhoneNumber = GeneratePhoneNumber(),
                Role = Role.Seller,
                BaseEntity = new BaseEntity(userCreateDate),
                Addresses = new List<Address>
                    {
                        new Address
                        {
                            Title = $"{userLastName} {userFirstName} آدرس",
                            BaseEntity = new BaseEntity(UserSeed.GetRandomDateAfter(userCreateDate)),
                            PhoneNumber = GeneratePhoneNumber(),
                            PostCode = Random.Shared.NextInt64(1_000_000_000, 9_999_999_999).ToString(),
                            Province = (Province)Random.Shared.Next(1, 31 + 1),
                            ReceiverName = $"{userFirstName} {userLastName}",
                            Text = new string(LoremIpsum.Take(20).ToArray()),
                        }
                    },
                BankCards = new List<BankCard>
                    {
                        new BankCard
                        {
                            OwnerName = $"{userFirstName} {userLastName}",
                            BaseEntity = new BaseEntity(UserSeed.GetRandomDateAfter(userCreateDate)),
                            Cvv2 = Random.Shared.Next(100, 10_000).ToString(),
                            ExpireDate = PersianDateTime.Now.AddMonths(Random.Shared.Next(1, 30)).ToString("yy/mm"),
                            Number = $"{Random.Shared.Next(5000, 7000)}-{Random.Shared.Next(1000, 10_000)}-{Random.Shared.Next(1000, 10_000)}-{Random.Shared.Next(1000, 10_000)}",
                        }
                    },
                Picture = new Picture
                {
                    BaseEntity = new BaseEntity(userCreateDate),
                    IsMain = true,
                    Name = isMan ? $"man-{Random.Shared.Next(1, 60 + 1)}.jpg" : $"woman-{Random.Shared.Next(1, 50 + 1)}",
                    SizeMB = 0.5f,
                    Type = PictureType.User,
                },

            };


            return user;
        }






        public static Seller CityMarket = new Seller
        {
            Title = "سیتی مارکت",
            User = GetRandomUserForSeller(),
            Description = LoremIpsum,
            BaseEntity = new BaseEntity(true),
            Picture = new Picture
            {
                Name = "city-market.jpg",
                SizeMB = 0.5f,
                Type = PictureType.Seller,
                IsMain = true,
                BaseEntity = new BaseEntity(UserSeed.GetRandomDateAfter(UserCreateDate)),
            },
            Address = new Address
            {
                Title = "آدرس سیتی مارکت",
                Text = "تهران، بزرگراه امام علی، خیابان شهید مدنی جنوبی",
                Province = Province.Tehran,
                ReceiverName = string.Empty,
                BaseEntity = new BaseEntity(true),
                PhoneNumber = GeneratePhoneNumber(),
                PostCode = Random.Shared.NextInt64(1_000_000_000, 9_999_999_999).ToString(),
            },
        };

        public static Seller KandooKadeh = new Seller
        {
            Title = "فروشگاه کندو کده",
            User = GetRandomUserForSeller(),
            Description = LoremIpsum,
            BaseEntity = new BaseEntity(true),
            Picture = new Picture
            {
                Name = "kandoo-kadeh.png",
                SizeMB = 0.5f,
                Type = PictureType.Seller,
                IsMain = true,
                BaseEntity = new BaseEntity(UserSeed.GetRandomDateAfter(UserCreateDate)),
            },
            Address = new Address
            {
                Title = "آدرس فروشگاه کندو کده",
                Text = "آذربایجان غربی , ارومیه، انتهای خیابان سعدی ۲، میدان طریقت",
                Province = Province.AzarbayjanGharbi,
                ReceiverName = string.Empty,
                BaseEntity = new BaseEntity(true),
                PhoneNumber = GeneratePhoneNumber(),
                PostCode = Random.Shared.NextInt64(1_000_000_000, 9_999_999_999).ToString(),
            },
        };

        public static Seller MarketOnline = new Seller
        {
            Title = "مارکت آنلاین",
            User = GetRandomUserForSeller(),
            Description = LoremIpsum,
            BaseEntity = new BaseEntity(true),
            Picture = new Picture
            {
                Name = "market-online.jpg",
                SizeMB = 0.5f,
                Type = PictureType.Seller,
                IsMain = true,
                BaseEntity = new BaseEntity(UserSeed.GetRandomDateAfter(UserCreateDate)),
            },
            Address = new Address
            {
                Title = "آدرس مارکت آنلاین",
                Text = "تهران، تهران‌پارس، تقاطع اشراق (فلکه دوم)، خیابان حج",
                Province = Province.Tehran,
                ReceiverName = string.Empty,
                BaseEntity = new BaseEntity(true),
                PhoneNumber = GeneratePhoneNumber(),
                PostCode = Random.Shared.NextInt64(1_000_000_000, 9_999_999_999).ToString(),
            },
        };

        public static Seller Lotus = new Seller
        {
            Title = "فروشگاه لوتوس",
            User = GetRandomUserForSeller(),
            Description = LoremIpsum,
            BaseEntity = new BaseEntity(true),
            Picture = new Picture
            {
                Name = "lotus.jpg",
                SizeMB = 0.5f,
                Type = PictureType.Seller,
                IsMain = true,
                BaseEntity = new BaseEntity(UserSeed.GetRandomDateAfter(UserCreateDate)),
            },
            Address = new Address
            {
                Title = "آدرس فروشگاه لوتوس",
                Text = "البرز , کرج، میدان آزادگان – خیابان برغان",
                Province = Province.Alborz,
                ReceiverName = string.Empty,
                BaseEntity = new BaseEntity(true),
                PhoneNumber = GeneratePhoneNumber(),
                PostCode = Random.Shared.NextInt64(1_000_000_000, 9_999_999_999).ToString(),
            },
        };

        public static Seller SetareShahr = new Seller
        {
            Title = "فروشگاه ستاره شهر",
            User = GetRandomUserForSeller(),
            Description = LoremIpsum,
            BaseEntity = new BaseEntity(true),
            Picture = new Picture
            {
                Name = "setare-shahr.png",
                SizeMB = 0.5f,
                Type = PictureType.Seller,
                IsMain = true,
                BaseEntity = new BaseEntity(UserSeed.GetRandomDateAfter(UserCreateDate)),
            },
            Address = new Address
            {
                Title = "آدرس فروشگاه ستاره شهر",
                Text = "صفهان، خیابان گلستان، خیابان هسا، ابتدای سعدی شرقی",
                Province = Province.Esfahan,
                ReceiverName = string.Empty,
                BaseEntity = new BaseEntity(true),
                PhoneNumber = GeneratePhoneNumber(),
                PostCode = Random.Shared.NextInt64(1_000_000_000, 9_999_999_999).ToString(),
            },
        };

        public static Seller Apadana = new Seller
        {
            Title = "فروشگاه آپادانا",
            User = GetRandomUserForSeller(),
            Description = LoremIpsum,
            BaseEntity = new BaseEntity(true),
            Picture = new Picture
            {
                Name = "apadana.jpg",
                SizeMB = 0.5f,
                Type = PictureType.Seller,
                IsMain = true,
                BaseEntity = new BaseEntity(UserSeed.GetRandomDateAfter(UserCreateDate)),
            },
            Address = new Address
            {
                Title = "آدرس فروشگاه آپادانا",
                Text = "فارس , شیراز، جاده سپیدان، روبروی شهرک گلستان",
                Province = Province.Fars,
                ReceiverName = string.Empty,
                BaseEntity = new BaseEntity(true),
                PhoneNumber = GeneratePhoneNumber(),
                PostCode = Random.Shared.NextInt64(1_000_000_000, 9_999_999_999).ToString(),
            },
        };

        public static Seller Aftab = new Seller
        {
            Title = "فروشگاه آفتاب",
            User = GetRandomUserForSeller(),
            Description = LoremIpsum,
            BaseEntity = new BaseEntity(true),
            Picture = new Picture
            {
                Name = "aftab.jpg",
                SizeMB = 0.5f,
                Type = PictureType.Seller,
                IsMain = true,
                BaseEntity = new BaseEntity(UserSeed.GetRandomDateAfter(UserCreateDate)),
            },
            Address = new Address
            {
                Title = "آدرس فروشگاه آفتاب",
                Text = "قم، بلوار الغدیر،",
                Province = Province.Qom,
                ReceiverName = string.Empty,
                BaseEntity = new BaseEntity(true),
                PhoneNumber = GeneratePhoneNumber(),
                PostCode = Random.Shared.NextInt64(1_000_000_000, 9_999_999_999).ToString(),
            },
        };

        public static Seller Amitis = new Seller
        {
            Title = "فروشگاه آمیتیس",
            User = GetRandomUserForSeller(),
            Description = LoremIpsum,
            BaseEntity = new BaseEntity(true),
            Picture = new Picture
            {
                Name = "amitis.png",
                SizeMB = 0.5f,
                Type = PictureType.Seller,
                IsMain = true,
                BaseEntity = new BaseEntity(UserSeed.GetRandomDateAfter(UserCreateDate)),
            },
            Address = new Address
            {
                Title = "آدرس فروشگاه آمیتیس",
                Text = "مازندران , ساری , بلوار طالقانی",
                Province = Province.Mazandaran,
                ReceiverName = string.Empty,
                BaseEntity = new BaseEntity(true),
                PhoneNumber = GeneratePhoneNumber(),
                PostCode = Random.Shared.NextInt64(1_000_000_000, 9_999_999_999).ToString(),
            },
        };

        public static Seller ModernStore = new Seller
        {
            Title = "مدرن استور",
            User = GetRandomUserForSeller(),
            Description = LoremIpsum,
            BaseEntity = new BaseEntity(true),
            Picture = new Picture
            {
                Name = "modern-store.jpg",
                SizeMB = 0.5f,
                Type = PictureType.Seller,
                IsMain = true,
                BaseEntity = new BaseEntity(UserSeed.GetRandomDateAfter(UserCreateDate)),
            },
            Address = new Address
            {
                Title = "آدرس مدرن استور",
                Text = "خوزستان , اهواز، جاده ساحلی",
                Province = Province.Khoozestan,
                ReceiverName = string.Empty,
                BaseEntity = new BaseEntity(true),
                PhoneNumber = GeneratePhoneNumber(),
                PostCode = Random.Shared.NextInt64(1_000_000_000, 9_999_999_999).ToString(),
            },
        };

        public static Seller Sabalan = new Seller
        {
            Title = "فروشگاه سبلان",
            User = GetRandomUserForSeller(),
            Description = LoremIpsum,
            BaseEntity = new BaseEntity(true),
            Picture = new Picture
            {
                Name = "sabalan.jpg",
                SizeMB = 0.5f,
                Type = PictureType.Seller,
                IsMain = true,
                BaseEntity = new BaseEntity(UserSeed.GetRandomDateAfter(UserCreateDate)),
            },
            Address = new Address
            {
                Title = "آدرس فروشگاه سبلان",
                Text = "آذربایجان شرقی , تبریز , چهار راه قره باغی",
                Province = Province.AzarbayjanSharghi,
                ReceiverName = string.Empty,
                BaseEntity = new BaseEntity(true),
                PhoneNumber = GeneratePhoneNumber(),
                PostCode = Random.Shared.NextInt64(1_000_000_000, 9_999_999_999).ToString(),
            },
        };












        public static readonly List<Seller> Sellers = new List<Seller>
        {
            CityMarket ,KandooKadeh ,MarketOnline ,Lotus ,SetareShahr ,Apadana ,Aftab ,Amitis ,ModernStore ,Sabalan,
        };


    }
}
