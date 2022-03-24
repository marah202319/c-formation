using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            string firstname = Console.ReadLine();
            Console.WriteLine("Hello  " + firstname +"!");

            Console.ReadLine();
           
            int numberOfTry = 1;
            bool isWin = false;

            Console.WriteLine("*** Jeu du plus ou du moins ***");
          
            var numberToFind = new Random().Next(0, 100);
         
            while (!isWin)
            {
                Console.WriteLine("Essayez de deviner le nombre entre 0 et 100 :");             
                var result = int.Parse(Console.ReadLine());
               
                if (result < numberToFind)
                {
                    Console.WriteLine("C'est plus");
                    numberOfTry++;
                } 
                else if (result > numberToFind)
                {
                    Console.WriteLine("C'est moins");
                    numberOfTry++;
                }
                else 
                     
                {
                    Console.WriteLine($"Trouvé en {numberOfTry} coups !");
                    Console.WriteLine($"Le résultat est bien {result}");
                    isWin = true;
                }
                
            }
            Console.ReadLine();
        }

    }
}
