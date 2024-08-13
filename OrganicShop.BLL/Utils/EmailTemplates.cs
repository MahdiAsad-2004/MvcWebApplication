using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace OrganicShop.BLL.Utils
{
    public class EmailTemplates
    {
    }







    public class VerifyEmailTemplate
    {

        public readonly string HtmlFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\email-templete\email-verification.html");

        private string Html { get; set; }

        public string UserName { get; set; }

        public string UrlVerify { get; set; }


        public VerifyEmailTemplate(string UserName, string UrlVerify)
        {
            this.UserName = UserName;
            this.UrlVerify = UrlVerify;
        }


        private async Task ReadHtmlFile()
        {
            this.Html = await File.ReadAllTextAsync(HtmlFilePath);
        }  

        private async Task ReplaeParams()
        {
            Html = Html.Replace("@Param.UserName", UserName);
            Html = Html.Replace("@Param.UrlVerify", UrlVerify);
        }


        public async Task<string> GetHtml()
        {
            await ReadHtmlFile();
            await ReplaeParams();
            return Html;
        }






    }



}
