using System.Diagnostics;

namespace BreakfastMenuAsync
{
    internal class Tea { }
    internal class Egg { }
    internal class Coffee { }
    internal class Toast { }

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start preparing breakfast...");
            var timer = Stopwatch.StartNew();

            var teaTask = BrewTeaAsync();
            var eggTask = FryEggAsync();
            var toastTask = ToastBreadAsync(canToast: false);

            var breakfastTasks = new List<Task> { teaTask, toastTask, eggTask };

            while (breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);

                try
                {
                    if (finishedTask == eggTask)
                    {
                        AddLog("Eggs are ready.");
                    }
                    else if (finishedTask == teaTask)
                    {
                        AddLog("Tea is ready.");
                    }
                    else if (finishedTask == toastTask)
                    {
                        if (finishedTask.IsCanceled)
                        {
                            AddLog("Toast preparation was canceled due to a problem with the toaster.");
                        }
                        else
                        {
                            AddLog("Toast is ready.");
                        }
                    }

                    await finishedTask;
                }
                catch (Exception ex)
                {
                    AddLog($"An error occurred: {ex.Message}");
                }

                breakfastTasks.Remove(finishedTask);
            }

            AddLog("All breakfast items are prepared!");
            AddLog("Breakfast is ready to serve!");

            try
            {
                var coffeeTask = BrewCoffeeAsync();
                await coffeeTask;
                AddLog("Coffee is ready!");
            }
            catch (Exception ex)
            {
                AddLog($"Error while brewing coffee: {ex.Message}");
            }

            timer.Stop();
            AddLog($"Total time: {timer.ElapsedMilliseconds} ms");

        }

        private static async Task<Tea> BrewTeaAsync()
        {
            try
            {
                AddLog("Boiling water for tea...");
                await Task.Delay(500);
                AddLog("Tea is brewing...");
                await Task.Delay(2000);
                return new Tea();
            }
            catch (Exception ex)
            {
                AddLog($"Error while brewing tea: {ex.Message}");
                throw;
            }
        }

        private static async Task<Egg> FryEggAsync()
        {
            try
            {
                AddLog("Start frying egg...");
                await Task.Delay(1000);
                return new Egg();
            }
            catch (Exception ex)
            {
                AddLog($"Error while frying egg: {ex.Message}");
                throw;
            }
        }

        private static async Task<Coffee> BrewCoffeeAsync()
        {
            try
            {
                AddLog("Start brewing coffee...");
                await Task.Delay(1000);
                return new Coffee();
            }
            catch (Exception ex)
            {
                AddLog($"Error while brewing coffee: {ex.Message}");
                throw;
            }
        }

        private static async Task<Toast> ToastBreadAsync(bool canToast)
        {
            if (!canToast)
            {
                AddLog("Toast machine is not working.");
                var cts = new CancellationTokenSource();
                cts.Cancel();
                return await Task.FromCanceled<Toast>(cts.Token);
            }

            try
            {
                AddLog("Putting bread in the toaster...");
                await Task.Delay(1000);
                AddLog("Adding butter and jam...");
                return new Toast();
            }
            catch (OperationCanceledException)
            {
                AddLog("Toast preparation was canceled because the toaster is not working.");
                throw;
            }
        }

        private static void AddLog(string message)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
        }
    }
}
