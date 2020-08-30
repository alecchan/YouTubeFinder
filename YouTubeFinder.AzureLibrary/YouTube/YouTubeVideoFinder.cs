using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeFinder.AzureLibrary.YouTube
{
    public class YouTubeVideoFinder : IYouTubeVideoFinder
    {
        private readonly IYouTubeClientFactory _factory;

        public YouTubeVideoFinder(IYouTubeClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<FindResult>> FindAsync(string channelId, string searchTerm, int maxResults)
        {
            if (string.IsNullOrEmpty(channelId))
                throw new ArgumentException(nameof(channelId));

            if (string.IsNullOrEmpty(searchTerm))
                throw new ArgumentException(nameof(searchTerm));

            var client = _factory.GetClient();


            var searchListRequest = client.Search.List("snippet");
            searchListRequest.ChannelId = channelId;
            searchListRequest.Q = searchTerm; // Replace with your search term.
            searchListRequest.MaxResults = maxResults;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();
            List<FindResult> videos = new List<FindResult>();
            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        videos.Add(new FindResult
                        {
                            Title = searchResult.Snippet.Title,
                            VideoId = searchResult.Id.VideoId,
                        });
                        break;
                }
            }

            return videos;
        }
    }
}
