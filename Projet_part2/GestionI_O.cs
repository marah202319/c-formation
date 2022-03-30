using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_part2
{
	public class GestionI_O
	{
        Dictionary<int, Gestionnaires> gestionnaires = new Dictionary<int, Gestionnaires>();
        public void LireGestionnaires(string path)
        {
           // List<Gestionnaires> ges = new List<Gestionnaires>();
            string[] data;
            int nbTransactions=0;

            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    data = reader.ReadLine().Split(';');
                    if (data.Length == 3)
                    {
                        //foreach(Gestionnaires g in ges)
                        data[2]=data[2].Replace(".",",");
                        string stringId = data[0];
                        int.TryParse(data[2], out nbTransactions);
                        if(data[1]=="Particulier" && nbTransactions > 0)
                        {
                            gestionnaires.Add(int.Parse(stringId),new Gestionnaires(int.Parse(stringId),Gestionnaires.TypeGestionnaire.Particulier,nbTransactions));
                        }
                        if(data[1]=="Entreprise" && nbTransactions > 0)
                        {
                            gestionnaires.Add(int.Parse(stringId),new Gestionnaires(int.Parse(stringId),Gestionnaires.TypeGestionnaire.Entreprise,nbTransactions));
                        }

                    }              
                
                }            
            }
        }
		Dictionary<int, Compte> comptes = new Dictionary<int, Compte>();

		public void LireComptes(string acctPath)
		{
			using (StreamReader sr = new StreamReader(acctPath))
			{
				while (!sr.EndOfStream)
				{
					int id;
					double solde = 0;
                    DateTime date;
                    int entree=0;
                    int sortie=0;

					string stringsolde = "";
                    string stringdate = "";
                    string stringentree="";
                    string stringsortie="";
					string[] data = sr.ReadLine().Split(';');
					if (data.Length > 0)
					{
						string stringId = data[0];
						if (data.Length == 5)
						{
							stringsolde = data[2].Replace('.', ',');
                            stringdate= data[1];
                            stringentree=data[3];
                            stringsortie=data[4];
                            


						}
                        
						if (int.TryParse(stringId, out id) && int.TryParse(stringentree, out entree) && int.TryParse(stringsortie, out sortie)&& DateTime.TryParse(stringdate,out date )&& !comptes.ContainsKey(id))
						{
							if ( string.IsNullOrWhiteSpace(stringsolde))
							{
                               // stringsolde = "0";
                               //solde = 0 ;
                               //Compte(int id,DateTime dateCrea, double solde=0,int entree,int sortie)
								comptes.Add(id, new Compte(id,date,0,entree,sortie));
							}
							else if (double.TryParse(stringsolde, out solde) && solde >= 0)
							{
								comptes.Add(id, new Compte(id,date,solde,entree,sortie));

							}
						}
					}
				}
			}
		}
        Dictionary<int, Transaction> transactions = new Dictionary<int, Transaction>();
        int id1;
		public void LireTransactions(string trxnPath)
		{
			using (StreamReader sr = new StreamReader(trxnPath))
			{				
				while (!sr.EndOfStream)
				{
					string Data1 = sr.ReadLine();
					string[] data = Data1.Split(';');
					string stringId = data[0];
                    string stringdate = data[1];
					string stringSolde = data[2].Replace('.', ',');
					string stringTransmetteur = data[3];
					string stringRecepteur = data[4];
					int id;        
                    DateTime date=DateTime.Parse(data[1]);
					double solde;
                    int transmetteur=0;
                    int recepteur=0;
                    Transaction transaction;
                   
                                        
                    if (int.TryParse(stringId, out id) && DateTime.TryParse(stringdate,out date ) && double.TryParse(stringSolde, out solde) && int.TryParse(stringTransmetteur, out transmetteur) && int.TryParse(stringRecepteur, out recepteur) && !transactions.ContainsKey(id))
                    {
                        //Transaction (TransactionType type, TransactionStatus status,OperationStatus opestat,DateTime dateTransaction, int id=0, double somme=0,int transmetteur=0,int recepteur=0)
                        transaction = new Transaction(Transaction.TransactionType.Virement,Transaction.TransactionStatus.OK,Transaction.OperationStatus.KO,date,id,solde,transmetteur,recepteur);
					
					    if (transmetteur == 0 && recepteur != 0)
                        {
                            transaction.Type = Transaction.TransactionType.Depot;
                           
                        }
					    else if (recepteur == 0 && transmetteur != 0)
                        {
                            transaction.Type = Transaction.TransactionType.Retrait;
                           
                        }
					     else if (recepteur == 0 && transmetteur == 0)
                        {
							 transaction.Status = Transaction.TransactionStatus.KO;                            
                        }
					  transactions.Add(id, transaction);
					}	
					  else if (int.TryParse(stringId, out id) && !transactions.ContainsKey(id))
                    {
                        transaction = new Transaction(Transaction.TransactionType.Virement,Transaction.TransactionStatus.KO,Transaction.OperationStatus.KO,date,id);
                        transactions.Add(id, transaction);
                    }         
                      else
                    {
                        id1=id;
                        transaction = new Transaction(Transaction.TransactionType.Virement,Transaction.TransactionStatus.KO,Transaction.OperationStatus.KO,date);
                        transactions.Add(-id, transaction);
                    }	
					}
				}
			}        
		private void Traitements()
        {
            Console.Write("     ");
            foreach (var account in comptes)
            {               
                 Console.Write(account.Value.Solde.ToString("F")+ " ");
                 Console.WriteLine(account.Value.Date);
            }
            Console.WriteLine();

            foreach (var t in transactions)
            {
                Console.WriteLine(t.Value.DateTransaction);
                if (t.Value.Status == Transaction.TransactionStatus.OK)
                {
                    if (t.Value.Type == Transaction.TransactionType.Depot)
                    {
                        if (comptes.ContainsKey(t.Value.Recepteur))
                        {
                            if (comptes[t.Value.Recepteur].depot(t.Value.Somme, t.Value))
                                t.Value.Status = Transaction.TransactionStatus.OK;
                            else
                                t.Value.Status = Transaction.TransactionStatus.KO;
                        }
                        else
                            t.Value.Status = Transaction.TransactionStatus.KO;

                    }
                    if (t.Value.Type == Transaction.TransactionType.Retrait)
                    {
                        if (comptes.ContainsKey(t.Value.Transmetteur))
                        {
                            if (comptes[t.Value.Transmetteur].retrait(t.Value.Somme, t.Value))
                                t.Value.Status = Transaction.TransactionStatus.OK;
                            else
                                t.Value.Status = Transaction.TransactionStatus.KO;
                        }
                        else
                            t.Value.Status = Transaction.TransactionStatus.KO;
                    }
                    if (t.Value.Type == Transaction.TransactionType.Virement)
                    {
                        if (comptes.ContainsKey(t.Value.Transmetteur) && comptes.ContainsKey(t.Value.Recepteur) && t.Value.Recepteur != t.Value.Transmetteur)
                        {
                            if (t.Value.Somme > 0 && comptes[t.Value.Transmetteur].retrait(t.Value.Somme, t.Value))
                            {
                               Transaction transaction = new Transaction(Transaction.TransactionType.Prelevement,Transaction.TransactionStatus.OK,Transaction.OperationStatus.KO,DateTime.Now,t.Value.Id,t.Value.Somme,t.Value.Recepteur,t.Value.Transmetteur);
                               comptes[t.Value.Recepteur].depot(t.Value.Somme, transaction);
                               t.Value.Status = Transaction.TransactionStatus.OK;
                            }
                            else
                                t.Value.Status = Transaction.TransactionStatus.KO;
                        }
                        else
                            t.Value.Status = Transaction.TransactionStatus.KO;
                    }
                }
                if (t.Key > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append($"{t.Key} {t.Value.Status} ");
                    foreach (var account in comptes)
                    {
                        sb.Append(account.Value.Solde.ToString("F")+ " ");
                    }
                    Console.WriteLine(sb.ToString());
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append($"{t.Value.Id} {t.Value.Status} ");
                    foreach (var account in comptes)
                    {
                        sb.Append(account.Value.Solde.ToString("F")+ " ");
                    }
                    Console.WriteLine(sb.ToString());
                }
            }
        }
		public void EcrireTransactionsStatus(string sttsPath)
        {
            using (StreamWriter sw = new StreamWriter(sttsPath))
            {
                Traitements();
                foreach (var t in transactions)
                {
                    if (t.Key > 0)                       
                        sw.WriteLine(t.Key +";"+t.Value.Status);
                    else
                        sw.WriteLine(id1 +";"+t.Value.Status);
                }
            };
        }        
        public void EcrireOperationsStatus(string sttsPath)
        {
            using (StreamWriter sw = new StreamWriter(sttsPath))
            {
                Traitements();
                foreach (var t in transactions)
                {
                    if (t.Key > 0)                       
                        sw.WriteLine(t.Key +";"+t.Value.Opestat);
                    else
                        sw.WriteLine(id1 +";"+t.Value.Opestat);
                }
            };
        }  
		}
	}