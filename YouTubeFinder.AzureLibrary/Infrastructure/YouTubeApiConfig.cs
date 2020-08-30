using System;
using System.Collections.Generic;
using System.Text;

namespace YouTubeFinder.AzureLibrary.Infrastructure
{
    public class YouTubeApiConfig
    {
        public string ApiKey { get; set; }

        public string AppName { get; set; }

        public YouTubeApiConfig(string apiKey, string appName)
        {
            ApiKey = apiKey;
            AppName = appName;
        }
    }
}
