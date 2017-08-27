using QRProject.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRProject.Interfaces
{
    public interface IReservationsViewModelRepository
    {
        ReservationsViewModel GetReservationsOfUser(int userId);
    }
}
