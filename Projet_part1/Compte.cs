using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_part1

{
	public class Compte
	{
		public int Id { get; set; }
		public double Solde { get; set; }
		private int Max_retrait { get; set; }

		public List<Transaction> transactions { get; set; }


		public Compte(int id, double solde=0)
		{
			Id = id;
			Solde = solde;
			Max_retrait = 1000;
			transactions = new List<Transaction>();
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
		public bool retrait(double somme, Transaction tr)
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
