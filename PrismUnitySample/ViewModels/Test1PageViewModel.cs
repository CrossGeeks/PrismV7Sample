using System;
using System.Threading.Tasks;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismUnitySample.ViewModels
{
    public class Test1PageViewModel: BindableBase, IActiveAware
    {
        INavigationService _navigationService;

        public event EventHandler IsActiveChanged;

        public DelegateCommand OnLoginCommand { get; set; }
		private bool _isActive;
		public bool IsActive
		{
			get { return _isActive; }
			set { SetProperty(ref _isActive, value, RaiseIsActiveChanged); }
		}
        public Test1PageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            OnLoginCommand = new DelegateCommand(GoHome);
        }

		protected virtual void RaiseIsActiveChanged()
		{
			IsActiveChanged?.Invoke(this, EventArgs.Empty);
		}
		async void GoHome()
		{
            await _navigationService.NavigateAsync(new Uri($"HomePage", UriKind.Relative), null, false);
		}
    }
}
