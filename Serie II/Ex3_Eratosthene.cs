using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    public static class Eratosthene
    {
        public static int[] EratosthenesSieve(int n)
        {
            var t = new int[n+1];
            
            for (int i = 0; i < t.Length; i++)
			{
                t[i]=i;
			}
            for (int i = 2; i < t.Length; i++)
			{
                for(int j=i+i;j< t.Length; j+=i){

                    t[j]=-1;
                } 
            }    
            return t;
           
        }
        
    }
}
