using AuthenticationModule.ViewModels;
using AuthenticationModule.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace AuthenticationModule
{
    public class AuthenticationModule : IModule
    {
        public void Initialize() { }

        public void OnInitialized() { }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
        }
    }
}