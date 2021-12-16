using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Bug
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DemoCollectionView.ItemsSource = null;
        }
    }

    public class MainViewModel
    {
        public List<string> Items { get; } = new List<string>
        {
            "a", "b", "c"
        };
    }
}
