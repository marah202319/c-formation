using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class Pyramid
    {
        public static void PyramidConstruction(int n, bool isSmooth)
        {
            
            for(int i = 1; i <= n; i++)
            {
                for (int j = i; j <= n; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= 2*i-1; k++)
                {
                   
                    
                        if (i % 2 == 0 && isSmooth)
                        {
                            Console.Write("-");
                        }
                        else
                        {
                            Console.Write("+");
                        }
                  

                }
            
                Console.WriteLine();
                
            }
        }
    }
}
