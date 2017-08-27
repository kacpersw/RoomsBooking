using QRProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using QRProject.Interfaces;
using QRProject.Implementations;

namespace QRProject.Controllers
{
    public class ReservationsController : ApiController
    {

        private readonly IReservationsRepository _repository;
        private readonly IReservationDetailsService _details;

        public ReservationsController(IReservationsRepository repository, 
            IReservationDetailsService details)
        { 
            _repository = repository;
            _details = details; 
        }

        public IHttpActionResult GetReservationsByUser(int id)
        {
            var reservations = _details.GetReservationByUser(id);

            if(reservations != null)
            {
                return Ok(reservations);
            }

            return NotFound();
        }

        public IEnumerable<Reservations> GetAllReservations()
        {
            return _repository.SelectAll();
        }

        public IHttpActionResult DeleteOneReservation(int id)
        {
            _repository.Delete(id);

            return Ok();
        }

        public IHttpActionResult PostOneReservation(Reservations reservation)
        {
            _repository.Insert(reservation);

            return Ok();
        }

    }
}
