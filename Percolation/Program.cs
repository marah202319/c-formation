using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    class Program
    {
        static void Main(string[] args)
        {
            Percolation pp = new Percolation(10);
            PercolationSimulation p = new PercolationSimulation();
            var p1=p.MeanPercolationValue(10,100);
            Console.WriteLine(p1.Mean +";" +p1.StandardDeviation +";" +p1.RelativeStd);
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        
        }
    }
}
