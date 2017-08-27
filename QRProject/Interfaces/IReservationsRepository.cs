using QRProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRProject.Interfaces
{
    public interface IReservationsRepository
    {
        IEnumerable<Reservations> SelectAll();
        bool Delete(int id);
        bool Insert(Reservations reservation);
        bool Insert(int roomNr, int userId, System.DateTime day, System.TimeSpan startHour, System.TimeSpan endHour);
    }
}
