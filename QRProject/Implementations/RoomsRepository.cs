using QRProject.Interfaces;
using QRProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using QRProject.ViewModels;

namespace QRProject.Implementations
{
    public class RoomsRepository : IRoomsRepository
    {

        private readonly ReservationDatabaseEntities _database;

        public RoomsRepository(ReservationDatabaseEntities database)
        {
            _database = database;
        }

        public IEnumerable<Rooms> SelectAll()
        {
            return _database.Rooms.ToArray();
        }

        public bool Delete(int id)
        {
            try
            {
                var rooms = _database.Rooms.Include(relation => relation.Reservations);
                var deleteRoom = rooms.FirstOrDefault(room => room.RoomId == id);

                if (deleteRoom != null)
                {
                    foreach (var item in _database.Reservations.Where(
                        reservation => reservation.RoomId == id))
                    {
                        _database.Entry(item).State = EntityState.Deleted;
                    }

                    _database.Entry(deleteRoom).State = EntityState.Deleted;
                    _database.SaveChanges();

                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Insert(Rooms room)
        {
            if (room != null)
            {
                _database.Entry(room).State = EntityState.Added;
                _database.SaveChanges();

                return true;
            }
            return false;
        }


    }
}