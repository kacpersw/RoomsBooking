using QRProject.Models;
using QRProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRProject.Interfaces
{
    public interface IRoomsReservationsRepository
    {
        IEnumerable<Reservations> GetUserReservations(string email);
    }
}
