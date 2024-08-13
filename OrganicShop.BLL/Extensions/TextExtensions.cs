using DryIoc.FastExpressionCompiler.LightExpression;
using MD.PersianDateTime;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Text;
using System.Web;
using System.Security.Cryptography;



namespace OrganicShop.BLL.Extensions
{
    public static class TextExtensions
    {
        public static string ToText(this string text)
        {
            return text.Trim().ToLower();
        }


        public static string ToToman(this string price)
        {
            return $"{price.ToMoney()} تومان";
        }


        public static string ToToman(this int price)
        {
            return $"{price.ToMoney()} تومان";
        }




        public static string ToMoney(this string price)
        {
            char[] priceArray = price.ToCharArray();
            StringBuilder toman = new StringBuilder();
            for (int i = 0; i < priceArray.Length; i++)
            {
                toman.Append(priceArray[i]);
                if (i == priceArray.Length - 4 || i == priceArray.Length - 7 || i == priceArray.Length - 10 || i == priceArray.Length - 13 || i == priceArray.Length - 16)
                {
                    toman.Append(",");
                }
            }
            return toman.ToString();
        }
        public static string ToMoney(this int price)
        {
            char[] priceArray = price.ToString().ToCharArray();
            StringBuilder toman = new StringBuilder();
            for (int i = 0; i < priceArray.Length; i++)
            {
                toman.Append(priceArray[i]);
                if (i == priceArray.Length - 4 || i == priceArray.Length - 7 || i == priceArray.Length - 10 || i == priceArray.Length - 13 || i == priceArray.Length - 16)
                {
                    toman.Append(",");
                }
            }
            return toman.ToString();
        }


        public static PersianDateTime ToPersianDate(this DateTime dateTime)
        {
            return new PersianDateTime(dateTime);
        }
        
        public static PersianDateTime NewPersianDate(int year , int month , int day)
        {
            return new PersianDateTime(year,month,day);
        }
        
        public static PersianDateTime ToPersianDate(this DateTime? dateTime)
        {
            return new PersianDateTime(dateTime);
        }




        public static string LogString<T>(this T obj)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Console.WriteLine($"{typeof(T).Name}:");
            foreach (var prop in typeof(T).GetProperties())
            {
                stringBuilder.AppendLine($"\t{prop.Name}: {prop.GetValue(obj)}");
            }
            return stringBuilder.ToString();
        }

        public static async void LogAsync<T>(this T obj)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Console.WriteLine($"{typeof(T).Name}:");
            foreach (var prop in typeof(T).GetProperties())
            {
                stringBuilder.AppendLine($"\t{prop.Name}: {prop.GetValue(obj)}");
            }
            await Console.Out.WriteLineAsync(stringBuilder.ToString());
        }


        public static void Log<T>(this T obj)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Console.WriteLine($"{typeof(T).Name}:");
            foreach (var prop in typeof(T).GetProperties())
            {
                stringBuilder.AppendLine($"\t{prop.Name}: {prop.GetValue(obj)}");
            }
            Console.Out.WriteLine(stringBuilder.ToString());
        }

        public static string ToSize(this float sizeMb)
        {
            if (sizeMb < 1)
                return $"{(sizeMb * 1000).ToString("0.00")} KB";
            else
                return $"{(sizeMb).ToString("0.00")} MB";
        }


        public static string EncodeUrlString(string str)
        {
            return HttpUtility.UrlEncode(str.Trim().Replace(" ", "-"), Encoding.UTF8).Replace("+", "-");
            //return HttpUtility.UrlEncode(str.Trim().Replace(" ", "-"), Encoding.UTF8);
        }

        public static string EncodeUrl(this string str)
        {
            return HttpUtility.UrlEncode(str.Trim().Replace(" ", "-"), Encoding.UTF8).Replace("+", "-");
        }

        public static string DecodeUrlString(string codedSttring)
        {
            try
            {
                return HttpUtility.UrlDecode(codedSttring, Encoding.UTF8).Replace("+", "-").Replace("-", " ");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"error in DecodePersianString()");
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }
        public static string DecodeUrl(this string codedSttring)
        {
            try
            {
                return HttpUtility.UrlDecode(codedSttring, Encoding.UTF8).Replace("+", "-").Replace("-", " ");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"error in DecodePersianString()");
                Console.WriteLine(ex.Message);
                return string.Empty;
            }
        }



        public static string GenerateProductBarcode()
        {
            return Guid.NewGuid().ToString().Substring(0, 13);
        }






        private static byte[] GetHash(this string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }



        public static string ToSha256String(this string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }



    }
}
