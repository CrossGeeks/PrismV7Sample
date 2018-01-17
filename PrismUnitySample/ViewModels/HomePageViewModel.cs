using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Common;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using PrismUnitySample.Services;

namespace PrismUnitySample.ViewModels
{
    public class HomePageViewModel : BindableBase,INavigatedAware
    {
		private string _userName;
		public string UserName
		{
			get { return _userName; }
			set { SetProperty(ref _userName, value); }
		}

        INavigationService _navigationService;
        IBatteryService _batteryService;
        IPageDialogService _pageDialogService;

        public ICommand GetBatteryStatusCommand { get; set; }

        public bool AllFieldsAreValid { get; set; } = true;


        IModuleManager _moduleManager;
        public HomePageViewModel(IModuleManager moduleManager, INavigationService navigationService, IBatteryService batteryService, IPageDialogService pageDialogService)
        {
            _moduleManager = moduleManager;
            _navigationService = navigationService;
            _batteryService = batteryService;
            _pageDialogService = pageDialogService;

			GetBatteryStatusCommand = new DelegateCommand(GetBatteryStatus).ObservesCanExecute(() => AllFieldsAreValid);
        }

        async void GetBatteryStatus(){

			var batteryStatus = _batteryService.GetBatteryStatus();
            await _pageDialogService.DisplayAlertAsync("Battery Status", batteryStatus, "Ok");

        }

        void INavigatedAware.OnNavigatedFrom(NavigationParameters parameters)
        {
       

        }

        void INavigatedAware.OnNavigatedTo(NavigationParameters parameters)
        {
            if(parameters.ContainsKey("UserName")){
                UserName = parameters.GetValue<string>("UserName");
            }
        }
    }
}
