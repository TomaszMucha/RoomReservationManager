using System.Collections.Generic;
using System.Linq;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using System.IO;
using SRPH_DataBase;
using System;

namespace GUI2DB
{
    public class Base
    {
        static string path = Directory.GetCurrentDirectory() + "\\database.srph";
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

    public class GUI2DB
    {

        public static void CreateReservation(int IdRoom, int IdClient, DateTime ReservationDataFrom, DateTime ReservationDataTo, List<string> RoomStandard, string Name, string Surename, string PESEL, long PhoneNumber)
        {

            if (true)
            {
                string path = Directory.GetCurrentDirectory() + "\\database.srph";
                IObjectContainer db;
                IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

                config.Common.ObjectClass(typeof(Reservation)).CascadeOnUpdate(true);
                config.Common.ObjectClass(typeof(Reservation)).CascadeOnDelete(true);
                config.Common.ObjectClass(typeof(Reservation)).CascadeOnActivate(true);

                db = Db4oEmbedded.OpenFile(config, path);
                //tets podłaczenia do bazy danych
                //Rooms test = new Rooms();
                //test.

                var reservation = new Reservation();
                reservation.IdClient = IdClient;
                reservation.IdRoom = IdRoom;
                reservation.PESEL = PESEL;
                reservation.PhoneNumber = PhoneNumber;
                reservation.ReservationDataFrom = ReservationDataFrom;
                reservation.ReservationDataTo = ReservationDataTo;
                reservation.RoomStandard = RoomStandard;
                reservation.Surename = Surename;
                reservation.Name = Name;

                db.Store(reservation);
                db.Commit();
                db.Close();



            }
        }
        public static void AddRooms(int roomID, int RoomNum, int Persons, string Beds)
            
        {
            string path = Directory.GetCurrentDirectory() + "\\database.srph";
            IObjectContainer db;
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

            config.Common.ObjectClass(typeof(Rooms)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(Rooms)).CascadeOnDelete(true);
            config.Common.ObjectClass(typeof(Rooms)).CascadeOnActivate(true);

            db = Db4oEmbedded.OpenFile(config, path);
            
            var room = new Rooms(RoomNum, Persons, Beds);

            db.Store(room);
            db.Commit();
            db.Close();

        }
        public static Reservation GetReservation(int ResNumber)
        {
            string path = Directory.GetCurrentDirectory() + "\\database.srph";
            IObjectContainer db;
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

            config.Common.ObjectClass(typeof(Reservation)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(Reservation)).CascadeOnDelete(true);
            config.Common.ObjectClass(typeof(Reservation)).CascadeOnActivate(true);

            db = Db4oEmbedded.OpenFile(config, path);
            var results = db.Query<Reservation>(x => x.ReservationID == ResNumber);
            Reservation Reserv = results.First();
            return Reserv;
            //jak jest puste to się wywala, trzeba to jakoś obudować
            //try catch łapiesz i wywalasz komuniakt ex brak rezerwacji o danym idp-

        }
        public static int GetRoomId()
        {
            int back = 0;
            string path = Directory.GetCurrentDirectory() + "\\database.srph";
            using (IObjectContainer db = Db4oEmbedded.OpenFile(path))
            {
                IObjectSet result = db.QueryByExample(new Rooms(null, null, null));
                Rooms found;
                if (result.HasNext())
                {
                    do
                    {
                        found = (Rooms)result.Next();
                        if (found.RoomId > back)
                        {
                            back = (int)found.RoomId;
                        }
                    } while (result.HasNext());
                }
                else
                {
                    back = 1;
                }

                return back;
            }
        }
        public static IList<Rooms> GetFreeRooms()
        {
            IObjectContainer db = Db4oFactory.OpenFile("C:\baza");          
            var FreeRooms = db.Query<Rooms>(x=>x.Booked==false);
            return FreeRooms;

        }
        public static void DeleteRoom(int roomID)
        {
            string path = Directory.GetCurrentDirectory() + "\\database.srph";
            IObjectContainer db;
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

            config.Common.ObjectClass(typeof(Rooms)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(Rooms)).CascadeOnDelete(true);
            config.Common.ObjectClass(typeof(Rooms)).CascadeOnActivate(true);

            db = Db4oEmbedded.OpenFile(config, path);
            var result= db.Query<Rooms>(x => x.RoomId == roomID);
            
            db.Delete(result);
            db.Commit();
            db.Close();

        }
        public static void DeleteReservation (int ResID)
        {
            string path = Directory.GetCurrentDirectory() + "\\database.srph";
            IObjectContainer db;
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

            config.Common.ObjectClass(typeof(Reservation)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(Reservation)).CascadeOnDelete(true);
            config.Common.ObjectClass(typeof(Reservation)).CascadeOnActivate(true);

            db = Db4oEmbedded.OpenFile(config, path);
            var result = db.Query<Reservation>(x => x.ReservationID == ResID);
            db.Delete(result);
            db.Commit();
            db.Close();
        }
        public static IList<Rooms> GetRoom(int ID)
        {
            string path = Directory.GetCurrentDirectory() + "\\database.srph";
            IObjectContainer db;
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

            config.Common.ObjectClass(typeof(Rooms)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(Rooms)).CascadeOnDelete(true);
            config.Common.ObjectClass(typeof(Rooms)).CascadeOnActivate(true);

            db = Db4oEmbedded.OpenFile(config, path);
            var Room = db.Query<Rooms>(x => x.RoomId == ID);
            return Room;
        }
        //TODO dodac metodę getRoom dającą dane pokoju po ID do edycji
        public static IList<Rooms> GetRooms ()
        {
            string path = Directory.GetCurrentDirectory() + "\\database.srph";
            IObjectContainer db;
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

            config.Common.ObjectClass(typeof(Rooms)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(Rooms)).CascadeOnDelete(true);
            config.Common.ObjectClass(typeof(Rooms)).CascadeOnActivate(true);

            db = Db4oEmbedded.OpenFile(config, path);
            var Rooms = db.Query<Rooms>();
            db.Close();
            return Rooms;
        }
        public static IList<Reservation> GetReservations()
        {
            string path = Directory.GetCurrentDirectory() + "\\database.srph";
            IObjectContainer db;
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

            config.Common.ObjectClass(typeof(Reservation)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(Reservation)).CascadeOnDelete(true);
            config.Common.ObjectClass(typeof(Reservation)).CascadeOnActivate(true);

            db = Db4oEmbedded.OpenFile(config, path);
            var Reservations = db.Query<Reservation>();
            db.Close();
            return Reservations;
        }
    }
}


       
