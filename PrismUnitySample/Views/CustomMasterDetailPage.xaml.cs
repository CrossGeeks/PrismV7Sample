using System;
using Prism.Navigation;
using Xamarin.Forms;

namespace PrismUnitySample.Views
{
    public partial class CustomMasterDetailPage : MasterDetailPage, IMasterDetailPageOptions
    {
        public CustomMasterDetailPage()
        {
            InitializeComponent();
        }

		public bool IsPresentedAfterNavigation
		{
			get { return false; }
		}
	}
}
