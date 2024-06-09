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
































    }
}
