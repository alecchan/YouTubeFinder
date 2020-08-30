using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using YouTubeFinder.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using YouTubeFinder.AzureLibrary.YouTube;

namespace YouTubeFinder
{
    public static class YouTubeSearchTrigger
    {
        [FunctionName("YouTubeSearchTrigger")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            string term = req.Query["term"];

            log.LogInformation($"C# Http trigger function processed: {term}");

            try
            {
                var videoFinder = DIContainer.Instance.GetService<IYouTubeVideoFinder>();
                var result = await videoFinder.FindAsync("UCzQUP1qoWDoEbmsQxvdjxgQ", term);
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex, $"Something went wrong with the YouTubeSearchTrigger");
                throw;
            }

            /*     string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                 dynamic data = JsonConvert.DeserializeObject(requestBody);
                 name = name ?? data?.name;

                 string responseMessage = string.IsNullOrEmpty(name)
                     ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                     : $"Hello, {name}. This HTTP triggered function executed successfully.";
            */
        }
    }
}
