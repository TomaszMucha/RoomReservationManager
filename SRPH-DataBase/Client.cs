using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPH_DataBase
{
    public class Client
    {
        public int IdClient { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public long PESEL { get; set; }
        public long PhoneNumber { get; set; }
    }
}
