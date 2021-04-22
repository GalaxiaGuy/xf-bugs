using System;
using Xamarin.Forms;

namespace Bug
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel { FirstName = "John", LastName = "Doe" };
        }
    }

    public class MainViewModel : IMainViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NotOnTheInterface { get; set; }
    }

    public interface IMainViewModel
    {
        string FirstName { get; }
        string LastName { get; }
        string FullName => $"{FirstName} {LastName}";
    }
}
