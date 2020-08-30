using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using YouTubeFinder.AzureLibrary.Infrastructure;

namespace YouTubeFinder.AzureLibrary.YouTube
{
    public class YouTubeClientFactory : IYouTubeClientFactory
    {
        private readonly YouTubeApiConfig _config;
        private YouTubeService _youTubeService;

        public YouTubeClientFactory(YouTubeApiConfig config)
        {
            _config = config;
        }

        public YouTubeService GetClient()
        {
            if (_youTubeService != null)
                return _youTubeService;

            _youTubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = _config.ApiKey,
                ApplicationName = _config.AppName,
            });

            return _youTubeService;
        }
    }
}
