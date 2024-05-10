using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Models;
using OrganicShop.Domain.Response.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.IServices
{
    public interface IEmailSenderService
    {
        Task<bool> Send(string emailAddress, string subject, string bodyHtml);

        Task<bool> Send(string[] emailAddresss, string subject, string bodyHtml);

    }

}
