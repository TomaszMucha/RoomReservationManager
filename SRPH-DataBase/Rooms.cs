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
        public int? RoomNumber { get; set; }
        public int? NumberOfPersons { get; set; }
        public string TypeOfBeds { get; set; }
        public bool Booked { get; set; }

        public Rooms(int? RoomID,int? RoomNumber, int? NumberOfPersons, string TypeOfBeds)
        {

            this.RoomId = RoomID;
            this.RoomNumber = RoomNumber;
            this.NumberOfPersons = NumberOfPersons;
            this.TypeOfBeds = TypeOfBeds;
            this.Booked = false;
        }
    }
}
