using System.Collections.Generic;
using Xamarin.Forms;

namespace Bug
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Span = 3;
            Items = new List<string> { "A", "B", "C", "D", "E", "F" };
        }

        private int _span = 1;
        public int Span
        {
            get => _span;
            set
            {
                _span = value;
                OnPropertyChanged();
            }
        }

        private List<string> _items;
        public List<string> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }
    }
}
