using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projet_part2
{
	public class Gestionnaires
	{
		public int Id { get; set; }		
		public int Nbrtransactions;
		public List<Transaction> ListTransactions;
		public TypeFrais Typefrais;
		public TypeGestionnaire typeGestionnaire1;
		public double Frais;

		
		Dictionary<int, Compte> comptes;
		public enum TypeGestionnaire
		{
			Particulier,
			Entreprise
		}
		public enum TypeFrais
        {
			fraisParticulier,
			fraisEntreprise
        }
		public enum TypeOperation
        {
			Transaction,
			Compte
        }

		public Gestionnaires(int id,TypeGestionnaire typeGestionnaire, int nbrtransactions)
		{
			Id = id;			
			Nbrtransactions = nbrtransactions;
			typeGestionnaire1 = typeGestionnaire;
			
			ListTransactions = new List<Transaction>();
		}		

	}
}
