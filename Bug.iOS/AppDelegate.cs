using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace Bug.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        private UIWindow _window;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            //LoadApplication(new App());

            _window = new UIWindow(UIScreen.MainScreen.Bounds);
            var viewController = new TestViewController();
            viewController.SetupMainPage();
            _window.RootViewController = viewController;
            _window.MakeKeyAndVisible();

            return true;
        }

        public class TestViewController : UIViewController
        {
            private UIViewController _mainPageViewController;

            public void SetupMainPage()
            {
                global::Xamarin.Forms.Forms.Init();

                var mainPage = new MainPage();
                _mainPageViewController = mainPage.CreateViewController();

                _mainPageViewController.View.Frame = View.Frame;

                AddChild(_mainPageViewController);
            }

            private void AddChild(UIViewController childViewcontroller)
            {
                childViewcontroller.WillMoveToParentViewController(this);
                AddChildViewController(childViewcontroller);
                View.AddSubview(childViewcontroller.View);
                childViewcontroller.DidMoveToParentViewController(this);
            }

            private void RemoveChild(UIViewController childViewcontroller)
            {
                childViewcontroller.WillMoveToParentViewController(null);
                childViewcontroller.View.RemoveFromSuperview();
                childViewcontroller.RemoveFromParentViewController();
                childViewcontroller.DidMoveToParentViewController(null);
            }

            public override void ViewWillTransitionToSize(CGSize toSize, IUIViewControllerTransitionCoordinator coordinator)
            {
                coordinator.AnimateAlongsideTransition(_ =>
                {
                    RemoveChild(_mainPageViewController);
                }, _ =>
                {
                    AddChild(_mainPageViewController);
                });
                base.ViewWillTransitionToSize(toSize, coordinator);
            }
        }
    }
}
