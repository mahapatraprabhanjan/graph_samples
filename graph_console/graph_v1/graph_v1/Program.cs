using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using System;
using FileSystemDirectory = System.IO.Directory;
using static System.Console;
using System.Net.Http;

namespace graph_v1
{
    class Program
    {
        private static GraphServiceClient _graphServiceClient;
        private static HttpClient _httpClient;

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(FileSystemDirectory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            if (configuration == null)
                WriteLine("Missing or invalid appsettings.json.");
        }
    }
}
