using QRProject.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRProject.Interfaces
{
    public interface IReservationDetailsService
    {
        IEnumerable<ReservationDetails> GetReservationByUser(int id);
    }
}
