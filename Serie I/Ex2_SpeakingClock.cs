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
            string str="";
            string str1 = "Merveilleuse nuit !";
            string str2 = "Bonne matinée !";
            string str3 = "Bon appétit !";
            string str4 = "Profitez de votre après-midi !";
            string str5 = "Passez une bonne soirée !";
           
            if (heure >= 0 && heure <= 6)
            {
             //   Console.WriteLine("il est " + heure + "H" + "," );
                str=str1;
            }
            if (heure > 6 && heure <= 12)
            {
                //   Console.WriteLine("il est " + heure + "H" + "," + str2);
                str = str2;
            }
            if (heure == 12)
            {
                //   Console.WriteLine("il est " + heure + "H" + "," + str3);
                str = str3;
            }
            if (heure>=13 && heure <= 18)
            {
                //   Console.WriteLine("il est "+heure+"H"+","+str4);
                str = str4;
            }
            if(heure>18 && heure<24)
            {
                //  Console.WriteLine("il est "+heure+"H"+","+str5);
                str = str5;
            }
            Console.Write("il est " + heure + "H" + ",");
            Console.Write(" " + str );
            Console.WriteLine("   ");
            return str;

            
        }
            
        }
    }

