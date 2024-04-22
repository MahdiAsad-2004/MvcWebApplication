using Microsoft.AspNetCore.Http;
using OrganicShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.BLL.Extensions
{
    public static class EnumExtension
    {

        public static MyEnum[] GetArray<MyEnum>() where MyEnum : Enum
        {
            return Enum.GetValues(typeof(MyEnum)) as MyEnum[];
        }


        //public static Dictionary<string,long> GetArray(this Enum e)
        //{
        //    var dic = new Dictionary<string,long>();

        //    foreach (var item in Enum.GetValues(e.GetType()))
        //    {
        //        item.LogAsync();
        //    }

        //    return dic;
        //}
    }
}
