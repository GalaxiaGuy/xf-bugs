using System;
using System.Collections.Generic;
using System.Linq;
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
    }

    public class MainViewModel
    {
        public List<string> Labels { get; } = Enumerable.Repeat(".", 100).ToList();
    }
}
