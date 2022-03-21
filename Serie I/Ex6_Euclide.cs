using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class Euclide
    {
        public static int Pgcd(int a, int b)
        {
            int c = 0;
            int r = a % b;
            if (r == 0)
            {
                c = b;
            }
            for (int i = b; i >1; i--)
            {
                if (a % i == 0 && b % i == 0)
                    c = i;
            }
            return c;

            
        }

        public static int PgcdRecursive(int a, int b)
        {
                   
            int r = a % b;
            if (r == 0)
                return b;
            return PgcdRecursive(b, r);
        }
    }
}
