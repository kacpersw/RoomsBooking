using QRProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRProject.ViewModels
{
    public class ReservationsViewModel
    {
        public ReservationsViewModel()
        {
            reservations = new List<Reservations>();
        }

        public List<Reservations> reservations;
    }
}