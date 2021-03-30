using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
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

    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Colors = new List<Color>
            {
                Color.Blue,
                Color.Red,
                Color.Green,
                Color.Yellow,
                Color.Purple,
                Color.Magenta,
                Color.Gray,
                Color.Orange,
            };
        }

        public Color CurrentColor { get; private set; }

        public ICommand TapCommand => new AsyncCommand<Color>(async x =>
        {
            CurrentColor = x;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentColor)));
            await Task.Delay(1000);
            var options = new BrowserLaunchOptions { LaunchMode = BrowserLaunchMode.SystemPreferred, PreferredToolbarColor = CurrentColor };
            await Browser.OpenAsync("https://www.github.com/xamarin/xamarin.forms", options);
        });

        public List<Color> Colors { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
