using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_part2

{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime DateTransaction;
        public double Somme { get; set; }
        public int Transmetteur { get; set; }
        public int Recepteur { get; set; }

        public Transaction(int id, DateTime dateTransaction, double somme, int transmetteur, int recepteur)
        {
            Id = id;
            DateTransaction = dateTransaction;
            Somme = somme;
            Transmetteur = transmetteur;
            Recepteur = recepteur;
        }
    }
}

