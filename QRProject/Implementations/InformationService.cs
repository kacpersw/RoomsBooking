using QRProject.Interfaces;
using QRProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QRProject.Implementations
{
    public class InformationService : IInformationService
    {

        private IUsersRepository _repository;

        public InformationService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public InformationViewModel SetInformationViewModel(string id, string message)
        {

            var name = _repository.GetName(id);

            if (name == null)
                return null;

            return new InformationViewModel(name, message);
        }
    }
}