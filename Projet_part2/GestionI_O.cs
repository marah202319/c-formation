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
        Dictionary<int, Gestionnaire> gestionnaires = new Dictionary<int, Gestionnaire>();

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
                        if(data[1]=="Particulier" && nbTransactions >= 0)
                        {
                            gestionnaires.Add(int.Parse(stringId),new Gestionnaires(int.Parse(stringId),Gestionnaire.TypeGestionnaire.Particulier,nbTransactions));
                        }
                        if(data[1]=="Entreprise" && nbTransactions >= 0)
                        {
                            gestionnaires.Add(int.Parse(stringId),new Gestionnaires(int.Parse(stringId),Gestionnaire.TypeGestionnaire.Entreprise,nbTransactions));
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
                        if(!int.TryParse(stringentree, out entree) || !int.TryParse(stringsortie, out sortie)){
                            if (string.IsNullOrWhiteSpace(stringentree)){
                                entree =0;
                            }
                            if (string.IsNullOrWhiteSpace(stringsortie)){
                                sortie=0;
                            }                        
                        }
                        
						if (int.TryParse(stringId, out id) && DateTime.TryParse(stringdate,out date )&& !comptes.ContainsKey(id))
						{
							if ( string.IsNullOrWhiteSpace(stringsolde))
							{
                              //  entree= int.Parse(stringentree);
                              //  sortie= int.Parse(stringsortie);
                               //if conditions  && int.TryParse(stringentree, out entree) && int.TryParse(stringsortie, out sortie)
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
                        transaction = new Transaction(Transaction.TransactionType.Virement,Transaction.TransactionStatus.KO,Transaction.OperationStatus.OK,date,id);
                        transactions.Add(id, transaction);
                    }         
                      else
                    {
                        id1=id;
                        transaction = new Transaction(Transaction.TransactionType.Virement,Transaction.TransactionStatus.KO,Transaction.OperationStatus.OK,date);
                        transactions.Add(-id, transaction);
                    }	
					}
				}
			}        
		private void Traitements()
        {
            Console.Write("     ");
            foreach(var g in gestionnaires)
            {
                Console.WriteLine("gestionnaire type : "+g.Value.typeGestionnaire);
            }
            foreach (var account in comptes)
            {               
                 Console.Write(account.Value.Solde.ToString("F")+ " ");
                 Console.WriteLine("date compte : "+account.Value.Date);
            }
            Console.WriteLine();

            foreach (var t in transactions)
            {
                Console.WriteLine("date transaction :" +t.Value.DateTransaction);
                if (t.Value.Status == Transaction.TransactionStatus.OK)
                {
                    if (t.Value.Type == Transaction.TransactionType.Depot)
                    {
                        if (comptes.ContainsKey(t.Value.Recepteur))
                        {
                            if (comptes[t.Value.Recepteur].depot(t.Value.Somme, t.Value))
                            {
                                t.Value.Status = Transaction.TransactionStatus.OK;
                                //t.Value.Opestat = Transaction.OperationStatus.OK;
                            }
                                
                            else
                                t.Value.Status = Transaction.TransactionStatus.KO;
                                //t.Value.Opestat = Transaction.OperationStatus.KO;
                        }
                        else
                            t.Value.Status = Transaction.TransactionStatus.KO;
                           // t.Value.Opestat = Transaction.OperationStatus.KO;
                    }
                    if (t.Value.Type == Transaction.TransactionType.Retrait)
                    {
                        if (comptes.ContainsKey(t.Value.Transmetteur))
                        {
                            if (comptes[t.Value.Transmetteur].retrait(t.Value.Somme, t.Value)){
                                t.Value.Status = Transaction.TransactionStatus.OK;
                               // t.Value.Opestat = Transaction.OperationStatus.OK;
                            }                                
                            else{
                                t.Value.Status = Transaction.TransactionStatus.KO;
                                //t.Value.Opestat = Transaction.OperationStatus.KO;
                            }                              
                        }
                        else{
                            t.Value.Status = Transaction.TransactionStatus.KO;
                           // t.Value.Opestat = Transaction.OperationStatus.KO;                        
                        }
                            
                    }
                    if (t.Value.Type == Transaction.TransactionType.Virement)
                    {
                        if (comptes.ContainsKey(t.Value.Transmetteur) && comptes.ContainsKey(t.Value.Recepteur) && t.Value.Recepteur != t.Value.Transmetteur)
                        {
                            if (t.Value.Somme > 0 && comptes[t.Value.Transmetteur].retrait(t.Value.Somme, t.Value))
                            {
                               Transaction transaction = new Transaction(Transaction.TransactionType.Prelevement,Transaction.TransactionStatus.OK,Transaction.OperationStatus.OK,DateTime.Now,t.Value.Id,t.Value.Somme,t.Value.Recepteur,t.Value.Transmetteur);
                               comptes[t.Value.Recepteur].depot(t.Value.Somme, transaction);
                               t.Value.Status = Transaction.TransactionStatus.OK;
                               //t.Value.Opestat = Transaction.OperationStatus.OK;
                            }
                            else{
                                t.Value.Status = Transaction.TransactionStatus.KO;
                                //t.Value.Opestat= Transaction.OperationStatus.KO;
                            }
                                
                        }
                        else{
                             t.Value.Status = Transaction.TransactionStatus.KO;
                           // t.Value.Opestat= Transaction.OperationStatus.KO;
                        }                          
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
        private void Traitements1()
        {    
          Console.WriteLine("dsvdsfgs");           
            /*if(comptes[gestionnaires.Values].Entree!=0 && comptes[gestionnaires.Keys].Sortie==0 )
            {
              Creationc(comptes[gestionnaires.Keys].Id,comptes[gestionnaires.Keys].Date,comptes[gestionnaires.Keys].Solde,comptes[gestionnaires.Keys].Entree,comptes[gestionnaires.Keys].Sortie);               
            }*/
            foreach(var c in comptes)
            {                  
                if(c.Value.Entree !=0 && c.Value.Sortie==0)
                {                    
                    foreach (var t in transactions)
                    {
                        if (t.Value.Recepteur==c.Key || t.Value.Transmetteur==c.Key ){
                            if(gestionnaires.ContainsKey(c.Value.Entree)){
                                t.Value.Opestat= Transaction.OperationStatus.OK;
                                Creationc(c.Key,c.Value.Date,c.Value.Solde,c.Value.Entree,c.Value.Sortie);
                            }
                            else{
                                t.Value.Opestat= Transaction.OperationStatus.KO;
                            }                                
                        }                               
                    }
                }   
                if(c.Value.Entree ==0 && c.Value.Sortie!=0)
                {
                    Cloturec(c.Key,c.Value.Date,c.Value.Solde,c.Value.Entree,c.Value.Sortie); 
                    foreach (var t in transactions)
                    {
                        if (t.Value.Recepteur==c.Key || t.Value.Transmetteur==c.Key ){
                            if(gestionnaires.ContainsKey(c.Key)){
                                t.Value.Opestat= Transaction.OperationStatus.OK;
                            }
                            else{
                                t.Value.Opestat= Transaction.OperationStatus.KO;
                            }                             
                            
                        }                                
                    }
                }  
                if(c.Value.Entree ==0 && c.Value.Sortie!=0 && !gestionnaires.ContainsKey(c.Value.Sortie) )
                {
                    foreach (var t in transactions)
                    {
                        if (t.Value.Recepteur==c.Key || t.Value.Transmetteur==c.Key )
                                t.Value.Opestat= Transaction.OperationStatus.KO;
                    }
                }
                if(c.Value.Entree !=0 && c.Value.Sortie!=0 && gestionnaires.ContainsKey(c.Value.Sortie) && gestionnaires.ContainsKey(c.Value.Entree))
                {
                    //Cessionc();
                    ReceptionC();
                    foreach (var t in transactions)
                    {
                          t.Value.Opestat=Transaction.OperationStatus.OK; 
                    }    
                } 
                /*else
                {
                    t.Value.Opestat=Transaction.OperationStatus.OK;
                }*/
                
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
                Traitements1();                
                foreach (var t in transactions)
                {
                    if (t.Key > 0)                       
                        sw.WriteLine(t.Key +";"+t.Value.Opestat);
                    else
                        sw.WriteLine(id1 +";"+t.Value.Opestat);
                }
            };
        }  
        public void EcrireMetrologie(string sttsPath)
        {
            using (StreamWriter sw = new StreamWriter(sttsPath))
            {
                //Traitements();
                sw.WriteLine("Statistiques :");
                sw.WriteLine("Nombre de comptes :");
                sw.WriteLine("Nombre de transactions :");
                sw.WriteLine("Nombre de réussites :");
                sw.WriteLine("Nombre d'échecs :");
                sw.WriteLine("Montant total des réussites : "+0+" euros");
                sw.WriteLine();
                sw.WriteLine("Frais de gestions :");
                sw.WriteLine();
                sw.WriteLine("Identifant gestionnaire :"+0+" euros");
            };
        } 
        public void Creationc(int id, DateTime date, double solde = 0, int entree=0 , int sortie = 0)
        {
            foreach (var c in comptes)
            {
                if (id !=c.Key )
                {
                    //comptes.Add(-id,new Compte(id,date,solde,entree,sortie));
                    /*foreach(var t in transactions)
                    {
                        if (t.Key==id)
                    {
                        t.Value.Opestat =Transaction.OperationStatus.OK;                                
                    }
                    }*/
                    
                }
            }
        }
        public void Cloturec(int id, DateTime date, double solde = 0, int entree = 0, int sortie=0 )
        {
            foreach (var c in comptes)
            {
                if (id ==c.Key )
                {                    
                    comptes.Add(-id,new Compte(-id,DateTime.Now,0,0,sortie));
                    foreach(var t in transactions)
                    {
                        if (t.Key==id)
                    {
                        t.Value.Opestat =Transaction.OperationStatus.OK;                                
                    }
                    }
                }
            }
        }
        public void Cessionc(int id, DateTime date,int id1, DateTime date1, double solde = 0, int entree = 0, int sortie=0, double solde1 = 0, int entree1 = 0, int sortie1=0)
        {  
            int ide;
            /*DateTime datee;
            double soldee = 0;
            int entreee = 0;
            int sortiee=0;*/
                foreach(var g in gestionnaires)
            {
                if (id1 == g.Key && id == g.Key && comptes.ContainsKey(id1) && comptes.ContainsKey(id))
                {                    
                    ide=id;
                    //Compte(id,date,solde,entree,sortie)=Compte(id1,date1,solde1,entree1,sortie1);
                }
            } 
            
                                       
        }
        public void ReceptionC()
        {

        }
		}
	}