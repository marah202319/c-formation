using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Serie_IV
{
    public class PhoneBook
    {
        private Dictionary<string, string> _contacts;

        public PhoneBook()
        {
            _contacts = new Dictionary<string, string>();
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string format = @"^0[1-9]{8}$";
            Regex rgx = new Regex(format);
            return rgx.IsMatch(phoneNumber);

        }

        public bool ContainsPhoneContact(string phoneNumber)
        {
            if (IsValidPhoneNumber(phoneNumber))
                return _contacts.ContainsKey(phoneNumber);
            return false;
            throw new Exception("numero non trouvé !");
        }

        public void PhoneContact(string phoneNumber)
        {
            if (!ContainsPhoneContact(phoneNumber))
            {
                Console.WriteLine($"{phoneNumber} : {_contacts[phoneNumber]}");
            }
            else
            {
                throw new Exception("numero non trouvé !");
            }
        }

        public bool AddPhoneNumber(string phoneNumber, string name)
        {
            if (!ContainsPhoneContact(phoneNumber) && !String.IsNullOrWhiteSpace(name))
            {
                _contacts.Add(phoneNumber, name);
                return true;
            }
            else
            {
                return false;
                throw new Exception("numero deja existant ou nom non montionné !");
                
            }
            
        }

        public bool DeletePhoneNumber(string phoneNumber)
        {
            if (ContainsPhoneContact(phoneNumber))
            {
                _contacts.Remove(phoneNumber);
                return true;
            }
            else
            {
                return false;
                throw new Exception("numero non existant");              
            }
        }

        public void DisplayPhoneBook()
        {
            Console.WriteLine("Annuaire téléphonique :");
            Console.WriteLine("----------------------");
            if (_contacts.Count == 0)
            {
                Console.WriteLine("Annuaire est vide");
            }
            else
            {
                foreach (var contact in _contacts)
                {
                    PhoneContact(contact.Key);
                }
            }

        }
    }
}
