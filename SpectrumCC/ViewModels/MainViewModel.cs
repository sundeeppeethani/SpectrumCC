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

        public MainViewModel(IMvxNavigationService navigationService, ISQLiteDb sqliteDb)
        {
            _navigationService = navigationService;
            _sqliteDb = sqliteDb;
        }
        
        
        public override Task Initialize()
        {
            //TODO: Add starting logic here
		    
            return base.Initialize();
        }
        
        public IMvxCommand LoginCommand => new MvxCommand(Login);
        private void Login()
        {
            using (var connection = _sqliteDb.GetConnection())
            {
                var info = connection.GetTableInfo("User");
                if (info.Any())
                {
                    var isUserExists = connection.Table<User>().Any(x => x.UserName == UserName && x.Password == Password);
                    if (isUserExists)
                    {
                        
                    }
                    else
                    {

                    }
                }

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