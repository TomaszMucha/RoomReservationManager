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
        public string NumberOfBeds { get; set; }
        public bool Booked { get; set; }

        public Rooms(int? RoomNumber, int? NumberOfPersons, string NumberOfBeds)
        {

            this.RoomId = 1;
            this.RoomNumber = RoomNumber;
            this.NumberOfPersons = NumberOfPersons;
            this.NumberOfBeds = NumberOfBeds;
            this.Booked = false;
        }
    }
}
