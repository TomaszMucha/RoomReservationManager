﻿using System.Collections.Generic;
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
        static string path = Directory.GetCurrentDirectory()+"\\database.srph";
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

                db.Store(reservation);
                
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
            
            var room = new Rooms();
            room.RoomId = roomID;
            room.Booked = false;
            room.NumberOfBeds = Beds;
            room.NumberOfPersons = Persons;
            room.RoomNumber = RoomNum;

            db.Store(room);

        }
        public static Reservation GetReservation(int ResNumber)
        {
            string path = Directory.GetCurrentDirectory();
            IObjectContainer db;
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();

            config.Common.ObjectClass(typeof(Reservation)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(Reservation)).CascadeOnDelete(true);
            config.Common.ObjectClass(typeof(Reservation)).CascadeOnActivate(true);

            db = Db4oEmbedded.OpenFile(config, path);
            var results = db.Query<Reservation>(x => x.ReservationID == ResNumber);
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
        public static IList<Rooms> GetRoom(int ID)
        {
            IObjectContainer db = Db4oFactory.OpenFile("C:\baza");
            var Room = db.Query<Rooms>(x => x.RoomId == ID);
            return Room;
        }
        //TODO dodac metodę getRoom dającą dane pokoju po ID do edycji
        
    }
}


       
