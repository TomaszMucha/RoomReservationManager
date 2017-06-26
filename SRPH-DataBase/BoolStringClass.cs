using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPH_DataBase
{
    public class BoolStringClass
    {
        private object standardName;
        private object standardPrice;
        private object isPermamentOrIsNotPermament;

        public BoolStringClass(object standardName, object standardPrice, object isPermamentOrIsNotPermament)
        {
            this.standardName = standardName;
            this.standardPrice = standardPrice;
            this.isPermamentOrIsNotPermament = isPermamentOrIsNotPermament;
        }

        public string StandardName { get; set; }
        public int StandardPrice { get; set; }
        public bool IsPermamentOrIsNotPermament { get; set; }
    }
}
