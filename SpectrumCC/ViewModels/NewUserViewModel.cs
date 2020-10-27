using System;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using SpectrumCC.Helpers;
using SpectrumCC.Interfaces;
using SpectrumCC.Users;

namespace SpectrumCC.ViewModels
{
    public class NewUserViewModel: MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ISQLiteDb _sqliteDb;
        private readonly IDialogService _dialogService;

        public NewUserViewModel(IMvxNavigationService navigationService, ISQLiteDb sqliteDb, IDialogService dialogService)
        {
            _navigationService = navigationService;
            _sqliteDb = sqliteDb;
            _dialogService = dialogService;
        }

        public override Task Initialize()
        {
            //TODO: Add starting logic here

            return base.Initialize();
        }

        public IMvxCommand CreateAccountCommand => new MvxCommand(CreateAccount);
        private void CreateAccount()
        {
            if (RegexHelper.HasSpecialCharactersInString(FirstName))
            {
                _dialogService.ShowDialog("Error", "First Name must not have these special characters:!@#$%^&", "OK");
            }
            else if(RegexHelper.HasSpecialCharactersInString(LastName))
            {
                _dialogService.ShowDialog("Error", "Last Name must not have these special characters:!@#$%^&", "OK");
            }
            else if (!RegexHelper.IsBetweenCharacterLength(Password, 8, 15))
            {
                _dialogService.ShowDialog("Error", "Password must have from 8 to 15 characters", "OK");
            }
            else if (!RegexHelper.IsMixtureOfLetterAndDigits(Password))
            {
                _dialogService.ShowDialog("Error", "Password must have at least one lowercase letter, one uppercase letter", "OK");
            }
            else if (RegexHelper.HasContainsAnySequence(Password))
            {
                _dialogService.ShowDialog("Error", "Password must not have repetitive any sequence of characters ", "OK");
            }
            else
            {
                using (var connection = _sqliteDb.GetConnection())
                {
                    connection.CreateTable<User>();
                    User user = new User
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        UserName = UserName,
                        Password = Password,
                        PhoneNumber = PhoneNumber,
                        ServiceStartDate = ServiceStartDate,
                    };
                    connection.Insert(user);
                }

                _navigationService.Navigate<AccountSuccessfullyCreatedViewModel>();
            }
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
