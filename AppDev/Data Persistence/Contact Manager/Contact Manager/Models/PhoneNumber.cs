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
        public int Number { get; set; }
        public PhoneType Type { get; set; }
    }
}
