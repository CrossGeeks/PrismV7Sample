using System;
using Prism.Events;
using PrismUnitySample.Events;
using Xamarin.Forms;

namespace PrismUnitySample.Views
{
    public class CustomNavigationPage: NavigationPage
    {
        IEventAggregator _eventAggregator;
        public CustomNavigationPage(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _eventAggregator.GetEvent<UpdateNavBarEvent>().Subscribe(UpdateColor);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _eventAggregator.GetEvent<UpdateNavBarEvent>().Unsubscribe(UpdateColor);
        }

        void UpdateColor(bool isShowingTheLoging){
			if (isShowingTheLoging)
			{
				this.BarBackgroundColor = Color.Black;
			}
			else
			{
				this.BarBackgroundColor = Color.Red;
			}

        }
    }
}
