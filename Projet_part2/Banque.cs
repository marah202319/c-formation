using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_part2
{
    public class Banque
    {
        Dictionary<int, Gestionnaire> _gestionnaires;
        Dictionary<int, Compte> _comptes;
        List<Transaction> _transactions;
        List<LigneFichier> _lignes;

        public Banque()
        {
            _gestionnaires = new Dictionary<int, Gestionnaire>();
            _comptes = new Dictionary<int, Compte>();
            _transactions = new List<Transaction>();
        }

        internal void LireGestionnaires(string mngrPath)
        {
            using (StreamReader reader = new StreamReader(mngrPath))
            {
                while (!reader.EndOfStream)
                {
                    string[] data = reader.ReadLine().Split(';');
                    if (data.Length == 3)
                    {
                        int id = int.Parse(data[0]);
                        TypeGestionnaire type = data[1] == "Entreprise" ? TypeGestionnaire.Entreprise : TypeGestionnaire.Particulier;
                        int.TryParse(data[2].Replace(".", ","), out int nbTransactions);
                        if (nbTransactions >= 0 && !_gestionnaires.ContainsKey(id))
                        {
                            _gestionnaires.Add(id, new Gestionnaire(id, type, nbTransactions));
                        }
                    }
                }
            }
        }

        internal void LireFichiers(string acctPath, string trxnPath)
        {
            using (StreamReader reader = new StreamReader(acctPath))
            {
                while (!reader.EndOfStream)
                {
                    string[] data = reader.ReadLine().Split(';');
                    if (data.Length == 5)
                    {
                        int.TryParse(data[0], out int id);
                        DateTime.TryParse(data[1], out DateTime date);
                        int.TryParse(data[2].Replace(".", ","), out int montant);
                        int.TryParse(data[3], out int entree);
                        int.TryParse(data[4], out int sortie);

                        _lignes.Add(new LigneFichier(id, date, montant, entree, sortie, TypeOperation.Operation));
                    }
                }
            }
            using (StreamReader reader = new StreamReader(trxnPath))
            {
                while (!reader.EndOfStream)
                {
                    string[] data = reader.ReadLine().Split(';');
                    if (data.Length == 5)
                    {
                        int.TryParse(data[0], out int id);
                        DateTime.TryParse(data[1], out DateTime date);
                        int.TryParse(data[2].Replace(".", ","), out int montant);
                        int.TryParse(data[3], out int entree);
                        int.TryParse(data[4], out int sortie);

                        _lignes.Add(new LigneFichier(id, date, montant, entree, sortie, TypeOperation.Transaction));
                    }
                }
            }

            _lignes = _lignes.OrderBy(x => x.Date).ThenBy(x => x.Type).ToList();
        }
        public void CreatC(Compte c)
        {
            foreach(var acc in _comptes.Values)
            {
                if (acc.Id == c.Id)
                {

                }
            }
        }

        internal void TraiterFichiers()
        {
            List<string> statutsOpe = new List<string>();
            List<string> statutsTra = new List<string>();
            foreach (LigneFichier ligne in _lignes)
            {
                switch (ligne.Type)
                {
                    case TypeOperation.Operation:
                        if (ligne.Entree != 0 && ligne.Sortie == 0)
                        {
                            foreach (var gstn in _gestionnaires)
                            {
                                if (gstn.Key == ligne.Sortie)
                                {
                                    Console.WriteLine(ligne.Id + "Compte créé");
                                    Compte c = new Compte(ligne.Id, ligne.Date, ligne.Montant);
                                    _comptes.Add(ligne.Id, c);
                                    statutsOpe.Add($"{ligne.Id};OK");
                                    break;
                                }
                            }
                        }
                        else if (ligne.Entree != 0 && ligne.Sortie == 0)
                        {
                            foreach (var gstn in _gestionnaires)
                            {
                                if (gstn.Key == ligne.Sortie)
                                {
                                    foreach (var element in _comptes)
                                    {
                                        if (element.Key == ligne.Sortie)
                                        {
                                            element.Value.Date = ligne.Date;
                                            //ListCompte.Remove(element);
                                            Console.WriteLine($"{element.Value.Date} - {ligne.Date}");
                                        }
                                    }
                                }
                            }
                        }
                        else if (ligne.Entree != 0 && ligne.Sortie != 0)
                        {
                            if (_gestionnaires.ContainsKey(ligne.Entree) && _gestionnaires.ContainsKey(ligne.Sortie))
                            {
                                Console.WriteLine($"{ligne.Id} - Entree:{ligne.Entree} Compte cessionner");
                                ligne.Entree = ligne.Sortie;
                                Console.WriteLine($"{ligne.Id} - Entree:{ligne.Entree} Compte cessionner");
                                statutsOpe.Add($"{ligne.Id};OK");
                            }
                        }
                        break;

                    case TypeOperation.Transaction:
                        Transaction t = new Transaction(ligne.Id, ligne.Date, ligne.Montant, ligne.Entree, ligne.Sortie);
                        if (t.Transmetteur != 0 && t.Recepteur == 0)
                        {
                            //TransactionType.Retrait
                            // _transactions.Add(t.TransactionType.Retrait);
                            if (_comptes.ContainsKey(t.Transmetteur))
                            {
                                if (_comptes[t.Transmetteur].retrait(t.Somme, t))
                                {
                                    statutsTra.Add($"{t.Id};OK");
                                }
                                else
                                {
                                    statutsTra.Add($"{t.Id};KO");
                                }
                            }
                            else
                            {
                                statutsTra.Add($"{t.Id};KO");
                            }
                            //_transactions.Add(t);
                        }
                            
                        
                        else if (t.Transmetteur == 0 && t.Recepteur != 0)
                        {
                            if (_comptes.ContainsKey(t.Recepteur))
                            {
                                if (_comptes[t.Recepteur].retrait(t.Somme, t))
                                {
                                    statutsTra.Add($"{t.Id};OK");
                                }
                                else
                                {
                                    statutsTra.Add($"{t.Id};KO");
                                }
                            }
                            else
                            {
                                statutsTra.Add($"{t.Id};KO");
                            }
                            //_transactions.Add(t);
                        }

                        else if (t.Transmetteur != 0 && t.Recepteur != 0)
                        {
                            if (_comptes.ContainsKey(t.Recepteur) && _comptes.ContainsKey(t.Transmetteur) && t.Transmetteur!=t.Recepteur)
                            {
                                if (_comptes[t.Recepteur].retrait(t.Somme, t) && t.Somme>0)
                                {
                                    _comptes[t.Recepteur].depot(t.Somme, t) ;
                                    statutsTra.Add($"{t.Id};OK");
                                }
                                else
                                {
                                    statutsTra.Add($"{t.Id};KO");
                                }
                            }
                            else
                            {
                                statutsTra.Add($"{t.Id};KO");
                            }
                        }
                        break;
                    default:
                        Transaction t1 = new Transaction(ligne.Id, ligne.Date, ligne.Montant, ligne.Entree, ligne.Sortie);
                        statutsTra.Add($"{t1.Id};KO");
                        statutsOpe.Add($"{ligne.Id};OK");

                        break;
                }
            }
        }
    }
}
