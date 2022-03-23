using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_III
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            string input = path + @"\input.txt";
            string output = path + @"\output.txt";
            ClassCouncil.SchoolMeans(input, output);
            //int[] array1 = SortingPerformance.ArraysGenerator(3000)[1];
            //int[] array2 = SortingPerformance.ArraysGenerator(3000)[2];
            /* Random randNum = new Random();
             for (int i = 0; i < array.Length; i++)
             {
                 int.TryParse(randNum, out int result);
                 array[i] = result;
             }*/

            //Console.WriteLine(SortingPerformance.UseInsertionSort(array1));
            //Console.WriteLine(SortingPerformance.UseQuickSort(array2));
            SortingPerformance.PerformancesTest(new List<int> { 1000, 2000, 5000, 10000 }, 15);
            SortingPerformance.DisplayPerformances(new List<int> { 1000, 2000, 5000, 10000 }, 15);

            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
