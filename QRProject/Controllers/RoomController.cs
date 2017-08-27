using MessagingToolkit.QRCode.Codec.Data;
using QRProject.Implementations;
using QRProject.Interfaces;
using QRProject.Models;
using QRProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRProject.Controllers
{
    public class RoomController : Controller
    {
        private QRCodeService decoder = null;
        private readonly IReservationsRepository _reservationsRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IReservationsViewModelRepository _vmReservationsRepository;
        private readonly IRoomsRepository _roomsRepository;
        private readonly IInformationService _infoService;

        public RoomController(IReservationsRepository reservationsRepository, 
            IUsersRepository usersRepository,IReservationsViewModelRepository vmReservationsRepository, 
            IRoomsRepository roomsRepository, IInformationService infoService)
        {
            decoder = new QRCodeService();
            _reservationsRepository = reservationsRepository;
            _usersRepository = usersRepository;
            _vmReservationsRepository = vmReservationsRepository;
            _roomsRepository = roomsRepository;
            _infoService = infoService;
        }


        public ActionResult QReader()
        {
            return View(_infoService.SetInformationViewModel(User.Identity.Name, string.Empty));
        }

        [HttpPost]
        [Authorize]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            return View("Register", _infoService.SetInformationViewModel(User.Identity.Name, 
                decoder.DecodeCode(file)));
        }

        [HttpPost]
        [Authorize]
        public ActionResult Manual(int roomNr, System.DateTime date, 
            System.TimeSpan startHour, System.TimeSpan endHour)
        {
            var message = string.Empty;
            var canIDoRegistration = _reservationsRepository.Insert(roomNr, 
                Int32.Parse(User.Identity.Name), date, startHour, endHour);

            if (canIDoRegistration)
            {
                message = "Pomyślnie zarezerwowałeś salę " + roomNr + ".";
            }
            else
            {
                message = "Nie udało się zarezerwować sali. W wybranym czasie jest ona zajęta.";
            }

            return View(_infoService.SetInformationViewModel(User.Identity.Name, message));
        }

    }
}