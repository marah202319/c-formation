using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    public static class Search
    {
        public static int LinearSearch(int[] tableau, int valeur)
        {
            for(int i = 0; i < tableau.Length; i++)
            {
                if (tableau[i] == valeur) return i;                
            }
            return -1;
            //return Array.IndexOf(tableau,valeur);
        }

        public static int BinarySearch(int[] tableau, int valeur)
        {
           
            int a = 0;
            int b = tableau.Length;
            if (b == 0){
                return -1;
            }
                              
            while (b > a + 1){
            int m = (a + b)/2; 
                if (tableau[m] > valeur)
                    b = m;
                else
                    a = m;         
            } 
            if(tableau[a]!=valeur)
                return -1;
            return a;
           
        }
    }
}
