using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using SpectrumCC.Interfaces;
using SpectrumCC.Users;

namespace SpectrumCC.ViewModels
{
    public class MainViewModel : MvxViewModel
    {

        private readonly IMvxNavigationService _navigationService;
        private readonly ISQLiteDb _sqliteDb;
        private readonly IDialogService _dialogService;

        public MainViewModel(IMvxNavigationService navigationService, ISQLiteDb sqliteDb, IDialogService dialogService)
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
        
        public IMvxCommand LoginCommand => new MvxCommand(Login);
        private void Login()
        {
            if (!string.IsNullOrEmpty(UserName))
            {
                using (var connection = _sqliteDb.GetConnection())
                {
                    var info = connection.GetTableInfo("User");
                    if (info.Any())
                    {
                        var user = connection.Table<User>().
                                            Where(x => x.UserName.ToLower() == UserName.ToLower())
                                            .FirstOrDefault();
                        if (user == null)
                        {
                            _dialogService.ShowDialog("Error", "Account doesn’t exist", "OK");
                        }
                        else if (user.Password != Password)
                        {
                            _dialogService.ShowDialog("Error", "Password is incorrect", "OK");
                        }
                        else
                        {
                            _dialogService.ShowDialog("Success!", "User logged in", "OK");
                        }
                    }
                    else
                    {
                        _dialogService.ShowDialog("Error", "No users exist", "OK");
                    }
                }
            }
            else
            {
                _dialogService.ShowDialog("Warning", "User Name is empty", "OK");
            }
            
        }

        public IMvxCommand NewUserCommand => new MvxCommand(NewUser);
        private void NewUser()
        {
             _navigationService.Navigate<NewUserViewModel>();
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
    }
}