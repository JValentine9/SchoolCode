using System;
using ProtoBuf;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager.Models
{
    [ProtoContract]
    class Contact
    {
        public string Name { get; set; }

        public PhoneNumber Phone { get; set; }

        public Email EmailAddress { get; set; }
        //public List<Email> Emails = new List<Email>();

        //public List<PhoneNumber> PhoneNumbers = new List<PhoneNumber>();
    }
}
