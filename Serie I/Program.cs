using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    class Program
    {
        static void Main(string[] args)
        {
            ElementaryOperations.BasicOperation(1, 1, '+');
            ElementaryOperations.BasicOperation(6, 0, '/');
            ElementaryOperations.IntegerDivision(12, 5);
            ElementaryOperations.IntegerDivision(12, 0);
            ElementaryOperations.Pow(2, 3);
            ElementaryOperations.Pow(2, -3);
            SpeakingClock.GoodDay(3);
            SpeakingClock.GoodDay(12);
            SpeakingClock.GoodDay(35);
            Pyramid.PyramidConstruction(10, true);
            Pyramid.PyramidConstruction(10, false);
            Factorial.Factorial_(6);
           // Factorial.FactorialRecursive(5);
            Console.WriteLine(Factorial.FactorialRecursive(5));
            //PrimeNumbers.DisplayPrimes();
            //Console.Writeline(Euclide.PgcdRecursive(25, 30));
            Console.WriteLine(Euclide.PgcdRecursive(25, 30));
            Console.WriteLine(Euclide.Pgcd(25, 30));
            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
