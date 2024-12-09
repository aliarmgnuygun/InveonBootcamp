using System.Diagnostics;

namespace WebsiteFetcherAsyncVsSync
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            Console.WriteLine("1. Synchronous Execution");
            Console.WriteLine("2. Asynchronous Execution");
            Console.Write("Choose an option: ");
            string? choice = Console.ReadLine();

            // Added User-Agent header once for forbidden error
            if (!client.DefaultRequestHeaders.Contains("User-Agent"))
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
            }

            var watch = Stopwatch.StartNew();

            if (choice == "1")
            {
                RunDownloadSync();
            }
            else if (choice == "2")
            {
                await RunDownloadAsync();
            }
            else
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"\nTotal execution time: {elapsedMs} ms");
        }

        private static List<string> GetWebsiteUrl()
        {
            List<string> webSitesURL = new List<string>
            {
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.wikipedia.org",
                "https://www.coursera.org",
                "https://www.stackoverflow.com",
                "https://www.reddit.com",
                "https://x.com"
            };

            return webSitesURL;
        }


        #region Sync Methods
        private static void RunDownloadSync()
        {
            List<string> websites = GetWebsiteUrl();

            foreach (var site in websites)
            {
                var websiteInfo = DownloadWebsiteSync(site);
                ReportWebsiteInfo(websiteInfo);
            }
        }

        private static WebsiteDataModel DownloadWebsiteSync(string siteURl)
        {
            var websiteInfo = new WebsiteDataModel { WebsiteUrl = siteURl };

            try
            {
                websiteInfo.WebsiteData = client.GetStringAsync(siteURl).GetAwaiter().GetResult();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching data from {siteURl}: {ex.Message}");
                websiteInfo.WebsiteData = string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                websiteInfo.WebsiteData = string.Empty;
            }

            return websiteInfo;
        }

        #endregion

        #region Async Methods
        private static async Task RunDownloadAsync()
        {
            List<string> websites = GetWebsiteUrl();
            var downloadTasks = new List<Task<WebsiteDataModel>>();

            foreach (var site in websites)
            {
                downloadTasks.Add(DownloadWebsiteAsync(site));
            }

            var results = await Task.WhenAll(downloadTasks);

            foreach (var websiteInfo in results)
            {
                ReportWebsiteInfo(websiteInfo);
            }
        }

        private static async Task<WebsiteDataModel> DownloadWebsiteAsync(string siteURl)
        {
            var websiteInfo = new WebsiteDataModel { WebsiteUrl = siteURl };

            try
            {
                websiteInfo.WebsiteData = await client.GetStringAsync(siteURl);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching data from {siteURl}: {ex.Message}");
                websiteInfo.WebsiteData = string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                websiteInfo.WebsiteData = string.Empty;
            }
            return websiteInfo;
        }
        #endregion

        private static void ReportWebsiteInfo(WebsiteDataModel data)
        {
            Console.WriteLine($"{data.WebsiteUrl} downloaded: {data.WebsiteData.Length} characters long.");
        }
    }

    class WebsiteDataModel
    {
        public string WebsiteUrl { get; set; }
        public string WebsiteData { get; set; }
    }
}