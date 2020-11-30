using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncExperiment
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("Coffee is ready!");

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(4);
            var toastTask = MakeToastWithButterandJamAsync(2);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while(breakfastTasks.Count() > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if(finishedTask == eggsTask)
                {
                    Console.WriteLine("Eggs are ready!");
                } 
                else if(finishedTask == baconTask) 
                {
                    Console.WriteLine("Bacon is ready!");
                }
                else if(finishedTask == toastTask)
                {
                    Console.WriteLine("Toast is ready!");
                }
                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = PourOJ();
            Console.WriteLine("OJ is ready!");
            Console.WriteLine("BREAKFAST IS READY!!!");
            Console.ReadLine();
        }

        static async Task<Toast> MakeToastWithButterandJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }


        private static void ApplyJam(Toast toast) => Console.WriteLine("Applying jam to toast.");

        private static void ApplyButter(Toast toast) => Console.WriteLine("Applying butter to toast.");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int i = 0; i < slices; i++)
            {
                Console.WriteLine("Putting slice in toaster.");
            }

            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove bread from toaster.");

            return new Toast();
        }

        private async static Task<Bacon> FryBaconAsync(int strips)
        {
            Console.WriteLine($"Putting {strips} strips of bacon in the pan.");
            Console.WriteLine("Cooking first side.");
            await Task.Delay(3000);
            for(int strip = 0; strip < strips; strip++)
            {
                Console.WriteLine("Flipping strip.");
            }
            Console.WriteLine("Cooking second side...");
            await Task.Delay(3000);
            Console.WriteLine("Putting bacon on plate.");
            return new Bacon();
        }

        private async static Task<Egg> FryEggsAsync(int number)
        {
            Console.WriteLine("Warming up fryer.");
            await Task.Delay(3000);
            Console.WriteLine($"Cracking {number} of eggs.");
            await Task.Delay(3000);
            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring some coffee.");
            return new Coffee();
        }
    }

    internal class Toast { }
    internal class Juice { }
    internal class Bacon { }
    internal class Egg { }
    internal class Coffee { }
}
