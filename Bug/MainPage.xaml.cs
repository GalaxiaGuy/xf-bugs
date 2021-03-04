using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bug
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new MainPageViewModel();
            InitializeComponent();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            GridLayout.Span = width > height ? 3 : 2;
        }
    }

    public class MainPageViewModel
    {
        public List<string> Labels { get; }

        public MainPageViewModel()
        {
            Labels = Enumerable.Repeat("X", 200).ToList();
        }
    }
}
