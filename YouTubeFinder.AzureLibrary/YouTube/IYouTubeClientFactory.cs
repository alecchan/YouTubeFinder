using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.Text;

namespace YouTubeFinder.AzureLibrary.YouTube
{
    public interface IYouTubeClientFactory
    {
        YouTubeService GetClient();
    }
}
