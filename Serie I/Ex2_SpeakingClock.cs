using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_I
{
    public static class SpeakingClock
    {
        public static string GoodDay(int heure)
        {
            string str1 = "Merveilleuse nuit !";
            string str2 = "Bonne matinée !";
            string str3 = "Bon appétit !";
            string str4 = "Profitez de votre après-midi !";
            string str5 = "Passez une bonne soirée !";
            if(heure>=00 && heure <= 6)
            {
                Console.WriteLine("il est "+heure+"H"+","+str1);
            }
            if (heure >= 00 && heure <= 6)
            {
                Console.WriteLine("il est " + heure + "H" + "," + str1);
            }
            if (heure >= 00 && heure <= 6)
            {
                Console.WriteLine("il est " + heure + "H" + "," + str1);
            }
            if (heure >= 00 && heure <= 6)
            {
                Console.WriteLine("il est " + heure + "H" + "," + str1);
                 if(heure>=00 && heure <= 6)
            {
                Console.WriteLine("il est "+heure+"H"+","+str1);
            }
            if(heure>=00 && heure <= 6)
            {
                Console.WriteLine("il est "+heure+"H"+","+str1);
            }
            if (heure >= 00 && heure <= 6)
            {
                    Console.WriteLine("il est " + heure + "H" + "," + str1);
            }
            }
            return string.Empty;
        }
    }
}
