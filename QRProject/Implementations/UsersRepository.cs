using QRProject.Interfaces;
using QRProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace QRProject.Implementations
{
    public class UsersRepository : IUsersRepository
    {

        private readonly ReservationDatabaseEntities _database;

        public UsersRepository(ReservationDatabaseEntities database)
        {
            _database = database;
        }

        public IEnumerable<Users> SelectAll()
        {
            return _database.Users.ToArray();
        }

        public bool Delete(int id)
        {

            var users = _database.Users.Include(relation => relation.Reservations);

            if (users == null)
                return false;

            var deleteUser = users.FirstOrDefault(user => user.UserId == id);

            if (deleteUser != null)
            {
                try
                {
                    foreach (var item in _database.Reservations.Where(
                        reservation => reservation.UserId == id))
                    {
                        _database.Entry(item).State = EntityState.Deleted;
                    }

                    _database.Entry(deleteUser).State = EntityState.Deleted;
                    _database.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }

        public string GetName(string id)
        {
            try
            {
                var userId = int.Parse(id);
                var user = _database.Users.FirstOrDefault(person => person.UserId == userId);

                return user.FirstName;
            }
            catch
            {
                return null;
            }

        }

    }
}