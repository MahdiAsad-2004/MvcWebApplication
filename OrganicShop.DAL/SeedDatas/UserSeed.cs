
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.Enums;

namespace OrganicShop.DAL.SeedDatas
{
    public static class UserSeed
    {
        public static string GeneratePhoneNumber()
        {
            return $"09{Random.Shared.Next(10, 40)}{Random.Shared.Next(100, 999)}{Random.Shared.Next(Random.Shared.Next(1000, 9999))}";
        }

        private static List<WishItem> GenerateWishItems()
        {
            List<WishItem> wishItems = new();
            HashSet<int> productIds = new HashSet<int>();
            for (int i = 1; i < Random.Shared.Next(1, 6); i++)
            {
                productIds.Add(Random.Shared.Next(1, ProductSeed.Products.Count + 1));
            }
            foreach (var productId in productIds)
            {
                wishItems.Add(new WishItem
                {
                    BaseEntity = new BaseEntity(true),
                    ProductId = productId,
                });
            }
            return wishItems;
        }

        private static List<Comment> GenerateComments()
        {
            List<Comment> comments = new();
            HashSet<int> productIds = new HashSet<int>();
            Comment? comment = null;
            for (int i = 1; i <= 5; i++)
            {
                productIds.Add(Random.Shared.Next(1, ProductSeed.Products.Count));
            }
            foreach (var productId in productIds)
            {
                comment = new Comment
                {
                    BaseEntity = new BaseEntity(true),
                    Rate = Random.Shared.Next(1, 6),
                    Text = new string(LoremIpsum.Take(Random.Shared.Next(50, 300)).ToArray()),
                    ProductId = productId,
                };
                switch (Random.Shared.Next(1, 4))
                {
                    case 1:
                        comment.Status = CommentStatus.Accepted;
                        break;

                    case 2:
                        comment.Status = CommentStatus.Accepted;
                        break;

                    case 3:
                        comment.Status = CommentStatus.Accepted;
                        break;

                    default:
                        throw new Exception();
                }
                comments.Add(comment);
            }
            return comments;
        }




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

            "کسرا" ,"کامیار" ,"کامران" ,"مهران" ,"مهراد" ,"مانی" ,"هومن" ,"همایون" ,"یاسین" ,"یزدان",
        };

        private static readonly List<string> Name_FirstNames_Woman = new List<string>
        {
            "آزاده" ,"اکرم" ,"آمنه" ,"ارغوان" ,"آرزو" ,"آوا" ,"بارانا" ,"بیتا" ,"بهاره" ,"بھناز" ,"پریسا" ,"پروانه" ,"پرنیان" ,"حورا" ,"حنا" ,"حمیرا" ,"دنیا" ,

            "دیبا" ,"دریا" ,"درسا" ,"روناک" ,"روژان" ,"رها" ,"رستا" ,"رونیکا" ,"صدف" ,"صحرا" ,"صبا" ,"عسل" ,"عاطفه" ,"هلما" ,"هدیه" ,"هلیا" ,"یاسمین" ,"یگانه" ,

            "فاطمه" ,"زهرا" ,"ریحانه" ,"هانیه" ,"دیانا" ,"مریم" ,"کیانا" ,"آیلین" ,"آتنا" ,"النا" ,"محیا" ,"مهسا" ,"نرگس" ,"سوگند" ,"پرنیا" ,"آیدا" ,"ملیکا" ,"یلدا" ,
        };


        private static string LoremIpsum = "لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ و با استفاده از طراحان گرافیک است. چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است و برای شرایط فعلی تکنولوژی مورد نیاز و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد. کتابهای زیادی در شصت و سه درصد گذشته، حال و آینده شناخت فراوان جامعه و متخصصان را می طلبد تا با نرم افزارها شناخت بیشتری را برای طراحان رایانه ای علی الخصوص طراحان خلاقی و فرهنگ پیشرو در زبان فارسی ایجاد کرد. در این صورت می توان امید داشت که تمام و دشواری موجود در ارائه راهکارها و شرایط سخت تایپ به پایان رسد وزمان مورد نیاز شامل حروفچینی دستاوردهای اصلی و جوابگوی سوالات پیوسته اهل دنیای موجود طراحی اساسا مورد استفاده قرار گیرد.";


