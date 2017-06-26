using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPH_DataBase
{
    public class BoolStringClass
    {
        private string standardName;
        private int standardPrice;
        private bool isPermamentOrIsNotPermament;

        public BoolStringClass(string standardName, int standardPrice, bool isPermamentOrIsNotPermament)
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
