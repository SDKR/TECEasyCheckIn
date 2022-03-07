using Core.DataInterfaces;
using Core.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Services
{
    public class CheckAndRemoveOldEntities : IHostedService, IDisposable
    {
        private readonly ILogger<CheckAndRemoveOldEntities> _logger;
        private Timer _timer;

        public CheckAndRemoveOldEntities(ILogger<CheckAndRemoveOldEntities> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            Services = serviceProvider;
        }

        public IServiceProvider Services { get; }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Checking for old entities Service running.");
            // last parameter is interval between runs
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(30));

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            _logger.LogInformation("Checking for old entities Service is working.");

            using (var scope = Services.CreateScope())
            {
                await CheckStudentCheckInsEntities(scope);
                //await CheckStudentEntities(scope);
            }
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Checking for old entities Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        private async Task CheckStudentCheckInsEntities(IServiceScope scope)
        {
            _logger.LogInformation("Checking for old StudentCheckIns.");

            var checkForOldEntitiesService =
                scope.ServiceProvider
                    .GetRequiredService<ICheckForOldEntities>();

            var oldStudentCheckIns =
                await checkForOldEntitiesService.GetOldStudentCheckInsEntities();

            if (oldStudentCheckIns != null && oldStudentCheckIns.Count != 0)
            {
                _logger.LogInformation("Found old StudentCheckIns, deleting now.");

                //checkForOldEntitiesService.DeleteOldEntities(oldStudentCheckIns);

                if (!await checkForOldEntitiesService.SaveAsync())
                    _logger.LogError("Error deleting old StudentCheckIns");
                else
                    _logger.LogInformation("StudentCheckIns deleted.");
            }
            else _logger.LogInformation("No old StudentCheckIns found.");
        }

        private async Task CheckStudentEntities(IServiceScope scope)
        {
            _logger.LogInformation("Checking for old Students.");

            var checkForOldEntitiesService =
                scope.ServiceProvider
                    .GetRequiredService<ICheckForOldEntities>();

            var oldStudents =
                await checkForOldEntitiesService.GetOldStudentEntities();

            if (oldStudents != null && oldStudents.Count != 0)
            {
                _logger.LogInformation("Found old Student, deleting now.");

                //checkForOldEntitiesService.DeleteOldEntities(oldStudents);

                if (!await checkForOldEntitiesService.SaveAsync())
                    _logger.LogError("Error deleting old Students");
                else
                    _logger.LogInformation("Students deleted.");
            }
            else _logger.LogInformation("No old Students found.");
        }
    }
}
