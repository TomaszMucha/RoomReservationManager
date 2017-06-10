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
        public static void AddRooms(int roomID, int RoomNum, int Persons, string Beds)
            
        {
            string path = Directory.GetCurrentDirectory();
            IObjectContainer db;
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

            config.Common.ObjectClass(typeof(Rooms)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(Rooms)).CascadeOnDelete(true);
            config.Common.ObjectClass(typeof(Rooms)).CascadeOnActivate(true);

            db = Db4oEmbedded.OpenFile(config, path);
            var rooms = new List<Rooms>();
            var room = new Rooms();
            IObjectSet result = db.QueryByExample(typeof(Rooms));

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
            string path = Directory.GetCurrentDirectory();
            IObjectContainer db;
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

            config.Common.ObjectClass(typeof(Reservation)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(Reservation)).CascadeOnDelete(true);
            config.Common.ObjectClass(typeof(Reservation)).CascadeOnActivate(true);

            db = Db4oEmbedded.OpenFile(config, path);
            var results = db.Query<Reservation>(x => x.PESEL == PESEL);
            Reservation Reserv = results.First();
            return Reserv;

        }

        public static IList<Rooms> GetFreeRooms()
        {
            IObjectContainer db = Db4oFactory.OpenFile("C:\baza");          
            var FreeRooms = db.Query<Rooms>(x=>x.Booked==false);
            return FreeRooms;

        }

        public static void DeleteRoom(int roomID)
        {
            string path = Directory.GetCurrentDirectory();
            IObjectContainer db;
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

            config.Common.ObjectClass(typeof(Rooms)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(Rooms)).CascadeOnDelete(true);
            config.Common.ObjectClass(typeof(Rooms)).CascadeOnActivate(true);

            db = Db4oEmbedded.OpenFile(config, path);
            var result= db.Query<Rooms>(x => x.RoomId == roomID);
            db.Delete(result);

        }
        public static void DeleteReservation (int ResID)
        {
            string path = Directory.GetCurrentDirectory();
            IObjectContainer db;
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

            config.Common.ObjectClass(typeof(Reservation)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(Reservation)).CascadeOnDelete(true);
            config.Common.ObjectClass(typeof(Reservation)).CascadeOnActivate(true);

            db = Db4oEmbedded.OpenFile(config, path);
            var result = db.Query<Reservation>(x => x.ReservationID == ResID);
            db.Delete(result);
        }
        
    }
}


       
