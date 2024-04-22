using System.Text.Json;

namespace OrganicShop.Mvc.Models.Redirect
{
    public class Redirect
    {
        public string Url { get; set; }
        public bool IsReplace { get; set; }
        public int TimeOut { get; set; }


        public string GetJsonStrng()
        {
            return JsonSerializer.Serialize(this);
        }

    }



}

