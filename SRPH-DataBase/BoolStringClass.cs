using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPH_DataBase
{
    public class BoolStringClass
    {
        //private string standardName;
        //private int standardPrice;
        //private bool isPermamentOrIsNotPermament;

        public BoolStringClass(string standardName, int standardPrice, bool isPermamentOrIsNotPermament)
        {
            StandardName = standardName;
            StandardPrice = standardPrice;
            IsPermamentOrIsNotPermament = isPermamentOrIsNotPermament;
        }

        public string StandardName { get; set; }
        public int StandardPrice { get; set; }
        public bool IsPermamentOrIsNotPermament { get; set; }
    }
}
