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
        [ProtoMember(1)]
        public string Name { get; set; }

        [ProtoMember(2)]
        public PhoneNumber Phone { get; set; }

        [ProtoMember(3)]
        public Email EmailAddress { get; set; }
        //public List<Email> Emails = new List<Email>();

        //public List<PhoneNumber> PhoneNumbers = new List<PhoneNumber>();

        public override string ToString()
        {
            return $"Name: {Name} \n{Phone.ToString()} \n{EmailAddress.ToString()}";
        }
    }
}
