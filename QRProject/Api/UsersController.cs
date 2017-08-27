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
    public class UsersController : ApiController
    {
        private IUsersRepository _repository;

        public UsersController(IUsersRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return _repository.SelectAll();
        }

        public IHttpActionResult DeleteOneUser(int id)
        {
            _repository.Delete(id);

            return Ok();
        }

    }
}
