using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var demo = new AsyncAwaitDemo();

            demo.DoStuff();

            while (true)
            {
                Console.WriteLine("Doing Stuff on the Main Thread..............");
            }
        }
    }

    public class AsyncAwaitDemo
    {
        public async Task DoStuff()
        {
            await Task.Run(() =>
            {
                LongRunningOperation();
            });
        }

        private static async Task<string> LongRunningOperation()
        {
            int counter;

            for (counter = 0; counter < 50000; counter++)
            {
                Console.WriteLine(counter);
            }

            return "Counter = " + counter;
        }
    }
}
