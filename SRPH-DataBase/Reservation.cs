using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPH_DataBase
{
    public class Reservation
    {
        public int IdRoom { get; set; }
        public int IdClient { get; set; }
        public DateTime ReservationDataFrom { get; set; }
        public DateTime ReservationDataTo { get; set; }
        public List<string> RoomStandard { get; set; } = new List<string>();
        public string Name { get; set; }
        public string Surename { get; set; }
        public long PESEL { get; set; }
        public long PhoneNumber { get; set; }
    }
}
