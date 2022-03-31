using System;

namespace Projet_part2
{
    internal class LigneFichier
    {
        public LigneFichier(int id, DateTime date, double montant, int entree, int sortie, TypeOperation type)
        {
            Id = id;
            Date = date;
            Montant = montant;
            Entree = entree;
            Sortie = sortie;
            Type = type;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Montant { get; set; }
        public int Entree { get; set; }
        public int Sortie { get; set; }
        public TypeOperation Type { get; set; }
    }
}