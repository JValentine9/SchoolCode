using System;
using ProtoBuf;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySerialDemo.Models
{
    [ProtoContract]
    class Movies
    {
        [ProtoMember(1)]
        public int Runtime { get; set; }
       [ProtoMember(2)]
        public int Year { get; set; }
        [ProtoMember(3)]
        public String Director { get; set; }
        private string title ="[UNKNOWN TITLE]";
        [ProtoMember(4)]
        public String Title
        {
            get { return title; }
            set
            {

            }
        }

        public override string ToString()
        {
            return $"{title} ({Year}) - Drieted by {Director}";
        }
    }
}
