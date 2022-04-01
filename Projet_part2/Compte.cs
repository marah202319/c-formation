using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_part2

{
	public class Compte
	{
		public int Id { get; set; }
		public double Solde { get; set; }
		private int Max_retrait { get; set; }
		public DateTime Date;
		//public int Entree;
		//public int Sortie;
		//public DateTime DateRes;
		public int Id_gest { get; set; }

		public List<Transaction> transactions { get; set; }


		public Compte(int id,DateTime date, double solde=0, int id_gest=0)
		{
			Id = id;
			Date=date;
			Solde = solde;						
			Max_retrait = 1000;
			transactions = new List<Transaction>();
			Id_gest = id_gest;
		}
		public bool depot(double somme,Transaction tr)
        {
			if (somme > 0)
            {
				
				transactions.Add(tr);
				Solde += somme;
				return true;
            }
			return false;
        }
		public bool Retrait(double somme, Transaction tr)
		{
			if ((Solde - somme) > 0 && somme >=0 )
			{				
				Solde -= somme;
				transactions.Add(tr);				
				return true;
			}
			return false;
		}
		
	}
}
