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
        public DateTime DataRezerwacji_Od { get; set; }
        public DateTime DataRezerwacji_Do { get; set; }
        public List<string> RoomStandard { get; set; } = new List<string>();
        public string Imię { get; set; }
        public string Nazwisko { get; set; }
        public string PESEL { get; set; }
        public long NumerTelefonu { get; set; }
        public List<BoolStringClass> BoolStringClassList { get; set; }

        public Reservation(int ReservationID, int IdRoom, DateTime DataRezerwacji_Od, DateTime DataRezerwacji_Do, List<String> RoomStandard, string Name, string Surename, string PESEL, long PhoneNumber)
        {
            this.ReservationID = ReservationID;
            this.IdRoom = IdRoom;
            this.DataRezerwacji_Od = DataRezerwacji_Od;
            this.DataRezerwacji_Do = DataRezerwacji_Do;
            this.RoomStandard = RoomStandard;
            this.Imię = Name;
            this.Nazwisko = Surename;
            this.PESEL = PESEL;
            this.NumerTelefonu = PhoneNumber;
            this.BoolStringClassList = new List<BoolStringClass>();
        }
    }
}
