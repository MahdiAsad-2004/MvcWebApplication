using DryIoc.Microsoft.DependencyInjection;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrganicShop.DAL.Context;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using System.Threading.Channels;

namespace OrganicShop.BLL.Services.BackgroundServices
{
    public class NewsLetterSenderServiceBackground : BackgroundService
    {
        #region ctor

        private readonly IBackgroundJobClient _BackgroundJobClient;
        private readonly IServiceScopeFactory _ServiceScopeFactory;
        private INewsLetterRepository _NewsLetterRepository;
        private INewsLetterMemberRepository _NewsLetterMemberRepository;
        private IEmailSenderService _EmailSenderService;
        //private readonly OrganicShopDbContext _DbContext;
        //private DryIocServiceScopeFactory _DryIocServiceScopeFactory;

        public NewsLetterSenderServiceBackground(IBackgroundJobClient backgroundJobClient, IServiceScopeFactory serviceScopeFactory)
        {
            _BackgroundJobClient = backgroundJobClient;
            _ServiceScopeFactory = serviceScopeFactory;
        }

        #endregion

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string[] newsLetterMembersEmails;
            List<NewsLetter> newsLetters;
            using (var scope = _ServiceScopeFactory.CreateScope())
            {
                _EmailSenderService = scope.ServiceProvider.GetRequiredService<IEmailSenderService>();
                _NewsLetterRepository = scope.ServiceProvider.GetRequiredService<INewsLetterRepository>();
                _NewsLetterMemberRepository = scope.ServiceProvider.GetRequiredService<INewsLetterMemberRepository>();
                //_EmailSenderService = scope.ServiceProvider.GetRequiredService<IEmailSenderService>();
                newsLetters = await _NewsLetterRepository.GetQueryable()
                    .Where(a => a.BaseEntity.IsActive && a.SendDate > DateTime.UtcNow)
                    .ToListAsync();
                newsLetterMembersEmails = await _NewsLetterMemberRepository.GetQueryable()
                    .Where(a => a.BaseEntity.IsActive)
                    .Select(a => a.Email)
                    .ToArrayAsync();

                foreach (var newsLetter in newsLetters)
                {
                    _BackgroundJobClient.Schedule(() =>
                        Console.WriteLine($"NewsLetter => Title: {newsLetter.Title} ---- SendDate: {newsLetter.SendDate.ToShortTimeString()}"), newsLetter.SendDate);

                    //_BackgroundJobClient.Schedule(() => _EmailSenderService.Send(newsLetterMembersEmails, newsLetter.Title, newsLetter.Content), newsLetter.SendDate);
                }
            }

        }

    }
}
