using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Bug
{
    public partial class ObjectTrackerView : ContentView
    {
        public ObjectTrackerView()
        {
            InitializeComponent();
        }

        private void Clean_Clicked(object sender, EventArgs e)
        {
            ObjectTracker.Instance.Clean();
        }
    }
}