        public static readonly User user = new User
        {
            Name = "",
            Email = "",
            PhoneNumber = GeneratePhoneNumber(),
            Password = "",
            Role = Domain.Enums.Role.Customer,
            BaseEntity = new BaseEntity(true),
            Addresses = new List<Address>
            {
                new Address
                {
                    BaseEntity = new BaseEntity(true),
                    PhoneNumber = GeneratePhoneNumber(),
                    PostCode = Random.Shared.NextInt64(1_000_000_000, 9_999_999_999).ToString(),
                    Province = (Province)Random.Shared.Next(1, 31 + 1),
                    ReceiverName = "",
                    Text = new string(LoremIpsum.Take(20).ToArray()),
                    Title = "",
                }
            },
            BankCards = new List<BankCard>
            {
                new BankCard
                {
                    BaseEntity = new BaseEntity(true),
                    Cvv2 = Random.Shared.Next(100, 10_000).ToString(),
                    ExpireDate = DateTime.Now.AddMonths(Random.Shared.Next(1, 30)),
                    Number = $"{Random.Shared.Next(5000, 7000)}-{Random.Shared.Next(1000, 10_000)}-{Random.Shared.Next(1000, 10_000)}-{Random.Shared.Next(1000, 10_000)}",
                    OwnerName = "",
                }
            },
            //Picture = new Picture
            //{
            //    BaseEntity = new BaseEntity(true),
            //    IsMain = true,
            //    Name = "",
            //    SizeMB
            //},
            WishItems = GenerateWishItems(),

        };









        public static List<User> RandomUsers()
        {
            List<User> users = new List<User>();
            User? user = null;
            string userFirstName = string.Empty;
            string userLastName = string.Empty;
            string userPassword = string.Empty;
            bool isMan = true;
            for (int i = 1; i <= 20; i++)
            {
                isMan = Random.Shared.Next(1, 6) > 2;
                userFirstName = isMan ?
                    Name_FirstNames_Man[Random.Shared.Next(0, Name_FirstNames_Man.Count)] :
                    Name_FirstNames_Woman[Random.Shared.Next(0, Name_FirstNames_Woman.Count)];
                userLastName = Name_LastNames[Random.Shared.Next(0, Name_LastNames.Count)];
                userPassword = $"user{Random.Shared.Next(1000, 10_000)}";
                user = new User()
                {
                    Name = $"{userFirstName} {userLastName}",
                    Email = $"{userPassword}@organicshop.ir",
                    Password = userPassword,
                    IsEmailVerified = false,
                    PhoneNumber = GeneratePhoneNumber(),
                    Role = Role.Customer,
                    BaseEntity = new BaseEntity(true),
                    Addresses = new List<Address>
                    {
                        new Address
                        {
                            Title = $"{userLastName} {userFirstName} آدرس",
                            BaseEntity = new BaseEntity(true),
                            PhoneNumber = GeneratePhoneNumber(),
                            PostCode = Random.Shared.NextInt64(1_000_000_000, 9_999_999_999).ToString(),
                            Province = (Province)Random.Shared.Next(1, 31 + 1),
                            ReceiverName = $"{userFirstName} {userLastName}",
                            Text = new string(LoremIpsum.Take(20).ToArray())
                        }
                    },
                    BankCards = new List<BankCard>
                    {
                        new BankCard
                        {
                            OwnerName = $"{userFirstName} {userLastName}",
                            BaseEntity = new BaseEntity(true),
                            Cvv2 = Random.Shared.Next(100, 10_000).ToString(),
                            ExpireDate = DateTime.Now.AddMonths(Random.Shared.Next(1, 30)),
                            Number = $"{Random.Shared.Next(5000, 7000)}-{Random.Shared.Next(1000, 10_000)}-{Random.Shared.Next(1000, 10_000)}-{Random.Shared.Next(1000, 10_000)}",
                        }
                    },
                    Picture = new Picture
                    {
                        BaseEntity = new BaseEntity(true),
                        IsMain = true,
                        Name = isMan ? $"man-{Random.Shared.Next(1, 60 + 1)}.jpg" : $"woman-{Random.Shared.Next(1, 50 + 1)}.jpg",
                        SizeMB = 0.5f,
                    },
                    WishItems = GenerateWishItems(),
                    Comments = GenerateComments(),
                };

                users.Add(user);

            }
            return users;
        }










    }
}
