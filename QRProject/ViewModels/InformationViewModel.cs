using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRProject.ViewModels
{
    public class InformationViewModel
    {
        public string UserFirstName { get; set; }
        public string Message { get; set; }

        public InformationViewModel(string name, string message)
        {
            UserFirstName = name;
            Message = message;
        }
    }
}