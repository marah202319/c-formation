using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class Factorial
    {
        public static int Factorial_(int n)
        {
            int resultat = 1;
            if (n == 0)
            {
                return 1;
            }
            else
            {
                for(int i = 1; i <= n; i++)
                {
                    resultat *= i;
                }
            }
            Console.WriteLine(resultat);
            return resultat;
            
        }

        public static int FactorialRecursive(int n)
        {
            int res = 1;
            if (n == 0)
            {
                res= 1;
            }
            else
            {
                res = n * FactorialRecursive(n - 1);
            }

           // Console.WriteLine(res);
            return res;
            
        }
    }
}
