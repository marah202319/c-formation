using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_II
{
    public struct Qcm
    {
        public string Question;
        public string[] Answers;
        public int Solution;
        public int Weight;

        public Qcm(string question, string[] answers, int solution, int weight)
        {
            Question = question;
            Answers = answers;
            Solution = solution;
            Weight = weight;
        }
    }

    public static class Quiz
    {
        public static void AskQuestions(Qcm[] qcms)
        {
            int score = 0;
            for(int i = 0; i < qcms.Length; i++)
            {
                score+=AskQuestion(qcms[i]);
                
            }
            Console.WriteLine("Resultats du questionnaire : " +score+"/"+qcms.Length);
        }

        public static int AskQuestion(Qcm qcm)
        {
            if (QcmValidity(qcm))
            {
                Console.WriteLine(qcm.Question);
                for(int i = 0; i < qcm.Answers.Length; i++)
                {
                    Console.Write((i+1) +"."+qcm.Answers[i] + "  ");

                }
                Console.WriteLine("  ");
                Console.WriteLine("Réponse : ");
                String rep = Console.ReadLine();
                int reponse;
                int.TryParse(rep,out reponse);

                while (reponse > qcm.Answers.Length || reponse <0 )
                {
                    Console.WriteLine("Reponse invalide !");
                    Console.WriteLine("Réponse : ");
                    rep = Console.ReadLine();                    
                    int.TryParse(rep, out reponse);
                }
                if (qcm.Solution == reponse)
                {
                    return qcm.Weight;
                }
            }
            else
            {
                Console.WriteLine("exception !");
                //throw new ArgumentException("Question non valide");
            }

            return 0;

        }

        public static bool QcmValidity(Qcm qcm)
        {
            if (qcm.Solution >= 0 && qcm.Solution < qcm.Answers.Length && qcm.Weight > 0)
                return true;
            return false;
        }
    }
}
