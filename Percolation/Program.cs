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
            /*3-b/  dans le pire des cas on va ouvrir une case qui un voisin plein et tt les autres cases ne sont pas plein.a ce moment on va les rendre pleines et la grille sera full.performance linéaire:O(n)
             * 3-c/ parceque si on a une case pleine, le reste ne seront pas tous ouvert.
             * 
             */ 
            //Percolation pp = new Percolation(10);
            //pp.
            PercolationSimulation p = new PercolationSimulation();
            p.PercolationValue(10);
            var p1=p.MeanPercolationValue(10,100);
            Console.WriteLine(p1.Mean +";" +p1.StandardDeviation +";" +p1.RelativeStd);
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        
        }
    }
}
