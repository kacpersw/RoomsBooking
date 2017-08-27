using QRProject.Interfaces;
using QRProject.Models;
using QRProject.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRProject.Implementations
{
    public class RoomsReservationsRepository : IRoomsReservationsRepository
    {
        private readonly ReservationDatabaseEntities _database;

        public RoomsReservationsRepository(ReservationDatabaseEntities database)
        {
            _database = database;
        }

        public IEnumerable<Reservations> GetUserReservations(string email)
        {
            try
            {
                var id = _database.Users.FirstOrDefault(user => user.Email == email);
                return _database.Reservations.Where(user => user.UserId == id.UserId).ToArray();
            }
            catch
            {
                return null;
            }
            
        }

        
    }
}