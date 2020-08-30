using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using YouTubeFinder.AzureLibrary.YouTube;

namespace YouTubeFinder.AzureLibrary.Infrastructure
{
    public static class DependencyInjectionRegistry
    {
        public static IServiceCollection AddYouTubeService(this IServiceCollection service, string youTubeApiKey, string appName)
        {
            service.AddSingleton(new YouTubeApiConfig(youTubeApiKey, appName));
            service.AddSingleton<IYouTubeClientFactory, YouTubeClientFactory>();
            service.AddSingleton<IYouTubeVideoFinder, YouTubeVideoFinder>();
            return service;
        }
    }
}
