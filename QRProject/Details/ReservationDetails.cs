using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRProject.Details
{
    public class ReservationDetails
    {
        public int roomNr;
        public int reservationId;
        public DateTime day;
        public TimeSpan startHour;
        public TimeSpan endHour;
    }
}