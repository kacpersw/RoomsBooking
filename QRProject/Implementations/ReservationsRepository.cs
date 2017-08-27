using QRProject.Interfaces;
using QRProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QRProject.Implementations
{
    public class ReservationsRepository : IReservationsRepository
    {

        private ReservationDatabaseEntities _database;

        public ReservationsRepository(ReservationDatabaseEntities database)
        {
            _database = database;
        }

        public IEnumerable<Reservations> SelectAll()
        {
            return _database.Reservations.ToArray();
        }

        public bool Delete(int id)
        {

            var deleteReservation = _database.Reservations.FirstOrDefault(
                reservation => reservation.ReservationId == id);

            if (deleteReservation != null)
            {
                _database.Entry(deleteReservation).State = EntityState.Deleted;
                _database.SaveChanges();

                return true;
            }

            return false;
        }

        public bool Insert(Reservations reservation)
        {
            if (reservation != null)
            {
                _database = new ReservationDatabaseEntities();
                _database.Entry(reservation).State = EntityState.Added;
                _database.SaveChanges();

                return true;
            }

            return false;
        }

        public bool Insert(int roomNr, int userId, System.DateTime day, 
            System.TimeSpan startHour, System.TimeSpan endHour)
        {

            var room = _database.Rooms.FirstOrDefault(v => v.RoomNr == roomNr);

            if (room == null)
                return false;

            Reservations reservation = new Reservations()
            {
                Day = day,
                StartHour = startHour,
                EndHour = endHour,
                UserId = userId,
                RoomId = room.RoomId
            };


            foreach (var item in _database.Reservations.Where(v => v.RoomId == room.RoomId))
            {
                if (item.Day == day)
                {
                    if (item.StartHour <= startHour && item.EndHour >= startHour)
                    {
                        return false;
                    }
                    if (item.StartHour <= item.EndHour && item.EndHour >= endHour)
                    {
                        return false;
                    }

                    if (item.StartHour >= startHour && item.EndHour <= endHour)
                    {
                        return false;
                    }
                    if (item.StartHour <= endHour && item.EndHour >= endHour)
                    {
                        return false;
                    }
                }
            }

            if (reservation != null)
            {

                _database.Entry(reservation).State = EntityState.Added;
                _database.SaveChanges();

                return true;
            }

            return false;
        }

    }
}