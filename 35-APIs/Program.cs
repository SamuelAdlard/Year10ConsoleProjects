using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace _35_APIs
{
    internal class Program
    {
        // Challenge: Create a program that can interact with an API

        // A sample program that prints out results from Formula 1 races is provided
        // Plenrt of free API's can be found here: https://github.com/public-apis/public-apis

        static void Main(string[] args)
        {
            string tryAgain = "y";

            while (tryAgain.ToLower() == "y")
            {
                //GetF1Data();
                ParliamentAPI.GetData();

                tryAgain = Console.ReadLine();
            }
        }

        static void GetF1Data()
        {
            F1API.PrintHeader();

            Console.WriteLine("For which year would you like the data?");
            string year = Console.ReadLine();

            Console.WriteLine("For which round would you like the data?");
            string round = Console.ReadLine();

            F1API.GetData(year + "/" + round + "/results");
        }
    }
}
