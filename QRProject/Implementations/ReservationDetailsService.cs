using QRProject.Details;
using QRProject.Interfaces;
using QRProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRProject.Implementations
{
    public class ReservationDetailsService : IReservationDetailsService
    {

        private ReservationDatabaseEntities _database;

        public ReservationDetailsService(ReservationDatabaseEntities database)
        {
            _database = database;
        }

        public IEnumerable<ReservationDetails> GetReservationByUser(int id)
        {
            try
            {
                return _database.Reservations.Where(reservation => reservation.UserId == id)
                               .Select(vm => new ReservationDetails()
                               {

                                   roomNr = vm.Rooms.RoomNr,
                                   reservationId = vm.ReservationId,
                                   day = (DateTime)vm.Day,
                                   startHour = (TimeSpan)vm.StartHour,
                                   endHour = (TimeSpan)vm.EndHour

                               }).ToArray();
            }
            catch
            {
                return null;
            }
           
        }
    }
}