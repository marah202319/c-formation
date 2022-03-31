using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projet_part2
{
    public class Gestionnaire
    {
        public int Id { get; set; }
        public TypeGestionnaire Type { get; set; }
        public int Nbrtransactions { get; set; }

        public List<Transaction> ListTransactions { get; set; }
        public TypeFrais Typefrais { get; set; }
        public double Frais { get; set; }

        public Gestionnaire(int id, TypeGestionnaire type, int nbrtransactions)
        {
            Id = id;
            Nbrtransactions = nbrtransactions;
            Type = type;
            ListTransactions = new List<Transaction>();
        }
    }
}
