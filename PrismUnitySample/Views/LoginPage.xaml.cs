using System;
using System.Collections.Generic;
using Prism.Events;
using PrismUnitySample.Events;
using Xamarin.Forms;

namespace PrismUnitySample.Views
{
    public partial class LoginPage : ContentPage
    {
        IEventAggregator _eventAggregator;
        public LoginPage(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            _eventAggregator = eventAggregator;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _eventAggregator.GetEvent<UpdateNavBarEvent>().Publish(true);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _eventAggregator.GetEvent<UpdateNavBarEvent>().Publish(false);
        }
    }
}
