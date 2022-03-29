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
		public TypeGestionnaire Type;
		public int Nbrtransactions;		
		Dictionary<int, Compte> comptes;
		
		public Gestionnaires(int id, TypeGestionnaire type, int nbrtransactions)
		{
			Id = id;
			Type = type;
			Nbrtransactions = nbrtransactions;
			comptes= = new Dictionary<int, Compte>();
		}
	}
}
