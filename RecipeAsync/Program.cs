namespace RecipeAsync
{ 
    internal class Coffee { }
    internal class Egg { }
    internal class Tea { }
    internal class Toast { }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---- Breakfast Menu ----");


            
        }

        private static async Task<Tea> MakeTea()
        {
            Console.WriteLine("Making tea...");
            await Task.Delay(2000);
            Console.WriteLine("Tea is ready!");
            return new Tea();
        }




    }
}
