using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public struct PclData
    {
        /// <summary>
        /// Moyenne 
        /// </summary>
        public double Mean { get; set; }
        /// <summary>
        /// Ecart-type
        /// </summary>
        public double StandardDeviation { get; set; }

        public double RelativeStd { get; set; }
    }

    public class PercolationSimulation
    {
        public PclData MeanPercolationValue(int size, int t)
        {
            PclData p =new PclData();
            var valpercol= new double[t];
            double s1 =0;
            double s2 =0;
            double moyenne=0;
            double ecarttype=0;
            for(int i = 0; i < t; i++)
            {
                valpercol[i]=PercolationValue(size);
                s1 += valpercol[i];
                s2 += valpercol[i]*valpercol[i]
            }
            moyenne=s1/t;
            ecarttype = Math.Sqrt((s2/t)-(moyenne*moyenne));
            p.Mean=moyenne;
            p.StandardDeviation=ecarttype;
            p.RelativeStd=ecarttype/moyenne;

          //  throw new NotImplementedException();
        }

        public double PercolationValue(int size)
        {
            int  ouvertes=0;            
            var percolation = new Percolation(size);
            var r = new Random();
            int  totcases = size*size;
            while(!percolation.Percolate())
            {
                int r1=r.Next(0, size);
                int r2=r.Next(0, size);
                if (!percolation.IsOpen(r1,r2)
                {
                    percolation.Open(r1,r2);
                    ouvertes++;
                }
            }
            return ouvertes/totcases;
           // throw new NotImplementedException();
        }
    }
}
