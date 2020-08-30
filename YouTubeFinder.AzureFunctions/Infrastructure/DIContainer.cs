using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YouTubeFinder.AzureLibrary.Infrastructure;

namespace YouTubeFinder.Infrastructure
{
    public sealed class DIContainer
    {
        private static readonly IServiceProvider _instance = Build();
        public static IServiceProvider Instance => _instance;

        static DIContainer()
        {

        }

        private DIContainer()
        {

        }

        private static IServiceProvider Build()
        {
            var services = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

         
            services.AddYouTubeService(configuration["YouTubeApiKey"], configuration["AppName"]);

            /*  services.AddSingleton(new EmailConfig(
                  host: configuration["EmailHost"
                  port: Convert.ToInt32(configuration["EmailPort"]),
                  sender: configuration["EmailSender"],
                  password: configuration["EmailPassword"]
                  ));
              services.AddSingleton<ISendEmailCommandHandler, SendEmailCommandHandler>();
              services.AddAzureQueueLibrary(configuration["AzureWebJobsStorage"]);
            */
            return services.BuildServiceProvider();
        }
    }
}
