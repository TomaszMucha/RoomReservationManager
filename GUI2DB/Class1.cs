using System.Collections.Generic;
using System.Linq;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using System.IO;
using SRPH_DataBase;

namespace GUI2DB
{
    public class Base
    {
        static string path = Directory.GetCurrentDirectory();
        IObjectContainer db;
        public List<Rooms> RoomsList { get; set; }
        public List<Reservation> ReservationList { get; set; }
        public List<Client> ClientList { get; set; }
        void test()
        {
            string path = Directory.GetCurrentDirectory();
            IObjectContainer db;
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

            config.Common.ObjectClass(typeof(Reservation)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(Reservation)).CascadeOnDelete(true);
            config.Common.ObjectClass(typeof(Reservation)).CascadeOnActivate(true);

            db = Db4oEmbedded.OpenFile(config, path);
        }

    }

    public class Class1
    {

        public static void CreateReservation(object sender)
        {

            if (true)
            {
                string path = Directory.GetCurrentDirectory();
                IObjectContainer db;
                IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

                config.Common.ObjectClass(typeof(Reservation)).CascadeOnUpdate(true);
                config.Common.ObjectClass(typeof(Reservation)).CascadeOnDelete(true);
                config.Common.ObjectClass(typeof(Reservation)).CascadeOnActivate(true);

                db = Db4oEmbedded.OpenFile(config, path);
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
                        RoomStandard = reservation.RoomStandard.ToList() });
                }
            }
        }
        public static void AddRooms()
            
        {
            string path = Directory.GetCurrentDirectory();
            IObjectContainer db;
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

            config.Common.ObjectClass(typeof(Reservation)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(Reservation)).CascadeOnDelete(true);
            config.Common.ObjectClass(typeof(Reservation)).CascadeOnActivate(true);

            db = Db4oEmbedded.OpenFile(config, path);
            var rooms = new List<Rooms>();
            var room = new Reservation();
            IObjectSet result = db.QueryByExample(typeof(Reservation));

            foreach (var x in result)
            {
                room = (Rooms)x;
                rooms.Add(new Rooms


                {
                    RoomId = room.RoomId,
                    RoomNumber = room.RoomNumber,
                    NumberOfPersons = room.NumberOfPersons,
                    NumberOfBeds = room.NumberOfBeds
                   
                });
            }

        }
        public static Reservation GetReservation(long PESEL)
        {
            var results = db.Query<Reservation>(x => x.PESEL == PESEL);
            Reservation Reserv = result.First();
            return Reserv;

        }
        
    }
}


       
