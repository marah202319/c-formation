using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_part2
{
    class ProgramProjet
    {
        static void Main(string[] args)
        {
            
            string path = Directory.GetCurrentDirectory();
            // Fichiers entrée
            string mngrPath = path + @"\Gestionnaires_1.txt";
            string acctPath = path + @"\Comptes_1.txt";
            string trxnPath = path + @"\Transactions_1.txt";
            //Fichiers sortie
            string sttsAcctPath = path + @"\StatutOpe_1.txt";
            string sttsTrxnPath = path + @"\StatutTra_1.txt";
            string mtrlPath = path + @"\Metrologie_1.txt";

            //TODO: Votre implémentation

            
           /* string path = Directory.GetCurrentDirectory();
            string acctPath = path + @"\Comptes_1.txt";
            string trxnPath = path + @"\Transactions_1.txt";
            string sttsPath = path + @"\Statut_1.txt";
           */
            GestionI_O g = new GestionI_O();
            g.LireComptes(acctPath);
            g.LireTransactions(trxnPath);
            g.EcrireTransactionsStatus(sttsTrxnPath);
            g.EcrireOperationsStatus(sttsAcctPath);
            g.EcrireMetrologie(mtrlPath);
            
            
            // Keep the console window open
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();          

        }
    }
}
