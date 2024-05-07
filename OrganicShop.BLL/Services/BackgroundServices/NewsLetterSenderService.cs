using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using System.Threading.Channels;

namespace OrganicShop.BLL.Services.BackgroundServices
{
    public class NewsLetterSenderService : BackgroundService
    {
        #region ctor

        private readonly INewsLetterRepository _NewsLetterRepository;
        private readonly IBackgroundJobClient _BackgroundJobClient;
        public NewsLetterSenderService(INewsLetterRepository newsLetterRepository, IBackgroundJobClient backgroundJobClient)
        {
            _NewsLetterRepository = newsLetterRepository;
            _BackgroundJobClient = backgroundJobClient;
        }

        #endregion

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var newsLetters = await _NewsLetterRepository.GetQueryable()
                .Where(a => a.BaseEntity.IsActive && a.SendDate > DateTime.UtcNow)
                .ToListAsync();
            foreach (var newsLetter in newsLetters)
            {
                _BackgroundJobClient.Schedule(() => 
                    Console.WriteLine($"NewsLetter => Title: {newsLetter.Title} ---- SendDate: {newsLetter.SendDate.ToShortTimeString()}"), newsLetter.SendDate);
            }
            
        }
    }
}
