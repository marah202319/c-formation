using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    class Program
    {
        static void Main(string[] args)
        {
            // Search.LinearSearch([1,2,3,4,5,6],5);
            int[] t = new int[] { 1, -5, 10, 3, 0, 4, 2, -7 };
            Console.WriteLine(Search.LinearSearch(t, 2));
            Array.Sort(t);
            Console.WriteLine(Search.BinarySearch(t, 5));
            Console.WriteLine(Search.BinarySearch(t, 3));
            //
            foreach (int i in Eratosthene.EratosthenesSieve(100))
                if (i != -1)
                    Console.WriteLine(i);
            //
            Qcm q1 = new Qcm("Qui est le jouer ayant remporté 6 ballons d'or ", new string[] { "C.Ronaldo", "Messi", "Ronaldo", "Modric" }, 2, 1);
            Qcm q2 = new Qcm("Qui est le jouer ayant remporté 6 ballons d'or ", new string[] { "C.Ronaldo", "Messi", "Ronaldo", "Modric" }, 2, 1);
            Qcm q3 = new Qcm("Quelle est3 ", new string[] { "476", "800", " 3", "4 " }, 2, 1);
            Qcm q4 = new Qcm("Quelle est4 ", new string[] { "476", "800", " 3", "4 " }, 2, 1);
           // Quiz.AskQuestion(q1);
            Quiz.AskQuestions(new Qcm[] {q1,q2,q3,q4});

            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
