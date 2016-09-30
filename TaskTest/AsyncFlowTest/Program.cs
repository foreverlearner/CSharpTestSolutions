using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFlowTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Program will end before MainAsync() complete.
            //MainAsync();
            //Console.WriteLine("\r\nBack to Main\r\n");

            // In order to wait for Async Method to complete, need to get its result
            bool rtn = MainAsync().Result;
            Console.WriteLine("\r\nBack to Main\r\n");
            Console.WriteLine("\r\n MainAsync().Result is: {0}.\r\n", rtn);

        }

        static async Task<bool> MainAsync()
        {
            Console.WriteLine("ONE: Entering Main.");
            Console.WriteLine("     Calling AccessTheWebAsync.");

            Task<int> getLengthTask = AccessTheWebAsync();

            Console.WriteLine("FOUR:  Back in Main.");
            Console.WriteLine("           Task getLengthTask is started.\r\n");
            Console.WriteLine("           About to await getLengthTask -- if there is caller, return to caller.\r\n");

            int contentLength = await getLengthTask;

            Console.WriteLine("\r\nSIX:   Back in startButton_Click.\r\n");
            Console.WriteLine("           Task getLengthTask is finished.\r\n");
            Console.WriteLine("           Result from AccessTheWebAsync is stored in contentLength.\r\n");
            Console.WriteLine("           About to display contentLength and exit.\r\n");

            Console.WriteLine("\r\nLength of the downloaded string: {0}.\r\n", contentLength);
            return true;
        }

        static async Task<int> AccessTheWebAsync()
        {
            Console.WriteLine("TWO: Entering AccessTheWebAsync.");

            // Declare an HttpClient object
            HttpClient client = new HttpClient();

            Console.WriteLine("      Calling HttpClient.GetStringAsync.");

            // GetStringAsync returns a Task<string>.
            Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");

            Console.WriteLine("THREE: Back in AccessTheWebAsync.");
            Console.WriteLine("     Task getStringTask is started.");

            // AccessTheWebAsync can continue to work until getStringTask is awaited.

            Console.WriteLine("       About to await getStringTask and return a Task<int> to Main.");

            string urlContents = await getStringTask;

            Console.WriteLine("FIVE: Back in AccessTheWebAsync.");
            Console.WriteLine("      Task getStringTask is complete.");
            Console.WriteLine("      Processing the return statement.");
            Console.WriteLine("      Exiting from AccessTheWebAsync.");

            return urlContents.Length;
        }
    }
}
