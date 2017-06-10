using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPH_DataBase
{
    public class Rooms
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int NumberOfPersons { get; set; }
        public string NumberOfBeds { get; set; }
        public bool Booked { get; set; }
    }
}
