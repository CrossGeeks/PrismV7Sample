using System;
using Prism.Commands;
using Prism.Navigation;

namespace PrismUnitySample.ViewModels
{
    public class CustomMasterDetailPageViewModel
    {
        INavigationService _navigationService;
        public DelegateCommand<string> OnNavigateCommand { get; set; }
        public CustomMasterDetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            OnNavigateCommand = new DelegateCommand<string>(NavigateAync);
        }

        async void NavigateAync(string page){
            await _navigationService.NavigateAsync(new Uri(page, UriKind.Relative));
        }
    }
}
