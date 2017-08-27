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
    public class ReservationsViewModelRepository : IReservationsViewModelRepository
    {
        private readonly ReservationDatabaseEntities _database;
        private ReservationsViewModel reservations;

        public ReservationsViewModelRepository(ReservationDatabaseEntities database)
        {
            _database = database;
            reservations = new ReservationsViewModel();
        }

        public ReservationsViewModel GetReservationsOfUser(int userId)
        {

            try
            {
                foreach (var item in _database.Reservations.Where(user => user.UserId == userId))
                {
                    reservations.reservations.Add(item as Reservations);
                }

                return reservations;
            }
            catch
            {
                return null;
            }
        }
    }
}