using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace SpectrumCC.ViewModels
{
    public class AccountSuccessfullyCreatedViewModel: MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public AccountSuccessfullyCreatedViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public IMvxCommand LoginNowCommand => new MvxCommand(LoginNow);
        private void LoginNow()
        {
            _navigationService.Navigate<MainViewModel>();
        }
    }
}
