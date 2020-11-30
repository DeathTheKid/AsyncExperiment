using System;
using System.Threading.Tasks;

namespace SynchronousExperiment
{
    class Program
    {
        static void Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("Coffee is ready!");

            var eggsTask = FryEggs(2);
            Console.WriteLine("Eggs are ready!");

            var baconTask = FryBacon(4);
            Console.WriteLine("Bacon is ready!");

            var toastTask = MakeToastWithButterandJam(2);
            Console.WriteLine("Toast is ready!");

            Juice oj = PourOJ();
            Console.WriteLine("OJ is ready!");

            Console.WriteLine("BREAKFAST IS READY!!!");
            Console.ReadLine();
        }

        static Toast MakeToastWithButterandJam(int number)
        {
            var toast = ToastBread(number);
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

        private static Toast ToastBread(int slices)
        {
            for (int i = 0; i < slices; i++)
            {
                Console.WriteLine("Putting slice in toaster.");
            }

            Console.WriteLine("Start toasting...");
            Task.Delay(3000);
            Console.WriteLine("Remove bread from toaster.");

            return new Toast();
        }

        private static Bacon FryBacon(int strips)
        {
            Console.WriteLine($"Putting {strips} strips of bacon in the pan.");
            Console.WriteLine("Cooking first side.");
            Task.Delay(3000);
            for (int strip = 0; strip < strips; strip++)
            {
                Console.WriteLine("Flipping strip.");
            }
            Console.WriteLine("Cooking second side...");
            Task.Delay(3000);
            Console.WriteLine("Putting bacon on plate.");
            return new Bacon();
        }

        private static Egg FryEggs(int number)
        {
            Console.WriteLine("Warming up fryer.");
            Task.Delay(3000);
            Console.WriteLine($"Cracking {number} of eggs.");
            Task.Delay(3000);
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