using System;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using PrismUnitySample.ViewModels;
using PrismUnitySample.Views;
using Xamarin.Forms;

namespace PrismUnitySample
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();


            //Uncomment this list to Test Prism Tabbed Page 
             NavigationService.NavigateAsync(new System.Uri("/NavigationPage/CustomTabbedPage?selectedTab=Test2Page", System.UriKind.Absolute));

            //Uncomment this list to Test Prism Master DetailPage 
            //  NavigationService.NavigateAsync(new System.Uri("/CustomMasterDetailPage/NavigationPage/Test2Page", System.UriKind.Absolute));

            //Uncomment this list to Test Prism general concepts as Custom NavigationPage/Modules/DelegateCommands/Services 
            //NavigationService.NavigateAsync(new System.Uri("http://www.MyTestApp/CustomNavigationPage/LoginPage", System.UriKind.Absolute));
             

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<CustomTabbedPage>();
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<CustomMasterDetailPage, CustomMasterDetailPageViewModel>();

            containerRegistry.RegisterForNavigation<CustomNavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();

            containerRegistry.RegisterForNavigation<Test1Page, Test1PageViewModel>();
            containerRegistry.RegisterForNavigation<Test2Page>();

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            Type authenticationModuleType = typeof(AuthenticationModule.AuthenticationModule);
            moduleCatalog.AddModule(
             new ModuleInfo(authenticationModuleType)
             {
                 ModuleName = authenticationModuleType.Name,
                 InitializationMode = InitializationMode.OnDemand
             });
        }
    }
}