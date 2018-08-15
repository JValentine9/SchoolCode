using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager.Models
{
    enum EmailType { Work, Personal }
    class Email
    {
        public string Address { get; set; }
        public EmailType Type { get; set; }

        public override string ToString()
        {
            return $"Email Address: {Address}, {Type}"; 
        }
    }
}
