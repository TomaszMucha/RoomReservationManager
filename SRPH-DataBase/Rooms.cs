using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPH_DataBase
{
    public class Rooms
    {
        public int? RoomId { get; set; }
        public int? NumerPokoju { get; set; }
        public int? IlośćOsób { get; set; }
        public string TypŁóżek { get; set; }
        public bool Booked { get; set; }

        public Rooms(int? RoomID,int? RoomNumber, int? NumberOfPersons, string TypeOfBeds)
        {

            this.RoomId = RoomID;
            this.NumerPokoju = RoomNumber;
            this.IlośćOsób = NumberOfPersons;
            this.TypŁóżek = TypeOfBeds;
            this.Booked = false;
        }
    }
}
