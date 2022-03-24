using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_IV
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBook p = new PhoneBook();
            p.AddPhoneNumber("0123456789", "TOTO");
            p.AddPhoneNumber("0751800000", "TiTi");
            p.DisplayPhoneBook();           
            BusinessSchedule e = new BusinessSchedule();
            TimeSpan duration = new TimeSpan(1, 12, 23, 62);
            e.AddBusinessMeeting(DateTime.Now, duration);
         //   e.AddBusinessMeeting(DateTime.UtcNow, duration);

            e.DisplayMeetings();
            // Keep the console window open
            Console.WriteLine("----------------------");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}

