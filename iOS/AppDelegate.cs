using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using PrismUnitySample.iOS.Services;
using PrismUnitySample.Services;
using UIKit;

namespace PrismUnitySample.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        static BatteryService batteryService = new BatteryService();
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(app, options);
        }
        public class iOSInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IContainerRegistry containerRegistry)
            {
                containerRegistry.RegisterInstance<IBatteryService>(batteryService);
            }
        }
    }
}



