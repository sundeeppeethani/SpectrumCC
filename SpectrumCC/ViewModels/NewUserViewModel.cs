using System;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace SpectrumCC.ViewModels
{
    public class NewUserViewModel: MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public NewUserViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }


        public override Task Initialize()
        {
            //TODO: Add starting logic here

            return base.Initialize();
        }

        public IMvxCommand CreateAccountCommand => new MvxCommand(CreateAccount);
        private void CreateAccount()
        {

        }

        private string _firstName = "";
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _lastName = "";
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        private string _userName = "";
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _password = "";
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private string _phoneNumber = "";
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
        }

        private string _serviceStartDate = "";
        public string ServiceStartDate
        {
            get { return _serviceStartDate; }
            set { SetProperty(ref _serviceStartDate, value); }
        }
    }
}
