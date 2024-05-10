using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using OrganicShop.BLL.Utily;
using OrganicShop.Domain.IServices;

namespace OrganicShop.BLL.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        #region ctor

        private readonly EmailSetting _emailSetting;
        public EmailSenderService(IOptions<EmailSetting> options)
        {
            _emailSetting = options.Value;
        }

        #endregion

        public async Task<bool> Send(string emailAddress , string subject , string bodyHtml)
        {
            //await Console.Out.WriteLineAsync($"Email Setting: {_emailSetting.EmailAddress} ------------ {_emailSetting.Password}");
            //return true;

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_emailSetting.EmailAddress));
            email.To.Add(MailboxAddress.Parse(emailAddress));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = bodyHtml };

            try
            {
                using (var smptClient = new MailKit.Net.Smtp.SmtpClient())
                {
                    smptClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.Auto);
                    // ========>>>>> 587 with Tls && 465 with ssl 

                    smptClient.Authenticate("ShopProviderr@gmail.com", "qrir ajfm ylpe esru");
                    await smptClient.SendAsync(email);
                    smptClient.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"An exception thrown while sendig email ....");
                await Console.Out.WriteLineAsync(ex.Message);
                return false;
            }
            return true;
        }


        public async Task<bool> Send(string[] emailAddresss, string subject, string bodyHtml)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_emailSetting.EmailAddress));
            foreach (var emailAddress in emailAddresss)
            {
                email.To.Add(MailboxAddress.Parse(emailAddress));
            }
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = bodyHtml };
            try
            {
                using (var smptClient = new MailKit.Net.Smtp.SmtpClient())
                {
                    smptClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.Auto);
                    // ========>>>>> 587 with Tls && 465 with ssl 

                    smptClient.Authenticate("ShopProviderr@gmail.com", "qrir ajfm ylpe esru");
                    await smptClient.SendAsync(email);
                    smptClient.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"An exception thrown while sendig email ....");
                await Console.Out.WriteLineAsync(ex.Message);
                return false;
            }
            return true;
        }
    }
}
