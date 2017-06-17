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

    public class GUI2DB
    {

        public static void CreateReservation(int ReservationID,int IdRoom, int IdClient, DateTime DataRezerwacji_Od, DateTime DataRezerwacji_Do, List<string> RoomStandard, string Name, string Surename, string PESEL, long PhoneNumber)
        {
            string path = Directory.GetCurrentDirectory() + "\\database.srph";
            
            using (IObjectContainer db = Db4oEmbedded.OpenFile(path))
            {
                var reservation = new Reservation(ReservationID,IdRoom, DataRezerwacji_Od, DataRezerwacji_Do, RoomStandard, Name, Surename, PESEL, PhoneNumber);

                db.Store(reservation);
                db.Commit();
                db.Close();
            }

            
        }
        public static void AddRooms(int roomID, int RoomNum, int Persons, string Beds)
            
        {
            string path = Directory.GetCurrentDirectory() + "\\database.srph";
            //IObjectContainer db;
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

            config.Common.ObjectClass(typeof(Rooms)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(Rooms)).CascadeOnDelete(true);
            config.Common.ObjectClass(typeof(Rooms)).CascadeOnActivate(true);

            //db = Db4oEmbedded.OpenFile(config, path);

            using (IObjectContainer db = Db4oEmbedded.OpenFile(config, path))
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
           // IObjectContainer db;
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

            config.Common.ObjectClass(typeof(Reservation)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(Reservation)).CascadeOnDelete(true);
            config.Common.ObjectClass(typeof(Reservation)).CascadeOnActivate(true);

            //db = Db4oEmbedded.OpenFile(config, path);
            using (IObjectContainer db = Db4oEmbedded.OpenFile(config, path))
            {
                var results = db.Query<Reservation>(x => x.ReservationID == ResNumber);
                Reservation Reserv = results.First();
                return Reserv;
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
        public static IEnumerable<Rooms> GetFreeRooms()
        {
            string path = Directory.GetCurrentDirectory() + "\\database.srph";
                 
            using (IObjectContainer db = Db4oEmbedded.OpenFile(path))
            {
                //var Room = db.Query<Rooms>(x => x.Booked == false);
                var Room = (from Rooms r in db select r).ToList().Where(r=>r.Booked==false);
                // test var x = (from Rooms r in db where r.Booked == false select r).ToList();
                return Room;
            }
     
            

        }
        public static void DeleteRoom(int roomID)
        {
            string path = Directory.GetCurrentDirectory() + "\\database.srph";
            
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

            config.Common.ObjectClass(typeof(Rooms)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(Rooms)).CascadeOnDelete(true);
            config.Common.ObjectClass(typeof(Rooms)).CascadeOnActivate(true);

            
            using (IObjectContainer db = Db4oEmbedded.OpenFile(config, path))
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
            //IObjectContainer db;
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

            config.Common.ObjectClass(typeof(Reservation)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(Reservation)).CascadeOnDelete(true);
            config.Common.ObjectClass(typeof(Reservation)).CascadeOnActivate(true);

            using (IObjectContainer db = Db4oEmbedded.OpenFile(config, path))
            {
                var result = db.Query<Reservation>(x => x.ReservationID == ResID);
                db.Delete(result);
                db.Commit();
                db.Close();
            }

           // db = Db4oEmbedded.OpenFile(config, path);
           
        }
        public static Rooms GetRoom(int ID)
        {
            string path = Directory.GetCurrentDirectory() + "\\database.srph";

            
            using (IObjectContainer db = Db4oEmbedded.OpenFile(path))
            {
                var Room = db.Query<Rooms>(x => x.RoomId == ID);
                if (Room.Count() != 0)
                {
                    return Room.First();
                }
                else
                    throw new Exception("Ogarnij se to");

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
        public static bool IsRoomBooked(DateTime TimeStart, DateTime TimeEnd)
         {
             using (IObjectContainer db = Db4oEmbedded.OpenFile(Directory.GetCurrentDirectory() + "\\database.srph"))
             {
                
                
                var res = (from Reservation r in db select r).Where(r => r.DataRezerwacji_Od.CompareTo(TimeStart) > 0 && r.DataRezerwacji_Do.CompareTo(TimeEnd) < 0).ToList();
                if (res.Count == 0)
                {
                    return true;
                }
                else return false;


            }
         }
        public static bool DoesRoomExist (int roomNum)
        {
            using (IObjectContainer db = Db4oEmbedded.OpenFile(Directory.GetCurrentDirectory() + "\\database.srph"))
            {
                var Room = db.Query<Rooms>(x => x.NumerPokoju == roomNum);
                if (Room.Count() == 0)
                {
                    return false;
                }
                else
                    return true;
                
            }
        }


}
}


       
