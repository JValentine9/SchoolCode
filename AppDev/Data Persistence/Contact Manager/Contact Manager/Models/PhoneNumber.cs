using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manager.Models
{
    enum PhoneType {Work, Personal, Home };
    class PhoneNumber
    {
        public string Number { get; set; }
        public PhoneType Type { get; set; }

        public override string ToString()
        {
            return $"Phone Number: {Number}, {Type}";
        }
    }
}
