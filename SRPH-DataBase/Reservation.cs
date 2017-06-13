using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPH_DataBase
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int IdRoom { get; set; }
        public DateTime ReservationDataFrom { get; set; }
        public DateTime ReservationDataTo { get; set; }
        public List<string> RoomStandard { get; set; } = new List<string>();
        public string Name { get; set; }
        public string Surename { get; set; }
        public string PESEL { get; set; }
        public long PhoneNumber { get; set; }

        public Reservation(int IdRoom,DateTime ReservationDataFrom, DateTime ReservationDataTo, List<String> RoomStandard, string Name, string Surename, string PESEL, long PhoneNumber, int IdReservation = 0)
        {
            this.IdRoom = IdRoom;
            this.ReservationDataFrom = ReservationDataFrom;
            this.ReservationDataTo = ReservationDataTo;
            this.RoomStandard = RoomStandard;
            this.Name = Name;
            this.Surename = Surename;
            this.PESEL = PESEL;
            this.PhoneNumber = PhoneNumber;


        }
    }
}
