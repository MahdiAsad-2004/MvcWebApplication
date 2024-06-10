using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.DAL.SeedDatas
{
    public class ProductSeed
    {
        public readonly Product p = new Product
        {
            Title = "",
            Price = 20_000,
            ShortDescription = "",
            Description = "",
            Categories = new List<Category> { },
            Pictures = new List<Picture>
            {
                new Picture
                {
                    IsMain = true,
                    Name = "",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
                new Picture
                {
                    IsMain = false,
                    Name = "",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
            },
            Properties = new List<Property>
            {
                new Property
                {
                    Value = "",
                    PropertyType = PropertyTypeSeed.Weight,
                },
                new Property
                {
                    Value = "",
                    PropertyType = PropertyTypeSeed.PackagingDimensions,
                },
                new Property
                {
                    Value = "",
                    PropertyType = PropertyTypeSeed.HealthLicenseNumber,
                },
                new Property
                {
                    Value = "",
                    PropertyType = PropertyTypeSeed.Ingredient,
                },
            },
            SoldCount = 0,
            Stock = Random.Shared.Next(0, 10),
            BaseEntity = new BaseEntity(true),
            BarCode = Guid.NewGuid().ToString().Substring(0, 13),
        };


        public readonly Product Bread = new Product
        {
            Title = "نان پیتا سه نان مقدار 370 گرم",
            SoldCount = 0,
            Stock = Random.Shared.Next(0, 10),
            BaseEntity = new BaseEntity(true),
            BarCode = Guid.NewGuid().ToString().Substring(0, 13),
            Categories = new List<Category> {CategorySeed.BasicGoods,CategorySeed.BasicGoods_Bread },
            ShortDescription = "نان پیتا محصولی از برند «سه نان» 300 گرم وزن دارد و محفظه‌ی نگهدارنده‌ی آن شفاف و پلاستیکی است. ارزش غذایی هر سهم نان پیتا سه نان برابر با 175 کیلوکالری انرژی، 4.25 گرم قند، 0.17 گرم نمک، 0.45 گرم چربی و 0.02 گرم اسیدهای چرب ترنس است. نان تست طلایی از ترکیب آرد گندم سبوس دار، آب، نمک، خمیرمایه و کره‌ی گیاهی تهیه شده است.",
            Description = "<div class=\"flex items-center grow\"><p class=\"grow text-h5 text-neutral-900\"><span class=\"relative\">معرفی برند سه نان</span></p></div><div class=\"mb-4\"><p class=\"text-body-1 text-neutral-800\">شرکت صنایع غذایی&nbsp;نامی نیک نهاد (سهامی خاص)&nbsp;تحت نام تجاری سه نان، با احداث کارخانه در شهرک صنعتی بهارستان در ۲۲ مهرماه ۱۳۸۷ به بهره برداری رسید. ماشین آلات این کارخانه از جدیدترین فناوری روز دنیا متعلق به شرکت Kaak هلند است و کاملاً مکانیزه، بدون دخالت دست، محصولات سالم، مرغوب با طعم و مزه مطبوع تولید می‌کند. سه نان با مخلوطی از آرد گندم های موجود که ویژگی‌های آن مورد تایید بخش غذایی گروه صنعتی (کاک) هلند است تهیه و تولید می‌شود. محصولات سه نان در فرهای مخصوص بدون تماس مستقیم با آتش پخت می‌شود. همچنین محصودلات سه نان پیش از بسته بندی توسط برج‌های خنک کننده به دمای مطلوب می‌رسد؛ در نتیجه این عمل، زمان ماندگاری سه نان زیاد بوده و به آسانی دچار کپک زدگی نمی‌شود.</p></div>",
            Pictures = new List<Picture>
            {
                new Picture
                {
                    IsMain = true,
                    Name = "bread-1-1.png",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
                new Picture
                {
                    IsMain = true,
                    Name = "bread-1-2.png",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
            },
            Price = 20_000,
            Properties = new List<Property>
            {
                new Property
                {
                    Value = "370 گرم",
                    PropertyType = PropertyTypeSeed.Weight,
                },
                new Property
                {
                    Value = "25 × 30 سانتی‌متر",
                    PropertyType = PropertyTypeSeed.PackagingDimensions,
                },
                new Property
                {
                    Value = "14654/125",
                    PropertyType = PropertyTypeSeed.HealthLicenseNumber,
                },
                new Property
                {
                    Value = "گندم",
                    PropertyType = PropertyTypeSeed.Ingredient,
                },
            },
        };

        public readonly Product Sugar = new Product
        {
            Title = "پودر شکر قنادی ضامن",
            Price = 35_500,
            ShortDescription = "شکر قنادی نوعی شکر مرغوب است که بیشتر برای لعاب روی شیرینی و تزئین کیک و پخت انواع كيك و شيريني بکار برده می‌شود. ¬¬¬¬این شکر که با نام پودر قنادی يا به اصلاح عاميانه پودر قند نیز شناخته می شود ، ریزترین فرم شکر سفید است و ذرات تشکیل دهنده آن از ریزترین الک هم عبور می کند. این نوع شکر در شیرینی پزی بسیار کاربرد دارد.",
            Description = "<p>شکر قنادی نوعی شکر مرغوب است که بیشتر برای لعاب روی شیرینی و تزئین کیک و پخت انواع كيك و شيريني بکار برده می‌شود. ¬¬¬¬این شکر که با نام پودر قنادی يا به اصلاح عاميانه پودر قند نیز شناخته می شود ، ریزترین فرم شکر سفید است و ذرات تشکیل دهنده آن از ریزترین الک هم عبور می کند. این نوع شکر در شیرینی پزی بسیار کاربرد دارد. برای تولید شیرینی های فشرده همچون شیرینی نخودچی ، همچنین خامه و کرم های مورد استفاده در قنادی که در عین شیرین بودن نباید ذرات شکر داخل آنها هنگام خوردن حس شوند ، استفاده می شود.</p>",
            Categories = new List<Category> { CategorySeed.BasicGoods , CategorySeed.BasicGoods_Sugar},
            Pictures = new List<Picture>
            {
                new Picture
                {
                    IsMain = true,
                    Name = "sugar-1-1.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
                new Picture
                {
                    IsMain = false,
                    Name = "sugar-1-2.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
                new Picture
                {
                    IsMain = false,
                    Name = "sugar-1-2.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
            },
            Properties = new List<Property>
            {
                new Property
                {
                    Value = "0.3 کیلوگرم",
                    PropertyType = PropertyTypeSeed.Weight,
                },
                new Property
                {
                    Value = "12×2×18 سانتی‌متر",
                    PropertyType = PropertyTypeSeed.PackagingDimensions,
                },
                new Property
                {
                    Value = "65465/1235",
                    PropertyType = PropertyTypeSeed.HealthLicenseNumber,
                },
            },
            SoldCount = 0,
            Stock = Random.Shared.Next(0, 10),
            BaseEntity = new BaseEntity(true),
            BarCode = Guid.NewGuid().ToString().Substring(0, 13),
        };

        public readonly Product RedBeans = new Product
        {
            Title = "لوبیا قرمز گلستان - 900 گرم",
            Price = 109_000,
            ShortDescription = "جدول ارزش غذایی در هر ۱۰۰ گرم: - انرژی: ۳۰۰ کیلوکالری - قند: ۲.۲ گرم - چربی: ۰.۸۲ گرم - نمک: ۰.۰۳ گرم - اسیدهای چرب ترانس: ۰ گرم ",
            Description = "",
            Categories = new List<Category> { CategorySeed.BasicGoods , CategorySeed.BasicGoods_Cereals},
            Pictures = new List<Picture>
            {
                new Picture
                {
                    IsMain = true,
                    Name = "beans-1-1.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
                new Picture
                {
                    IsMain = false,
                    Name = "beans-1-2.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                }
                ,new Picture
                {
                    IsMain = false,
                    Name = "beans-1-3.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
            },
            Properties = new List<Property>
            {
                new Property
                {
                    Value = "0.9 کیلوگرم",
                    PropertyType = PropertyTypeSeed.Weight,
                },
                new Property
                {
                    Value = "5 × 15 × 24 سانتی‌متر",
                    PropertyType = PropertyTypeSeed.PackagingDimensions,
                },
                new Property
                {
                    Value = "12545/15",
                    PropertyType = PropertyTypeSeed.HealthLicenseNumber,
                },
            },
            SoldCount = 0,
            Stock = Random.Shared.Next(0, 10),
            BaseEntity = new BaseEntity(true),
            BarCode = Guid.NewGuid().ToString().Substring(0, 13),
        };

        public readonly Product Macaroni = new Product
        {
            Title = "ماکارونی شلز زر ماکارون مقدار 500 گرم",
            Price = 28_000,
            ShortDescription = "ماکارونی غذای محبوبی میان بچه‌ها و بزر‌گترهاست و حتی دیدن آن هم اشتها را تحریک می‌کند. ماکارونی را به ده‌ها شکل و مدل درست می‌کنند و در واقع همه آن‌ها نوعی «پاستا» هستند که در اصطلاح خودمان به آن ماکارونی می‌گوییم. به سختی می‌توان به ته دیگ سیب زمینی ماکارونی نه گفت و حتی خود ماکارونی وقتی به صورت ته‌دیگ در می‌آید حسابی خوشمزه و ترد می‌شود. «زر ماکارون» یکی از تولید کنندگان مطرح ماکارونی و انواع پاستاست که در شکل و نوع محصولات خود تنوع زیادی به خرج داده است.",
            Description = "<div class=\"flex items-center grow\"><p class=\"grow text-h5\"><span class=\"relative\">زر ماکارون، با آرد سمولینا، برای همه</span></p></div><div class=\"mb-4\"><p class=\"text-body-1 text-neutral-800\">گروه صنعتی پژوهشی زر که در حال حاضر بزرگترین صادرکننده ایرانی انواع ماکارونی می‌‏باشد، در سکوی نخست صنعت ماکارونی ایران قرار گرفته و توانسته است با ایجاد فضای رقابتی در صنعت، به عنوان اولین تولیدکننده انواع ماکارونی و پاستا با آرد سمولینا در ایران، نقش مهمی را در ارتقاء کیفیت تولیدات داخلی به عهده بگیرد. به نحوی که هم اکنون محصولات ماکارونی ایران قادرند هم‌تراز با برندهای معتبر جهانی در رقابت‏‌های بین‏‌المللی موفق و سربلند وارد شوند. از سوی دیگر این گروه توانسته است با افزایش تعداد سیلوهای غلات خود، بالاترین توان ذخیره‏ سازی یکجا در کشور را کسب کرده و با راه‏ اندازی ۵ خط تولیدی آرد نیز در مقام نخست بیشترین ظرفیت تولید یکجا انواع آرد ایران قرار گیرد.</p></div>\r\n",
            Categories = new List<Category> {CategorySeed.BasicGoods , CategorySeed.BasicGoods_PastaAndNoodles},
            Pictures = new List<Picture>
            {
                new Picture
                {
                    IsMain = true,
                    Name = "macaroni-1-1.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
                new Picture
                {
                    IsMain = false,
                    Name = "macaroni-1-2.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
            },
            Properties = new List<Property>
            {
                new Property
                {
                    Value = "500 گرم",
                    PropertyType = PropertyTypeSeed.Weight,
                },
                new Property
                {
                    Value = "20x12x5 سانتی‌متر",
                    PropertyType = PropertyTypeSeed.PackagingDimensions,
                },
                new Property
                {
                    Value = "1654/123",
                    PropertyType = PropertyTypeSeed.HealthLicenseNumber,
                },
            },
            SoldCount = 0,
            Stock = Random.Shared.Next(0, 10),
            BaseEntity = new BaseEntity(true),
            BarCode = Guid.NewGuid().ToString().Substring(0, 13),
        };

        public readonly Product Oil = new Product
        {
            Title = "روغن مایع آفتابگردان لادن - 2.7 کیلوگرم",
            Price = 165_000,
            ShortDescription = "وغن مایع آفتابگردان حاوی ویتامین دی و ای لادن - 2.7 کیلوگرم روغن مایع آفتابگردان حاوی ویتامین دی و ای لادن - 2.7 کیلوگرم حاوی ویتامین دی و ای لادن است. ویتامین دی و ای لادن دو ماده مغذی مهم هستند که می‌توانند به سلامتی و زیبایی پوست کمک کنند. ویتامین دی معمولاً از طریق تابش نور خورشید به بدن ما وارد می‌شود و نقش مهمی در سلامت استخوان‌ها و سیستم ایمنی بدن دارد. ای لادن نیز یک آنتی اکسیدان قوی است که می‌تواند به پوست ما کمک کند و از آسیب‌های آزاد رادیکالی محافظت کند. وزن این محصول 2.7 کیلوگرم است.",
            Description = "<div class=\"flex items-center grow\"><p class=\"grow text-h5 \"><span class=\"relative\">روغن مایع آفتابگردان حاوی ویتامین دی و ای لادن</span></p></div><div class=\"mb-4\"><p class=\"text-body-1 text-neutral-800\">روغن مایع آفتابگردان حاوی ویتامین دی و ای لادن - 2.7 کیلوگرم روغن مایع آفتابگردان حاوی ویتامین دی و ای لادن - 2.7 کیلوگرم حاوی ویتامین دی و ای لادن است. ویتامین دی و ای لادن دو ماده مغذی مهم هستند که می‌توانند به سلامتی و زیبایی پوست کمک کنند. ویتامین دی معمولاً از طریق تابش نور خورشید به بدن ما وارد می‌شود و نقش مهمی در سلامت استخوان‌ها و سیستم ایمنی بدن دارد. ای لادن نیز یک آنتی اکسیدان قوی است که می‌تواند به پوست ما کمک کند و از آسیب‌های آزاد رادیکالی محافظت کند. وزن این محصول 2.7 کیلوگرم است. این روغن ممکن است برای استفاده در آشپزخانه یا حتی به عنوان روغن ماساژ مورد استفاده قرار گیرد. با توجه به حجم آن، این محصول به نظر می‌رسد که برای استفاده حرفه‌ای یا مصرف خانگی زیاد مناسب باشد. شرکت لادن یکی از برندهای معتبر در زمینه تولید انواع روغن‌های جامد، نیمه جامد و مایع است. این برند انواع مختلف روغن‌های خوراکی و سرخ‌کردنی را به حجم‌های بالا تولید و در بازار عرضه می‌کند. در سال‌های اولیه فعالیت خود، فقط در زمینه فروش روغن‌های جامد آفتابگردان فعالیت می‌کرد، اما با گذشت زمان محصولات خود را گسترش داده و در حال حاضر به عنوان یکی از بزرگترین تامین‌کنندگان انواع روغن‌های نباتی، مایع و گیاهی در کشور شناخته می‌شود. روغن یکی از اقلام غذایی ضروری در سبد خانوار است و سرانه مصرف آن در ایران بسیار بالا است. افراد زیادی به دنبال خرید روغن لادن هستند و بازار خرید و فروش عمده این محصول یکی از پرسودترین بازارها به شمار می‌رود. بسیاری از روغن‌های تولید شده برای مصارف خانگی و مابقی برای مصرف در رستوران‌ها، فست‌فودها و کافی‌شاپ‌ها در نظر گرفته می‌شود. برند روغن لادن در هفتمین جشنواره ملی برند محبوب به عنوان برند برتر در گروه روغن‌های غذایی و خوراکی شناخته شده است، که این امر به دلیل حمایت گسترده مصرف‌کنندگان در طی یک نظرسنجی صورت گرفته است. همچنین، برند لادن از گواهینامه‌ها و افتخارات زیر نیز برخوردار است: 1. دریافت گواهینامه مدیریت کیفیت ISO 9002 در سال ۱۳۷۵شمسی. 2. دریافت گواهینامه بین‌المللی کیفیت محصولات از شرکت SGS سوئیس در سال ۱۳۸۱شمسی. 3. دریافت مدیریت زیست محیطی ISO 14001 در سال ۱۳۸۲شمسی. 4. دریافت گواهینامه مدیریت ایمنی و بهداشت حرفه‌ای OHSAS 18001 در سال ۱۳۸۲شمسی. 5. انتخاب به عنوان واحد نمونه تولید و صادرات از طرف موسسه استاندارد و تحقیقات صنعتی ایران (ISIRI). این افتخارات و گواهینامه‌ها نشان‌دهنده تعهد و تلاش برند لادن در زمینه کیفیت، مدیریت زیست محیطی، ایمنی و بهداشت حرفه‌ای، و استانداردهای بین‌المللی است. انواع روغن لادن محصولات لادن به دسته‌های مختلفی تقسیم می‌شوند که شامل موارد زیر می‌شود: 1. کره گیاهی صبحانه: این نوع کره گیاهی برای استفاده در صبحانه و وعده‌های خوراکی خاصی طراحی شده است و معمولاً به عنوان یک جایگزین سالم برای کره و مارگارین حیوانی استفاده می‌شود. 2. کره گیاهی پخت و پز: این نوع کره گیاهی برای استفاده در پخت و پز و آشپزی مناسب است و معمولاً برای طعم دهی و افزودن چربی به غذاها استفاده می‌شود. 3. کره گیاهی پخت و پز زعفرانی: این نوع کره گیاهی حاوی زعفران است و برای افزودن طعم و رنگ به غذاها مناسب است.</p></div>\r\n",
            Categories = new List<Category> {CategorySeed.BasicGoods , CategorySeed.BasicGoods_Oil },
            Pictures = new List<Picture>
            {
                new Picture
                {
                    IsMain = true,
                    Name = "oil-1-1.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
                new Picture
                {
                    IsMain = false,
                    Name = "oil-1-2.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
                 new Picture
                {
                    IsMain = false,
                    Name = "oil-1-3.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
            },
            Properties = new List<Property>
            {
                new Property
                {
                    Value = "2.7 کیلوگرم",
                    PropertyType = PropertyTypeSeed.Weight,
                },
                new Property
                {
                    Value = "3 لیتر",
                    PropertyType = PropertyTypeSeed.Volume,
                },
                new Property
                {
                    Value = "15564/134",
                    PropertyType = PropertyTypeSeed.HealthLicenseNumber,
                },
                new Property
                {
                    Value = "بطری",
                    PropertyType = PropertyTypeSeed.PackageType,
                },
            },
            SoldCount = 0,
            Stock = Random.Shared.Next(0, 10),
            BaseEntity = new BaseEntity(true),
            BarCode = Guid.NewGuid().ToString().Substring(0, 13),
        };

        public readonly Product Rice = new Product
        {
            Title = "برنج طارم ممتاز گلستان - 10 کیلوگرم",
            Price = 1_400_000,
            ShortDescription = "طارم یکی از شهرهای شمالی استان زنجان است و به استان‌های گیلان ، قزوین و اردبیل نزدیک است . از جمله محصولاتی که در این شهر کاشته می‌شود، می‌توان به برنج اشاره کرد . البته روستای طارم سر هم در استان گیلان و در نزدیکی شهر کوچصفهان قرار دارد که شباهت اسمی با این منطقه دارد و البته محصول غالب این روستا نیز برنجش است.",
            Description = "<div class=\"flex items-center grow\"><p class=\"grow text-h5 \"><span class=\"relative\">برنج طارم ممتاز گلستان</span></p></div><div class=\"mb-4\"><p class=\"text-body-1 text-neutral-800\">نج طارم گلستان، محصولی ایرانی است که با توجه به کیفیت برتر، به علت داشتن مقدار مناسبی از پروتئین، فیبر، ویتامین‌ها و مواد معدنی، همواره بین مردم ایران محبوب بوده­است. این برنج ایرانی به­دلیل دارا بودن از طعم و عطری منحصر به­فرد، در بین سایر نمونه­های موجود دیگر برجسته است. لازم به ذکر است که برند گلستان تضمین می‌دهد کالای ارائه‌شده‌توسط این برند، اصل و بدون هیچ‌گونه افزودنی غیرطبیعی است. اطمینان از اصالت کالا، می‌تواند نگرانی‌های شما را از بابت خرید آنلاین آن برطرف کند.</p></div>\r\n",
            Categories = new List<Category> { CategorySeed.BasicGoods , CategorySeed.BasicGoods_Rice},
            Pictures = new List<Picture>
            {
                new Picture
                {
                    IsMain = true,
                    Name = "rice-1-1.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
                new Picture
                {
                    IsMain = false,
                    Name = "rice-1-2.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
            },
            Properties = new List<Property>
            {
                new Property
                {
                    Value = "10 کیلوگرم",
                    PropertyType = PropertyTypeSeed.Weight,
                },
                new Property
                {
                    Value = "سفید",
                    PropertyType = PropertyTypeSeed.RiceColor,
                },
                new Property
                {
                    Value = "1658/448",
                    PropertyType = PropertyTypeSeed.HealthLicenseNumber,
                },
                new Property
                {
                    Value = "دانه کامل",
                    PropertyType = PropertyTypeSeed.GrainSize,
                },
            },
            SoldCount = 0,
            Stock = Random.Shared.Next(0, 10),
            BaseEntity = new BaseEntity(true),
            BarCode = Guid.NewGuid().ToString().Substring(0, 13),
        };

        public readonly Product Nabaat = new Product
        {
            Title = "نبات نی دار زعفرانی بهرامن بسته 16 عددی",
            Price = 120_000,
            ShortDescription = "نبات زعفرانی ",
            Description = "",
            Categories = new List<Category> {CategorySeed.BasicGoods , CategorySeed.BasicGoods_Candy },
            Pictures = new List<Picture>
            {
                new Picture
                {
                    IsMain = true,
                    Name = "nabaat-1-1.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
            },
            Properties = new List<Property>
            {
                new Property
                {
                    Value = "0.256 کیلوگرم",
                    PropertyType = PropertyTypeSeed.Weight,
                },
                new Property
                {
                    Value = "2x18x20 سانتی‌متر",
                    PropertyType = PropertyTypeSeed.PackagingDimensions,
                },
                new Property
                {
                    Value = "5415/863",
                    PropertyType = PropertyTypeSeed.HealthLicenseNumber,
                },
            },
            SoldCount = 0,
            Stock = Random.Shared.Next(0, 10),
            BaseEntity = new BaseEntity(true),
            BarCode = Guid.NewGuid().ToString().Substring(0, 13),
        };

        public readonly Product Dessert = new Product
        {
            Title = "دسر شکلاتی دومینو مقدار 100 گرم",
            Price = 18_000,
            ShortDescription = "دسرهای آماده دومینو برای زمان‌هایی که مهمان سرزده دارید و یا دوست دارید یک میان وعده خوشمزه میل کنید انتخاب بسیار مناسبی است. شکلات، یکی از خوشمزه ترین خوراکی‌ها‌ی شیرین بین تمام گروه‌های سنی است. شرکت دومینو دسر شکلاتی دومینو را تولید کرده‌است که طرفداران زیادی دارد. ارزش غذایی در 100 گرم دسر شکلاتی دومینو برابر128 کیلوکالری انرژی، 18.11 گرم قند، 4 گرم چربی، 0.22 گرم نمک و 0.4 گرم اسیدهای چرب ترانس است.",
            Description = "<div class=\"flex items-center grow\"><p class=\"grow text-h5 \"><span class=\"relative\">تاریخچه دومینو</span></p></div><div class=\"mb-4\"><p class=\"text-body-1 text-neutral-800\">در سال 1390 شرکت لبنیات و بستنی دومینو با تجربه و تخصص سی ساله بنیانگذاران خود که تا قبل از تاسیس دومینو به عنوان یکی از بنیانگذاران و مالکان مجموعه لبنیات و بستنی میهن فعالیت می کردند، تاسیس گردید. دومینو با استفاده از مواد اولیه مرغوب، محصولات لبنی را تولید و به بازار عرضه کرده‌است. دومینو با در نظر گرفتن شعار \"طعمی نو\" تلاش دارد با بهره گیری از کلیه منابع ، استاندارد جدیدی از طعم و مزه و تنوع  محصولات را در صنعت لبنیات و بستنی ایجاد کند. دومینو با استفاده از مرغوب‌ترین مواد اولیه و تلفیق آن با قابلیت و خلاقیت کارشناسان این شرکت و توجه به ذائقه مصرف کنندگان، سبد گسترده و کاملی از انواع لبنیات و بستنی ایجاد کرده است. از اهداف مهم دومینو می‌توان به تمرکز روز ذائقه مصرف کنندگان، نوآوری و تولید محصولات جدید و ایجاد اشتغال مولد و سرمایه گذاری پایدار اشاره کرد. استفاده از لبنیات در سبد غذایی از اهمیت ویژه‌ای برخوردار است. با توجه به اهمیت ویژه لبنیات، ابتکار تولید لبنیات طعم‌دار مانند شیر و ماست‌های طعم‌دار برای تشویق افراد به مصرف لبنیات بسیار جالب و کاربردی است.</p></div>\r\n",
            Categories = new List<Category> { CategorySeed.Dairy , CategorySeed.DriedFruitsAndSweets_Dessert},
            Pictures = new List<Picture>
            {
                new Picture
                {
                    IsMain = true,
                    Name = "dessert-1-1.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
                new Picture
                {
                    IsMain = false,
                    Name = "dessert-1-2.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
            },
            Properties = new List<Property>
            {
                new Property
                {
                    Value = "100 گرم",
                    PropertyType = PropertyTypeSeed.Weight,
                },
                new Property
                {
                    Value = "6 × 5 × 4 سانتی‌متر",
                    PropertyType = PropertyTypeSeed.PackagingDimensions,
                },
                new Property
                {
                    Value = "4524/894",
                    PropertyType = PropertyTypeSeed.HealthLicenseNumber,
                },
                new Property
                {
                    Value = "کاکائو",
                    PropertyType = PropertyTypeSeed.Taste,
                },
            },
            SoldCount = 0,
            Stock = Random.Shared.Next(0, 10),
            BaseEntity = new BaseEntity(true),
            BarCode = Guid.NewGuid().ToString().Substring(0, 13),
        };
        
        public readonly Product Cheese = new Product
        {
            Title = "پنیر سفید ایرانی پگاه - 400 گرم",
            Price = 44_000,
            ShortDescription = "",
            Description = "",
            Categories = new List<Category> { },
            Pictures = new List<Picture>
            {
                new Picture
                {
                    IsMain = true,
                    Name = "cheese-1-1.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
                new Picture
                {
                    IsMain = false,
                    Name = "cheese-1-2.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                }
                ,new Picture
                {
                    IsMain = false,
                    Name = "cheese-1-3.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                }
                ,new Picture
                {
                    IsMain = false,
                    Name = "cheese-1-4.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
            },
            Properties = new List<Property>
            {
                new Property
                {
                    Value = "400 گرم",
                    PropertyType = PropertyTypeSeed.Weight,
                },
                new Property
                {
                    Value = "14×7×10 سانتی‌متر",
                    PropertyType = PropertyTypeSeed.PackagingDimensions,
                },
                new Property
                {
                    Value = "1816/864",
                    PropertyType = PropertyTypeSeed.HealthLicenseNumber,
                },
                new Property
                {
                    Value = "یخچال",
                    PropertyType = PropertyTypeSeed.MaintenanceMethod,
                },
                new Property
                {
                    Value = "ظرف پلاستیکی ",
                    PropertyType = PropertyTypeSeed.PackageType,
                },
            },
            SoldCount = 0,
            Stock = Random.Shared.Next(0, 10),
            BaseEntity = new BaseEntity(true),
            BarCode = Guid.NewGuid().ToString().Substring(0, 13),
        };

        public readonly Product Cream = new Product
        {
            Title = "خامه صباح - 200 میلی لیتر",
            Price = 32_000,
            ShortDescription = "خامه صباح - 200 میلی لیتر خامه صباح یک محصول لبنی است که معمولا به صورت روزانه مصرف می‌شود. این محصول دارای حجم ۲۰۰ میلی لیتر است و ویژگی‌های خاصی دارد که می‌تواند مصرف‌کننده را به خود جذب کند. خامه صباح دارای چربی متوسط است که برای افرادی که به دنبال محصولات با چربی کمتر هستند، مناسب است.",
            Description = "<div class=\"flex items-center grow\"><p class=\"grow text-h5 \"><span class=\"relative\">خامه صباح </span></p></div><div class=\"mb-4\"><p class=\"text-body-1 text-neutral-800\">خامه صباح - 200 میلی لیتر خامه صباح یک محصول لبنی است که معمولا به صورت روزانه مصرف می‌شود. این محصول دارای حجم ۲۰۰ میلی لیتر است و ویژگی‌های خاصی دارد که می‌تواند مصرف‌کننده را به خود جذب کند. خامه صباح دارای چربی متوسط است که برای افرادی که به دنبال محصولات با چربی کمتر هستند، مناسب است. خامه صباح، با حجم ۲۰۰ میلی لیتر، یک گزینه سالم برای افرادی است که علاقه‌مند به مصرف محصولات لبنی هستند. این محصول می‌تواند به عنوان یک گزینه مناسب و مورد توجه برای افرادی که به دنبال محصولات پر از املاح و مواد مغذی هستند، مطرح شود. خامه صباح با حجم ۲۰۰ میلی لیتری، یک منبع خوب از کلسیم و پروتئین برای سازمان‌هایی است که به دنبال تقویت استخوان‌ها و حفظ سلامتی استخوان‌های خود هستند. همچنین، این محصول می‌تواند به عنوان یک گزینه لذیذ و سرشار از انرژی برای صبحانه یا تنقلات بعد از ظهر مورد استفاده قرار گیرد. ویژگی‌های خامه صباح - ۲۰۰ میلی لیتر خامه صباح، یکی از محصولات لبنی است که با حجم ۲۰۰ میلی لیتر در بازار موجود است. این محصول یک نقش حیاتی در تهیه بسیاری از خوراکی‌ها و دسرها دارد. خامه صباح با بافت نرم و لذیذی که دارد، به عنوان یکی از مواد اصلی در تهیه انواع شیرینی‌ها مورد استفاده قرار می‌گیرد. این ماده خوراکی با طعم و عطر خوشمزه‌اش، به تهیه دسرهای مختلف مانند موس‌ها، کیک‌ها، پن‌کوتاه‌ها و… کمک می‌کند. همچنین، خامه صباح به عنوان یک افزودنی لذیذ و خوشمزه در قهوه‌ها و نوشیدنی‌های سرد مانند شیک‌ها و فرپها نیز استفاده می‌شود. با توجه به ویژگی‌های مطلوب خامه صباح و تاثیر آن در ارتقای طعم و بافت خوراکی‌ها، این محصول به عنوان یکی از مواد اصلی و اساسی در آشپزی و تهیه دسرها حائز اهمیت است. </p></div>\r\n",
            Categories = new List<Category> {CategorySeed.Dairy , CategorySeed.Dairy_Cream },
            Pictures = new List<Picture>
            {
                new Picture
                {
                    IsMain = true,
                    Name = "cream-1-1.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
                new Picture
                {
                    IsMain = false,
                    Name = "cream-1-2.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                }, 
                new Picture
                {
                    IsMain = false,
                    Name = "cream-1-3.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
            },
            Properties = new List<Property>
            {
                new Property
                {
                    Value = "210 گرم",
                    PropertyType = PropertyTypeSeed.Weight,
                },
                new Property
                {
                    Value = "12 × 3 × 4 سانتی‌متر",
                    PropertyType = PropertyTypeSeed.PackagingDimensions,
                },
                new Property
                {
                    Value = "5641/621",
                    PropertyType = PropertyTypeSeed.HealthLicenseNumber,
                },
                new Property
                {
                    Value = "",
                    PropertyType = PropertyTypeSeed.Ingredient,
                },
            },
            SoldCount = 0,
            Stock = Random.Shared.Next(0, 10),
            BaseEntity = new BaseEntity(true),
            BarCode = Guid.NewGuid().ToString().Substring(0, 13),
        };

        public readonly Product Dough = new Product
        {
            Title = "دوغ بدون گاز گرمادیده پگاه مقدار 2 لیتر",
            Price = 48_000,
            ShortDescription = "دوغ بدون گاز گرمادیده پگاه از ترکیب آب، ماست، نمک و گیاهان دارویی مختلف تهیه می‌شود. این نوشیدنی از مواد اولیه طبیعی و بدون افزودنی‌های مصنوعی تهیه می‌شود که به همین دلیل برای سلامتی بسیار مفید است.",
            Description = "<div class=\"flex items-center grow\"><p class=\"grow text-h5 \"><span class=\"relative\">دوغ بدون گاز گرمادیده پگاه</span></p></div<div class=\"mb-4\"><p class=\"text-body-1 text-neutral-800\">وغ بدون گاز گرمادیده پگاه از ترکیب آب، ماست، نمک و گیاهان دارویی مختلف تهیه می‌شود. این نوشیدنی از مواد اولیه طبیعی و بدون افزودنی‌های مصنوعی تهیه می‌شود که به همین دلیل برای سلامتی بسیار مفید است. یکی از موادی که به عنوان یکی از ترکیبات اصلی دوغ بدون گاز گرمادیده پگاه استفاده می‌شود، پونه است. پونه یک گیاه دارویی ست که خواص ضد التهابی، ضد عفونی کننده و ضد تشنجی دارد. مصرف پونه به عنوان یک ترکیبات دارویی در دوغ بدون گاز گرمادیده پگاه، می‌تواند به بهبود عملکرد گوارش و کاهش التهابات دستگاه گوارش کمک کند. نعنا نیز یکی دیگر از گیاهان دارویی است که در تهیه دوغ بدون گاز پگاه استفاده می‌شود. این گیاه دارای خواص ضد التهابی و ضد عفونی کننده است و می‌تواند به بهبود عملکرد گوارش و کاهش علائم ناشی از مشکلات گوارشی کمک کند. دوغ بدون گاز گرمادیده پگاه به صورت بطری عرضه می‌شود که این نوع بسته‌بندی به نگهداری و حمل و نقل آسان این نوشیدنی کمک می‌کند. همچنین بطری‌های دوغ پگاه قابل بازیافت هستند که از لحاظ محیط زیستی نیز بسیار مفید هستند. خواص دوغ بدون گاز دوغ یک نوشیدنی سنتی و محبوب در کشورهای مختلف است که از زمان های قدیم مورد استفاده قرار می گرفته است. این نوشیدنی از ترکیب شیر، محصولات لبنی و مواد غذایی دیگر تهیه می شود و خواص بسیاری برای سلامتی دارد. یکی از نوع دوغ ها که بوران دوغ نام دارد، دوغ بدون گاز است که خواص بسیاری برای سلامتی دارد. دوغ بدون گاز یک نوشیدنی خنک و ملایم است که از ترکیب شیر، محصولات لبنی و مواد طبیعی دیگر تهیه می شود.</p></div>\r\n",
            Categories = new List<Category> { CategorySeed.Dairy , CategorySeed.Dairy_Dough},
            Pictures = new List<Picture>
            {
                new Picture
                {
                    IsMain = true,
                    Name = "dough-1-1.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
                new Picture
                {
                    IsMain = false,
                    Name = "dough-1-2.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                }, 
                new Picture
                {
                    IsMain = false,
                    Name = "dough-1-3.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
            },
            Properties = new List<Property>
            {
                new Property
                {
                    Value = "2200 گرم",
                    PropertyType = PropertyTypeSeed.Weight,
                },
                new Property
                {
                    Value = "31 × 10 × 10 سانتی‌متر",
                    PropertyType = PropertyTypeSeed.PackagingDimensions,
                },
                new Property
                {
                    Value = "1645/931",
                    PropertyType = PropertyTypeSeed.HealthLicenseNumber,
                },
                new Property
                {
                    Value = "بطری",
                    PropertyType = PropertyTypeSeed.PackageType,
                },
            },
            SoldCount = 0,
            Stock = Random.Shared.Next(0, 10),
            BaseEntity = new BaseEntity(true),
            BarCode = Guid.NewGuid().ToString().Substring(0, 13),
        };

        public readonly Product Milk = new Product
        {
            Title = "شیر کم چرب پگاه - 946 میلی لیتر",
            Price = 25_000,
            ShortDescription = "شیر کم چرب پگاه - 946 میلی لیتر شیر کم چرب پگاه 946 میلی لیتر یک محصول لبنی محبوب است که از شیر گاو تهیه می‌شود و بسته‌بندی آن در بطری انجام شده است. شیر کم چرب به علت کنترل میزان چربی برای سلامت بسیار مفید بوده و افرادی که به دلایل مختلف رژیم غذایی خاصی را دنبال می‌کنند از این نوع شیر بیشتر استفاده می‌کنند. ",
            Description = "<div class=\"flex items-center grow\"><p class=\"grow text-h5 \"><span class=\"relative\">معرفی </span></p></div><div class=\"mb-4\"><p class=\"text-body-1 text-neutral-800\">شیر کم چرب پگاه - 946 میلی لیتر شیر کم چرب پگاه 946 میلی لیتر یک محصول لبنی محبوب است که از شیر گاو تهیه می‌شود و بسته‌بندی آن در بطری انجام شده است. شیر کم چرب به علت کنترل میزان چربی برای سلامت بسیار مفید بوده و افرادی که به دلایل مختلف رژیم غذایی خاصی را دنبال می‌کنند از این نوع شیر بیشتر استفاده می‌کنند. همچنین در برخی از دستورات غذایی و یا برای ساخت برخی از دسرها استفاده از شیر کم‌چرب عملکرد بهتری نشان داده است. در ادامه به بررسی این محصول با کیفیت از برند پگاه می‌پردازیم. نوع شیر و میزان چربی موجود در شیر این محصول لبنی از شیر گاو بوده و دارای مقدار کمی چربی است که به عنوان یک گزینه سالم و کم‌کالری برای مصرف‌کنندگان است. با این وجود، این شیر همچنان ارزش غذایی بالایی دارد و به عنوان یک منبع پروتئین و ویتامین برای رژیم غذایی افراد مناسب است. شیر کم چرب پگاه - ۹۴۶ میلی لیتر یک منبع عالی از کلسیم، پروتئین و ویتامین D است که بهبود سلامت استخوان‌ها و افزایش استحکام عضلات را تسهیل می‌کند. همچنین، مصرف این نوع شیر می‌تواند به کاهش خطر ابتلا به بیماری‌های مزمن مانند دیابت و بیماری‌های قلبی عروقی کمک کند.</p></div>\r\n",
            Categories = new List<Category> { CategorySeed.Dairy , CategorySeed.Dairy_Milk},
            Pictures = new List<Picture>
            {
                new Picture
                {
                    IsMain = true,
                    Name = "milk-1-1.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
                new Picture
                {
                    IsMain = false,
                    Name = "milk-1-2.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
            },
            Properties = new List<Property>
            {
                new Property
                {
                    Value = "0.964 لیتر",
                    PropertyType = PropertyTypeSeed.Volume,
                },
               
                new Property
                {
                    Value = "1349/451",
                    PropertyType = PropertyTypeSeed.HealthLicenseNumber,
                },
                new Property
                {
                    Value = "بطری",
                    PropertyType = PropertyTypeSeed.PackageType,
                },
            },
            SoldCount = 0,
            Stock = Random.Shared.Next(0, 10),
            BaseEntity = new BaseEntity(true),
            BarCode = Guid.NewGuid().ToString().Substring(0, 13),
        };

        public readonly Product Butter = new Product
        {
            Title = "کره حیوانی پاستوریزه میهن 50 گرم",
            Price = 16_000,
            ShortDescription = "کره حیوانی لاکتیکی بدون نمک ارزش غذایی در هر ۱۵ گرم: انرژی: ۱۱۲.۵ کیلو کالری",
            Description = "<div class=\"flex items-center grow\"><p class=\"grow text-h5 \"><span class=\"relative\">میهن؛ برند محبوب ملی</span></p></div><div class=\"mb-4\"><p class=\"text-body-1 text-neutral-800\">مجتمع صنایع غذایی میهن مجموعه ای ایرانی است که در سال ۱۳۵۴ تأسیس شد. این مجموعه یکی از بزرگ‌ترین تولیدکنندگان بستنی و لبنیات در کشور محسوب می‌شود که با نیروی انسانی بالغ بر ۱۹۰۰۰ نفر تا به امروز در این عرصه فعالیت دارند. تولیدات این شرکت شامل پنیر، کره، شیر، خامه ،ماست، دوغ و انواع بستنی و آبمیوه است، که علاوه بر پوشش بازار داخلی محصولات خود را به کشورهایی همچون عراق، کویت، امارات متحده عربی و جمهوری آذربایجان صادر می‌کنند.  در حال حاضر میهن با سه کارخانه بزرگ تولیدی بستنی و لبنیات مشغول به کار است و به فعالیت خود ادامه می‌دهد.</p></div>\r\n",
            Categories = new List<Category> { CategorySeed.Dairy , CategorySeed.Dairy_Butter},
            Pictures = new List<Picture>
            {
                new Picture
                {
                    IsMain = true,
                    Name = "butter-1-1.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
            },
            Properties = new List<Property>
            {
                new Property
                {
                    Value = "50 گرم",
                    PropertyType = PropertyTypeSeed.Weight,
                },
                new Property
                {
                    Value = "7 × 5 × 2 سانتی‌متر",
                    PropertyType = PropertyTypeSeed.PackagingDimensions,
                },
                new Property
                {
                    Value = "6542/983",
                    PropertyType = PropertyTypeSeed.HealthLicenseNumber,
                },
            },
            SoldCount = 0,
            Stock = Random.Shared.Next(0, 10),
            BaseEntity = new BaseEntity(true),
            BarCode = Guid.NewGuid().ToString().Substring(0, 13),
        };

        public readonly Product Yogurt = new Product
        {
            Title = "ماست همزده سبو هراز - 1800 گرم",
            Price = 103_000,
            ShortDescription = "ماست همزده سبو هراز - 1800 گرم ماست همزده سبو هراز با وزن ۱۸۰۰ گرم، یکی از محصولات با امتیاز بالا بین خریداران است که توسط دیجی‌کالا به بازار عرضه می‌شود. این محصول به دلیل کیفیت بالا و مزه لذیذ خود توانسته است توجه بسیاری از مصرف‌کنندگان را به خود جلب کند. ",
            Description = "<div class=\"flex items-center grow\"><p class=\"grow text-h5 \"><span class=\"relative\">معرفی</span></p></div><div class=\"mb-4\"><p class=\"text-body-1 text-neutral-800\">ماست همزده سبو هراز - 1800 گرم ماست همزده سبو هراز با وزن ۱۸۰۰ گرم، یکی از محصولات با امتیاز بالا بین خریداران است که توسط دیجی‌کالا به بازار عرضه می‌شود. این محصول به دلیل کیفیت بالا و مزه لذیذ خود توانسته است توجه بسیاری از مصرف‌کنندگان را به خود جلب کند. با توجه به تنوع و جذابیت این محصول، مصرف‌کنندگان بسیاری اقدام به خرید و استفاده از آن نموده‌اند. تولید و عرضه این محصول با استانداردهای بالا و به روش‌های بهداشتی انجام می‌شود تا اطمینان از بهره‌وری و سلامت مصرف‌کنندگان حاصل گردد. این محصول به عنوان یک گزینه عالی برای صبحانه یا سفره‌های خانوادگی محسوب می‌شود. تنوع در طعم و امکانات استفاده از این محصول، آن را به یک گزینه مناسب و محبوب در بین خریداران تبدیل کرده است.</p></div>\r\n",
            Categories = new List<Category> {CategorySeed.Dairy , CategorySeed.Dairy_Yogurt },
            Pictures = new List<Picture>
            {
                new Picture
                {
                    IsMain = true,
                    Name = "yogurt-1-1.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
                new Picture
                {
                    IsMain = false,
                    Name = "yogurt-1-2.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
                new Picture
                {
                    IsMain = false,
                    Name = "yogurt-1-3.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
            },
            Properties = new List<Property>
            {
                new Property
                {
                    Value = "1.8 کیلوگرم",
                    PropertyType = PropertyTypeSeed.Weight,
                },
                new Property
                {
                    Value = "18x9x9 سانتی‌متر",
                    PropertyType = PropertyTypeSeed.PackagingDimensions,
                },
                new Property
                {
                    Value = "1349/453",
                    PropertyType = PropertyTypeSeed.HealthLicenseNumber,
                },
                new Property
                {
                    Value = "سطل",
                    PropertyType = PropertyTypeSeed.Ingredient,
                },
            },
            SoldCount = 0,
            Stock = Random.Shared.Next(0, 10),
            BaseEntity = new BaseEntity(true),
            BarCode = Guid.NewGuid().ToString().Substring(0, 13),
        };

        public readonly Product Jam = new Product
        {
            Title = "مربا به اصالت - 820گرم",
            Price = 98_000,
            ShortDescription = "ارزش غذایی محصول در هر ۲۰ گرم: - انرژی: ۵۲.۴ کیلوکالری - قند: ۱۱.۶ گرم",
            Description = "",
            Categories = new List<Category> {CategorySeed.Dairy , CategorySeed.Dairy_Jam },
            Pictures = new List<Picture>
            {
                new Picture
                {
                    IsMain = true,
                    Name = "jam-1-1.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
                new Picture
                {
                    IsMain = false,
                    Name = "jam-1-2.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
                new Picture
                {
                    IsMain = false,
                    Name = "jam-1-3.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
            },
            Properties = new List<Property>
            {
                new Property
                {
                    Value = "820 گرم",
                    PropertyType = PropertyTypeSeed.Weight,
                },
                new Property
                {
                    Value = "16 × 5 × 5 سانتی‌متر",
                    PropertyType = PropertyTypeSeed.PackagingDimensions,
                },
                new Property
                {
                    Value = "4658/318",
                    PropertyType = PropertyTypeSeed.HealthLicenseNumber,
                },
            },
            SoldCount = 0,
            Stock = Random.Shared.Next(0, 10),
            BaseEntity = new BaseEntity(true),
            BarCode = Guid.NewGuid().ToString().Substring(0, 13),
        };

        public readonly Product Honey = new Product
        {
            Title = "عسل چهار گیاه ممتاز خوانسار - 1000 گرم",
            Price = 510_000,
            ShortDescription = "این عسل غالبا از از چهارگیاه مختلف ( گون زرد - یونجه - جعفری - گاپونه ) می باشد که به عسل چهار گیاه معروف است که فواید آن بیش از حد وصف است. عسل خوانسار، با معروفیت آن در سطح جهان، کیفیت و طبیعی بودن عسل هایش را برای شما هموطن عزیز تضمین مینماید.",
            Description = "<div class=\"flex items-center grow\"><p class=\"grow text-h5 \"><span class=\"relative\">معرفی</span></p></div><div class=\"mb-4\"><p class=\"text-body-1 text-neutral-800\">سابقه زنبور داری در ایران به بیش از 800 سال قبل از میلاد برمی گردد در دوران هخامنشیان نیز نگهداری از زنبور عسل مرسوم بوده است و مردم به جای شکر از عسل استفاده می کردند. شاید دلیل نبوغ ایرانیان در دنیا مصرف زیاد این ماده شگفت انگیز توسط نیاکان ما است :) این عسل غالبا از از چهارگیاه مختلف ( گون زرد - یونجه - جعفری - گاپونه ) می باشد که به عسل چهار گیاه معروف است که فواید آن بیش از حد وصف است. عسل خوانسار، با معروفیت آن در سطح جهان، کیفیت و طبیعی بودن عسل هایش را برای شما هموطن عزیز تضمین مینماید.</p></div>\r\n",
            Categories = new List<Category> {CategorySeed.Dairy , CategorySeed.Dairy_Honey },
            Pictures = new List<Picture>
            {
                new Picture
                {
                    IsMain = true,
                    Name = "honey-1-1.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
                new Picture
                {
                    IsMain = false,
                    Name = "honey-1-2.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
                new Picture
                {
                    IsMain = false,
                    Name = "honey-1-3.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
            },
            Properties = new List<Property>
            {
                new Property
                {
                    Value = "1000 گرم",
                    PropertyType = PropertyTypeSeed.Weight,
                },
                new Property
                {
                    Value = "39x28x۱14 سانتی‌متر",
                    PropertyType = PropertyTypeSeed.PackagingDimensions,
                },
                new Property
                {
                    Value = "1564/643",
                    PropertyType = PropertyTypeSeed.HealthLicenseNumber,
                },
            },
            SoldCount = 0,
            Stock = Random.Shared.Next(0, 10),
            BaseEntity = new BaseEntity(true),
            BarCode = Guid.NewGuid().ToString().Substring(0, 13),
        };

        public readonly Product BreakfastChocolate = new Product
        {
            Title = "کرم کاکائو فندقی فرمند - 200 گرم",
            Price = 130_000,
            ShortDescription = "«کرم کاکائوی فندقی فرمند» در هر 100 گرم حاوی 560 کیلوکالری انرژی، 52.6 گرم قند و 35 گرم چربی است. این کرم کاکائو حاوی 200 گرم شکلات فندقی هیجان‌انگیز برای کودکان و بزرگ‌سالان است که می‌توانند از آن لذت ببرند. قطعا صبحانه یکی از مهم ترین وعده های غذایی در طول روز محسوب میشود. پس بهتر است که هنگام صرف آن از مواد مقوی و خوشمزه استفاده کنیم.",
            Description = "<div class=\"flex items-center grow\"><p class=\"grow text-h5 \"><span class=\"relative\">فرمند، به شیرینی لبخند</span></p></div><div class=\"mb-4\"><p class=\"text-body-1 text-neutral-800\">فرمند نامی آشناست که بسیاری از جوان‌ها از کودکی با آن خاطره دارند. این برند که در اصل متعلق به شرکت شکلات پرند است، در زمینه‌ی تولید انواع شکلات، بیسکوییت و ویفر، ژله و دیگر تنقلات شیرین فعالیت می‌کند. فرمند محصولات خود را به بیش از 14 کشور جهان مانند امارات متحده عربی، ترکمنستان، بحرین، افریقای جنوبی، عراق، چین تایلند، روسیه و... صادر می‌کند. کارخانه‌ی شرکت شکلات پرند (فرمند) در زمینی با مساحت 70000 مترمربع واقع شده است و انواع شکلات، پودر دسر، پودر ژله، پودر کاکائو، قهوه، دراژه‌ و کرم کاکائو در این کارخانه تولید می‌شوند.</p></div>\r\n",
            Categories = new List<Category> { CategorySeed.Dairy , CategorySeed.Dairy_BreakfastChocolate},
            Pictures = new List<Picture>
            {
                new Picture
                {
                    IsMain = true,
                    Name = "breakfast-chocolate-1-1.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
                new Picture
                {
                    IsMain = false,
                    Name = "breakfast-chocolate-1-2.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
                new Picture
                {
                    IsMain = false,
                    Name = "breakfast-chocolate-1-3.jpg",
                    SizeMB = (float)0.550,
                    BaseEntity = new BaseEntity(true),
                    Type = PictureType.Product,
                },
            },
            Properties = new List<Property>
            {
                new Property
                {
                    Value = "200 گرم",
                    PropertyType = PropertyTypeSeed.Weight,
                },
                new Property
                {
                    Value = "7 × 8 × 6 سانتی‌متر",
                    PropertyType = PropertyTypeSeed.PackagingDimensions,
                },
                new Property
                {
                    Value = "1568/430",
                    PropertyType = PropertyTypeSeed.HealthLicenseNumber,
                },
            },
            SoldCount = 0,
            Stock = Random.Shared.Next(0, 10),
            BaseEntity = new BaseEntity(true),
            BarCode = Guid.NewGuid().ToString().Substring(0, 13),
        };









    }
}
