using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeFinder.AzureLibrary.YouTube
{
    public interface IYouTubeVideoFinder
    {
        Task<IEnumerable<FindResult>> FindAsync(string channelId, string searchTerm, int maxResults = 5);
    }
}
