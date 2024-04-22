using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace OrganicShop.Mvc.Models.Toast
{
    public class Toast
    {
        public string Title { get; set; } = "";
        public string Text { get; set; } = "";
        public ToastType Type { get; set; } = ToastType.Success;
        public ToastPosition Position { get; set; } = ToastPosition.TopEnd;
        public int TimeMs { get; set; } = 6000;



        public Toast()
        {
                
        }
        public Toast(ToastType toastType, string text)
        {
            Type = toastType;
            Text = text;
            Title = GetTitle(toastType);
        }
        public Toast(ToastType toastType, string text, int timeMs)
        {
            Type = toastType;
            Text = text;
            TimeMs = timeMs;
            Title = GetTitle(toastType);
        }



        public void SetToastOnResponse(HttpResponse response)
        {
            var MessageJson = JsonSerializer.Serialize(this);
            response.Headers.Add("Message", MessageJson);
        }


        private string GetTitle(ToastType messageType)
        {
            switch (messageType)
            {
                case ToastType.Success:
                    return "موفق";
                case ToastType.Error:
                    return "خطا !";
                case ToastType.Warning:
                    return "هشدار";
                case ToastType.Info:
                    return "اطلاعات";
                case ToastType.Question:
                    return "پرسش";
                default:
                    return "";
            }
        }

        public static Toast GetToastFromTempData(object x)
        {
            if(x is string)
            {
                var jsonStr = x as string;
                return JsonSerializer.Deserialize<Toast>(jsonStr);
            }
            else if(x is Toast)
            {
                return x as Toast;
            }
            throw new Exception("Wrong Toast TempData");
        }



        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
    }

}

