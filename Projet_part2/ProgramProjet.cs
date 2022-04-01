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
            string mngrPath = path + @"\Gestionnaires.txt";
            string acctPath = path + @"\Comptes.txt";
            string trxnPath = path + @"\Transactions.txt";
            //Fichiers sortie
            string sttsAcctPath = path + @"\StatutOpe.txt";
            string sttsTrxnPath = path + @"\StatutTra.txt";
            string mtrlPath = path + @"\Metrologie.txt";

            //TODO: Votre implémentation

            Banque b = new Banque();
            b.LireGestionnaires(mngrPath);
            b.LireFichiers(acctPath, trxnPath);
            b.TraiterFichiers();
            b.EcrireTransactionsStatus(sttsTrxnPath);
            b.EcrireOperationsStatus(sttsAcctPath);
            b.EcrireMetrologie(mtrlPath);
            /*
            GestionI_O g = new GestionI_O();
            #region Lecture fichiers

            g.LireComptes(acctPath);
            g.LireTransactions(trxnPath);
            g.LireGestionnaires(mngrPath);

            #endregion
            g.EcrireTransactionsStatus(sttsTrxnPath);
            g.EcrireOperationsStatus(sttsAcctPath);

            g.EcrireMetrologie(mtrlPath);
            */

            // Keep the console window open
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }
    }
}
