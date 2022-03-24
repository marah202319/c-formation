using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serie_IV
{
    public class BusinessSchedule
    {
        private SortedDictionary<DateTime, DateTime> _emploi;
        public DateTime begindate { get; set; }
        public DateTime enddate { get; set; }
        public BusinessSchedule()
        {
            _emploi = new SortedDictionary<DateTime, DateTime>();
            begindate = new DateTime(2020, 01, 01);
            enddate = new DateTime(2030, 12, 31);
        }
        public bool IsEmpty()
        {
            if (_emploi.Count == 0)
                return true;
            return false;
        }

        public void SetRangeOfDates(DateTime begin, DateTime end)
        {
            if (!IsEmpty())
            {
                begindate = begin;
                enddate = end;
            }
            else
            {
                throw new Exception("!!!!!!");
            }

        }

        private KeyValuePair<DateTime, DateTime> ClosestElements(DateTime beginMeeting)
        {
            DateTime datemin = DateTime.MinValue;
            DateTime datemax = DateTime.MaxValue;

            foreach (DateTime meeting in _emploi.Keys)
            {
                if (beginMeeting >= meeting)
                {
                    datemin = meeting;
                }
                else if (beginMeeting <= meeting)
                {
                    datemax = meeting;
                }
            }
            return new KeyValuePair<DateTime, DateTime>(datemin, datemax);
        }

        public bool AddBusinessMeeting(DateTime date, TimeSpan duration)
        {

            if (date > begindate && date + duration < enddate)
            {
                var closes = ClosestElements(date);
                //DateTime reuPrecedente = closes.Key;
                //DateTime reuSuivante = closes.Value;
                //_emploi[closes.Key]
                DateTime finReuPrec = closes.Key == DateTime.MinValue ? closes.Key : _emploi[closes.Key];
                if (finReuPrec <= date && closes.Value >= date + duration)
                {
                    _emploi.Add(date, date + duration);
                    return true;
                }

            }

            return false;
        }

        public bool DeleteBusinessMeeting(DateTime date, TimeSpan duration)
        {
            if (_emploi.ContainsKey(date))
            {
                _emploi.Remove(date);
                return true;
            }
            return false;
        }

        public int ClearMeetingPeriod(DateTime begin, DateTime end)
        {
            int nbrdel = 0;
            foreach (var meeting in _emploi.Keys)
            {
                // if(ClosestElements(begin))
                if (meeting > begin && meeting < end)
                {
                    _emploi.Remove(meeting);
                    nbrdel++;
                }
            }
            return nbrdel;
        }

        public void DisplayMeetings()
        {
            Console.WriteLine("Emploi du temps :" + begindate + "  -  " + enddate);
            Console.WriteLine("----------------------");
            if (IsEmpty())
            {
                Console.WriteLine("Pas de réunions programmées");
            }
            int i = 1;
            foreach (var e in _emploi)
            {
                //Console.WriteLine("Réunion " + i + " : " + e.Key.ToString("dd/MM/YYYY HH:mm:ss") + "  -  " + e.Value.ToString("dd/MM/YYYY HH:mm:ss"));
                Console.WriteLine("Réunion " + i + "      : " + e.Key + "  -  " + e.Value);
                i++;
            }
        }
    }
}
