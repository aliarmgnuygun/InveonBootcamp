using System.Diagnostics;

namespace TaskMethodsUsage
{
    public class Program
    {
        static async Task Main(string[] args)
        {

            //await ComplexCalculationAsync();
            //await FactoryStartNewAsync();
            //await DelayExample();
            //await ProductSaleProcess();
            //await CheckProductPriceAsync(0);
            //await GetAllDataAsync();
            //await CheckUserLoginAsync("JohnDoe", "password123");
            //await LogUserLoginAsync("JohnDoe");
            //WaitAll();
            //WaitAny();
            /*
            var uiTask = SimulateUIUpdatesAsync();
            await PerformHeavyCalculationAsync();
            await uiTask;
            */

        }
        private static async Task DelayExample()
        {
            var stopwatch = Stopwatch.StartNew();
            var delay = Task.Delay(1000).ContinueWith(_ =>
            {
                stopwatch.Stop();
            });
            await delay;
            Console.WriteLine($"Task Delay example usage \nTime elapsed: {stopwatch.ElapsedMilliseconds} ms");
        }


        #region Task.Run and Task.Factory.StartNew Usage
        private static async Task ComplexCalculationAsync()
        {
            var stopwatch = Stopwatch.StartNew();
            await Task.Run(() =>
            {
                Console.WriteLine("Starting the complex calculation...");
                for (int i = 0; i < int.MaxValue; i++)
                {
                    var calculatedValue = Math.Sqrt(i);
                }
                Console.WriteLine("Finished the complex calculation!");
            });
            stopwatch.Stop();
            Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
        }
        private static async Task FactoryStartNewAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            await Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Starting the complex calculation...");
                for (int i = 0; i < int.MaxValue; i++) 
                {
                    var calculatedValue = Math.Sqrt(i); 
                }
                Console.WriteLine("Finished the complex calculation!");
            }, TaskCreationOptions.LongRunning); 

            stopwatch.Stop();
            Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms");
        }
        #endregion
       
        #region FromException and FromCanceled Usage
        private static async Task<string> ProductSaleProcess()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            Task saleTask = Task.Run(() =>
            {
                while (!cts.Token.IsCancellationRequested)
                {
                    Console.WriteLine("Sale process is running...");
                    Thread.Sleep(1000);
                }
            }, cts.Token);

            await Task.Delay(2000);
            cts.Cancel();
            Task cancelledTask = Task.FromCanceled(cts.Token);

            if (cancelledTask.IsCanceled)
            {
                Console.WriteLine("Sale process is cancelled!");
                return "";
            }

            await saleTask;
            return "Sale process completed successfully!";
        }

        private static Task<string> CheckProductPriceAsync(int price)
        {
            if (price <= 0)
            {
                return Task.FromException<string>(new ArgumentException("Price cannot be negative!"));
            }
            return Task.FromResult($"The product price is {price}.");
        }
        #endregion

        #region WhenAll, WhenAny Usage and Differences
        private static async Task GetAllDataAsync()
        {
            var fetchWeather = GetWeatherAsync();
            var fetchStock = GetStockDataAsync();
            var fetchNews = GetNewsAsync();

            var allTasks = new[] { fetchWeather, fetchStock, fetchNews };

            var whenAllTask = Task.WhenAll(allTasks);
            var whenAnyTask = Task.WhenAny(allTasks);

            var firstCompletedTask = await whenAnyTask;
            Console.WriteLine($"First completed result: {await firstCompletedTask}");


            await whenAllTask.ContinueWith(allTasks =>
            {
                Console.WriteLine("All tasks completed.");
            });

            async Task<string> GetWeatherAsync()
            {
                await Task.Delay(1000);
                return "Weather data: Sunny, 26°C";
            }

            async Task<string> GetStockDataAsync()
            {
                await Task.Delay(1500);
                return "Stock data: Nike sneakers at $300";
            }

            async Task<string> GetNewsAsync()
            {
                await Task.Delay(1200);
                return "News data: World leaders meet for summit in Turkey";
            }
        }
        #endregion

        #region FromResult and CompletedTask Usage and Differences
        private static Task<bool> CheckUserLoginAsync(string username, string password)
        {
            // from result -> we return a value. (TResult or completed task)
            bool isValid = username == "JohnDoe" && password == "password123";
            return Task.FromResult(isValid);
        }

        private static Task LogUserLoginAsync(string username)
        {
            // completed task -> we dont return any value. (void or completed task)
            Console.WriteLine($"User {username} logged in at {DateTime.Now}.");
            return Task.CompletedTask;
        }
        #endregion

        #region WaitAll, WaitAny Usage and Differences
        private static void WaitAll()
        {
            Task task1 = Task.Run(() => DoWork(1, 3000));
            Task task2 = Task.Run(() => DoWork(2, 1000));
            Task task3 = Task.Run(() => DoWork(3, 2000));

            Console.WriteLine("Using Task.WaitAll (blocking):");
            Task.WaitAll(task1, task2, task3);
            Console.WriteLine("All tasks completed using WaitAll.");
        }
        private static void WaitAny()
        {
            Task task1 = Task.Run(() => DoWork(1, 3000));
            Task task2 = Task.Run(() => DoWork(2, 1000));
            Task task3 = Task.Run(() => DoWork(3, 2000));

            Console.WriteLine("Using Task.WaitAny (blocking):");
            int completedIndex = Task.WaitAny(task1, task2, task3);
        }
        private static void DoWork(int taskId, int delay)
        {
            Console.WriteLine($"Task {taskId} started.");
            Task.Delay(delay).Wait();
            Console.WriteLine($"Task {taskId} completed.");
        }
        #endregion

        #region Yield Usage
        static async Task PerformHeavyCalculationAsync()
        {
            Console.WriteLine("İşlem başladı!");

            await Task.Yield();

            // Bu satır başka bir iş parçacığında çalışacak
            Console.WriteLine("Task.Yield sonrası çalıştı!");

            await Task.Delay(2000); 
            Console.WriteLine("İşlem bitti!");
        }
        #endregion
    }
}