using System.Collections.Generic;
using System.Linq;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using System.IO;
using SRPH_DataBase;
using System;
using Db4objects.Db4o.Linq;

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

            var reservation = new Reservation(ReservationDataFrom, ReservationDataTo, RoomStandard, Name,Surename,PESEL,PhoneNumber);

            db.Store(reservation);
            db.Commit();
            db.Close();
        }
        public static void AddRooms(int roomID, int RoomNum, int Persons, string Beds)
            
        {
            string path = Directory.GetCurrentDirectory() + "\\database.srph";
            
            using (IObjectContainer db = Db4oEmbedded.OpenFile(path))
            {
                var room = new Rooms(roomID, RoomNum, Persons, Beds);

                db.Store(room);
                db.Commit();
                db.Close();
            }

            

        }
        public static Reservation GetReservation(int ResNumber)
        {
            string path = Directory.GetCurrentDirectory() + "\\database.srph";
            using (IObjectContainer db = Db4oEmbedded.OpenFile(path))
            {
                try
                {
                    var results = db.Query<Reservation>(x => x.ReservationID == ResNumber);
                    Reservation Reserv = results.First();
                    return Reserv;
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
           
            //jak jest puste to się wywala, trzeba to jakoś obudować
            //try catch łapiesz i wywalasz komuniakt ex brak rezerwacji o danym idp-

        }
        public static int GetRoomId()
        {
            string path = Directory.GetCurrentDirectory() + "\\database.srph";
            using (IObjectContainer db = Db4oEmbedded.OpenFile(path))
            {
                var result = (from Rooms r in db select r).ToList();

                int IdNumber = 1;

                if (result.Count!=0)
                {
                    foreach (var item in result)
                    {
                        if (item.RoomId==IdNumber)
                        {
                            IdNumber = (int)item.RoomId+1;
                        }
                    
                    }
                }
                else
                {
                    IdNumber = 1;
                }
                return IdNumber;
            }
        }

        public static int GetReservationId()
        {
            int back = 0;
            string path = Directory.GetCurrentDirectory() + "\\database.srph";
            using (IObjectContainer db = Db4oEmbedded.OpenFile(path))
            {
                var result = (from Reservation r in db select r).ToList();

                int IdNumber = 1;

                if (result.Count != 0)
                {
                    foreach (var item in result)
                    {
                        if (item.ReservationID == IdNumber)
                        {
                            IdNumber = (int)item.ReservationID + 1;
                        }

                    }
                }
                else
                {
                    IdNumber = 1;
                }
                return IdNumber;
            }
        }

        public static List<Rooms> GetFreeRooms()
        {
            string path = Directory.GetCurrentDirectory() + "\\database.srph";

            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

            config.Common.ObjectClass(typeof(Reservation)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(Reservation)).CascadeOnDelete(true);

            config.Common.ObjectClass(typeof(Reservation)).CascadeOnActivate(true);

            List<Rooms> Room = new List<Rooms>();
            using (IObjectContainer db = Db4oEmbedded.OpenFile(config, path))
            {
                //Room = (from Rooms r in db select r).ToList().Where(r=>r.Booked==true);
            }
     
            return Room;

        }

        public static void DeleteRoom(int roomID)
        {
            string path = Directory.GetCurrentDirectory() + "\\database.srph";
           
            using (IObjectContainer db = Db4oEmbedded.OpenFile(path))
            {
                var result = db.Query<Rooms>(x => x.RoomId == roomID);

                db.Delete(result);
                db.Commit();
                db.Close();
            }
            

        }

        public static void DeleteReservation (int ResID)
        {
            string path = Directory.GetCurrentDirectory() + "\\database.srph";
            

            using (IObjectContainer db = Db4oEmbedded.OpenFile(path))
            {
                var result = db.Query<Reservation>(x => x.ReservationID == ResID);
                db.Delete(result);
                db.Commit();
                db.Close();
            }
            
        }

        public static IList<Rooms> GetRoom(int ID)
        {
            string path = Directory.GetCurrentDirectory() + "\\database.srph";
            
            using (IObjectContainer db = Db4oEmbedded.OpenFile(path))
            {
                var Room = db.Query<Rooms>(x => x.RoomId == ID);
                return Room;
            }
            
        }

        //TODO dodac metodę getRoom dającą dane pokoju po ID do edycji
        public static IList<Rooms> GetRooms ()
        {
            string path = Directory.GetCurrentDirectory() + "\\database.srph";

            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

            config.Common.ObjectClass(typeof(Rooms)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(Rooms)).CascadeOnDelete(true);
            config.Common.ObjectClass(typeof(Rooms)).CascadeOnActivate(true);

            List<Rooms> Rooms;
            using (IObjectContainer db = Db4oEmbedded.OpenFile(config, path))
            {
                Rooms = (from Rooms r in db select r).ToList();
            }
            return Rooms.ToList<Rooms>();

        }

        public static List<Reservation> GetReservations()
        {
            string path = Directory.GetCurrentDirectory() + "\\database.srph";

            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

            config.Common.ObjectClass(typeof(Reservation)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(Reservation)).CascadeOnDelete(true);

            config.Common.ObjectClass(typeof(Reservation)).CascadeOnActivate(true);

            List<Reservation> Reservations; 
            using (IObjectContainer db = Db4oEmbedded.OpenFile(config, path))
            {
                Reservations = (from Reservation r in db select r).ToList();
            }
            return Reservations.ToList<Reservation>();

        }
        public static void ShowFreeRoom(DateTime TimeStart, DateTime TimeEnd)
        {
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Directory.GetCurrentDirectory() + "\\database.srph"))
            {

            }
        }
    }
}


       
