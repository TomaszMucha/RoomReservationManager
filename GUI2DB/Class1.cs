using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using SRPH_DataBase;

namespace GUI2DB
{
    public class Class1
    {
        public static void CreateReservation(object sender)
        {
            if (true)
            {
                //tets podłaczenia do bazy danych
                //Rooms test = new Rooms();
                //test.
                var reservations = new List<Reservation>();
                var reservation = new Reservation();
                IObjectSet result = db.QueryByExample(typeof(Reservation));

                foreach (var x in result)
                {
                    reservation = (Reservation)x;
                    reservations.Add(new Reservation


                    {
                        IdRoom = reservation.IdRoom,
                        IdClient = reservation.IdClient,
                        ReservationDataFrom = reservation.ReservationDataFrom,
                        ReservationDataTo = reservation.ReservationDataTo,
                        RoomStandard = reservation.RoomStandard.ToList();
                    )
                    };
                           
                   
                }

            }


        }
    }
}
