using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_part1

{
	public class Transaction
	{
		public int Id { get; set; }
		public double Somme { get; set; }
		public int Transmetteur { get; set; }
		public int Recepteur { get; set; }
		public TransactionType Type { get; set; }
		public TransactionStatus Status { get; set; }
		public enum TransactionType
        {
			Depot,
			Retrait,
			Virement,
			Prelevement
        }
		public enum TransactionStatus
        {
			OK,
			KO
        }

		public Transaction (TransactionType type, TransactionStatus status,int id=0,double somme=0,int transmetteur=0,int recepteur=0)
		{
			Id = id;
			Somme = somme;
			Transmetteur = transmetteur;
			Recepteur = recepteur;
			Type = type;
			Status = status;
		}
		/*public Transaction (int id=0,double somme=0,int transmetteur=0,int recepteur=0)
		{
			Id = id;
			Somme = somme;
			Transmetteur = transmetteur;
			Recepteur = recepteur;

		}*/
	}
}

