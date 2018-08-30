using System;
using ProtoBuf;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager.Models
{
    enum ContactType { Family, Friends, Coworkers};

    class Contact
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ContactType Type { get; set; }

        public List<Email> Emails = new List<Email>();

        public List<PhoneNumber> PhoneNumbers = new List<PhoneNumber>();

        public PhoneNumber Phone
        {
            get { return PhoneNumbers[0]; }
            set
            {
                PhoneNumbers.Add(value);
            }
        }

        public Email Email
        {
            get { return Emails[0]; }
            set
            {
                Emails.Add(value);
            }
        }

        public override string ToString()
        {
            string returnValue = $"Name: {FirstName} {LastName}, Type: {Type}";
            foreach (PhoneNumber p in PhoneNumbers)
            {
                returnValue += $"/n{p.ToString()}";
            }
            foreach (Email e in Emails)
            {
                returnValue += $"/n{e.ToString()}";
            }
            return returnValue;
        }

        public void EmailAdd(Email e)
        {
            Emails.Add(e);
        }

        public void PhoneAdd(PhoneNumber p)
        {
            PhoneNumbers.Add(p);
        }
    }
}
