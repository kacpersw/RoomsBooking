using QRProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRProject.Interfaces
{
    public interface IUsersRepository
    {
        IEnumerable<Users> SelectAll();
        bool Delete(int id);
        string GetName(string id);
    }
}