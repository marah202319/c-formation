using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class ElementaryOperations
    {
        public static void BasicOperation(int a, int b, char operation)
        {
            var resultat = 0;
            string str = "Operation invalid";
            switch (operation)
            {
                case '+':
                    resultat = a + b;
                    break;
                case '-':
                    resultat = a - b;
                    break;
                case '*':
                    resultat = a * b;
                    break;
                case '/':
                    if (b != 0){
                        resultat = a / b;
                    }
                    else
                    {
                     //   Console.WriteLine("Operation invalid");                        
                    }
                  
                    break;
                default:
                    Console.WriteLine("Operation invalid");
                    break;

            }
            if (resultat != 0)
            {
                Console.WriteLine(a + " " + operation + " " + b + " = " + resultat);
            }
            else
            {
                Console.WriteLine(a + " " + operation + " " + b + " = " + str);
            }
            
            
        }

        public static void IntegerDivision(int a, int b)
        {
            string str = "Operation invalid";
            if (b != 0)
            {
                int r = 0;
                int q = 0;
                r = a % b;
                q = (a - r) / b;
                Console.WriteLine(a + " =" + q + " *" + b + " + " + r);
            }
            else
            {
                Console.WriteLine(a + " :"  + b + " = " +str);
            }
            
        }

        public static void Pow(int a, int b)
        {
            string str = "Operation invalid";
            int resultat = 1;
            if (b > 0)
            {
                for(int j = 0 ; j < b; j++)
                {
                    resultat *= a;
                }
                Console.WriteLine(a + " ^" + b + " = " + resultat);
            }
            else
            {
                Console.WriteLine(a + " ^" + b + " = " + str);
            } 
        }
    }
}
