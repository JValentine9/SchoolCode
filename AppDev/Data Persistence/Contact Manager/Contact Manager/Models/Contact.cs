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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Email> Emails = new List<Email>();
        public List<PhoneNumber> PhoneNumbers = new List<PhoneNumber>();
    }
}
