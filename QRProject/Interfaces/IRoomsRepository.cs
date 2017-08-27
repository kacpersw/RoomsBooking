using QRProject.Models;
using QRProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRProject.Interfaces
{
    public interface IRoomsRepository
    {
        IEnumerable<Rooms> SelectAll();
        bool Delete(int id);
        bool Insert(Rooms room);
    }
}
