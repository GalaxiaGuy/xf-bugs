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
            HeaderColor = Color.Red;
            Items = new List<string> { "A", "B", "C", "D", "E", "F" };
            Indirect.Span = 3;
            Indirect.HeaderColor = Color.Red;
            Indirect.Items = new List<string> { "A", "B", "C", "D", "E", "F" };
        }

        public PageProperties Indirect { get; } = new PageProperties();

        private Color _headerColor = Color.Blue;
        public Color HeaderColor
        {
            get => _headerColor;
            set
            {
                _headerColor = value;
                OnPropertyChanged();
            }
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

        private List<string> _items = new List<string> { "X", "Y", "Z" };
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

    public class PageProperties : BindableObject
    {
        private Color _headerColor = Color.Blue;
        public Color HeaderColor
        {
            get => _headerColor;
            set
            {
                _headerColor = value;
                OnPropertyChanged();
            }
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

        private List<string> _items = new List<string> { "X", "Y", "Z" };
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
