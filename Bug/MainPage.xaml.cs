using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Bug
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            ObjectTracker.Instance.Track("MainPage", this);
            InitializeComponent();
            BindingContext = new MainViewModel
            {
                Items = new List<Item>
                {
                    new Item { Title = "Hello" },
                    new Item { Title = "Goodbye" },
                },
                LengthenTitleCommand = new Command(LengthenTitle),
                ShortenTitleCommand = new Command(ShortenTitle)
            };
        }

        private void LengthenTitle(object parameter)
        {
            if (parameter is Item item)
            {
                item.Title += item.Title;
                item.RaisePropertyChanged(nameof(Item.Title));
            }
        }

        private void ShortenTitle(object parameter)
        {
            if (parameter is Item item)
            {
                item.Title = item.Title.Substring(0, item.Title.Length / 2);
                item.RaisePropertyChanged(nameof(Item.Title));
            }
        }

        private async void Push_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private void Clean_Clicked(object sender, EventArgs e)
        {
            ((MainViewModel)BindingContext).Tracker.Clean();
        }
    }

    public class MainViewModel
    {
        public List<Item> Items { get; set; }
        public ICommand LengthenTitleCommand { get; set; }
        public ICommand ShortenTitleCommand { get; set; }
        public ObjectTracker Tracker { get; } = ObjectTracker.Instance;

        public MainViewModel()
        {
            ObjectTracker.Instance.Track("MainViewModel", this);
        }
    }

    public class Item : INotifyPropertyChanged
    {
        public string Title { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
