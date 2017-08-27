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
    public class RoomsController : ApiController
    {

        private readonly IRoomsRepository _repository;

        public RoomsController(IRoomsRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Rooms> GetAllRooms()
        {
            return _repository.SelectAll();
        }


        public IHttpActionResult DeleteOneRoom(int id)
        {
            _repository.Delete(id);

            return Ok();
        }

        public IHttpActionResult PostOneRoom(Rooms room)
        {
            _repository.Insert(room);

            return Ok();
        }

    }

}
