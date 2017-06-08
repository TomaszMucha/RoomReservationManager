﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;


namespace GUI2DB
{
    public class Class1
    {
        public static void CreateReservation(int roomnum)
        { 
            if ()
            {
                Rooms = new List<Room>();
                room = new Room();
                IObjectSet result = db.QueryByExample(typeof(Room));

                foreach (var x in result)
                {
                    room = (Room)x;
                    Rooms.Add(new Room
                    {
                        reservation = new Reservation
                        {
                            IDRoom = reservation.IdRoom == null ? "" : reservation.IdRoom,
                            IDClient = reservation.IdClient == null ? "" : reservation.IdClient,
                            ReservationDataFrom = reservation.ReservationDataFrom == null ? "" : reservation.ReservationDataFrom,
                            ReservationDataTo = reservation.ReservationDataTo == null ? "" : reservation.ReservationDataTo,
                            RoomStandard = reservation.RoomStandard == null ? "" : reservation.RoomStandard
                        },
                            IDRoom = reservation.IdRoom,
                            IDClient = reservation.IdClient,
                            ReservationDataFrom = reservation.ReservationDataFrom,,
                            ReservationDataTo = reservation.ReservationDataTo,
                            RoomStandard = reservation.RoomStandard
                    });
                }

        }

          
        }
}
