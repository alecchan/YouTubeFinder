In your local development environment, add a file named 'local.settings.json' to the YouTubeFinder.AzureFunctions and paste in the following.

{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet"
  },
  "YouTubeApiKey": "<enter you google api key here>",
  "AppName": "<the name of the application>"
}