using System;
using Foundation;
using UIKit;

namespace Bug.iOS
{
    public class MyViewController : UIViewController
    {
        public MyViewController() : base()
        {
        }

        public UIView NonExportedView { get; set; }

        [Export("exportedView")]
        public UIView ExportedView { get; set; }

        public void CreateView()
        {
            _ = View;
        }

        public bool CheckIfViewEqualsNull()
        {
            return View == null;
        }

        public bool CheckIfViewIsNull()
        {
            return View is null;
        }

        public bool CheckIfNonExportedViewEqualsNull()
        {
            return NonExportedView == null;
        }

        public bool CheckIfNonExportedViewIsNull()
        {
            return NonExportedView is null;
        }

        public bool CheckIfExportedViewEqualsNull()
        {
            return ExportedView == null;
        }

        public bool CheckIfExportedViewIsNull()
        {
            return ExportedView is null;
        }

        public bool CheckIfViewIsLoaded()
        {
            return this.IsViewLoaded;
        }
    }
}
