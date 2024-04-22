﻿using MD.PersianDateTime;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Text;


namespace OrganicShop.BLL.Extensions
{
    public static class TextExtension
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

    }
}
