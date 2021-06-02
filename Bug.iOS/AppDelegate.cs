using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace Bug.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private MyViewController _viewController;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            Test();

            return base.FinishedLaunching(app, options);
        }

        private async void Test()
        {
            await ExecuteAsync("Create UIViewController", () => new UIViewController());
            await ExecuteAsync("Create UIView", () => new UIView());
            await ExecuteAsync("Create UIColor", () => new UIColor(1, 1));

            await ExecuteMyViewControllerAsync("Check if View is equal to null", x => x.CheckIfViewEqualsNull());
            await ExecuteMyViewControllerAsync("Check if View is null pattern", x => x.CheckIfViewIsNull());
            await ExecuteMyViewControllerAsync("Check if View is loaded", x => x.CheckIfViewIsLoaded());

            await ExecuteMyViewControllerAsync("Check if View is equal to null after creating View", x => x.CheckIfViewEqualsNull(), x => x.CreateView());
            await ExecuteMyViewControllerAsync("Check if View is null pattern after creating View", x => x.CheckIfViewIsNull(), x => x.CreateView());
            await ExecuteMyViewControllerAsync("Check if View is loaded after creating View", x => x.CheckIfViewIsLoaded(), x => x.CreateView());

            await ExecuteMyViewControllerAsync("Check if non-exported View is equal to null", x => x.CheckIfNonExportedViewEqualsNull());
            await ExecuteMyViewControllerAsync("Check if non-exported View is null pattern", x => x.CheckIfNonExportedViewIsNull());

            await ExecuteMyViewControllerAsync("Check if exported View is equal to null", x => x.CheckIfExportedViewEqualsNull());
            await ExecuteMyViewControllerAsync("Check if exported View is null pattern", x => x.CheckIfExportedViewIsNull());

            await ExecuteMyViewControllerAsync("Check if NavigationController is equal to null", x => x.CheckIfNavigationControllerEqualsNull());
            await ExecuteMyViewControllerAsync("Check if NavigationController is null pattern", x => x.CheckIfNavigationControllerIsNull());

            var view1 = new UIView();
            await ExecuteMyViewControllerAsync("Set non-exported View", x => x.SetNonExportedView(view1));

            var view2 = new UIView();
            await ExecuteMyViewControllerAsync("Set exported View", x => x.SetExportedView(view2));
        }

        private async Task ExecuteAsync(string name, Action action)
        {
            Console.WriteLine(name);

            await Task.Run(() =>
            {
                try
                {
                    action();
                    Console.WriteLine("OK");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception");
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine();
            });
        }

        private async Task ExecuteMyViewControllerAsync(string name, Action<MyViewController> action, Action<MyViewController> setup = null)
        {
            Console.WriteLine(name);
            _viewController = new MyViewController();
            setup?.Invoke(_viewController);

            await Task.Run(() =>
            {
                try
                {
                    action(_viewController);
                    Console.WriteLine("OK");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception");
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine();
            });
        }
    }
}
