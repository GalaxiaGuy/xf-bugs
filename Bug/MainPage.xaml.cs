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
        public List<Item> Items { get; }

        public MainViewModel()
        {
            Items = Enumerable.Range(0, 30).Select(x => new Item()).ToList();
        }
    }

    public class Item
    {
        private static readonly Random s_rand = new Random();

        public List<Color> Colors { get; }

        public Item()
        {
            Colors = Enumerable.Range(0, 3).Select(x => new Color(s_rand.NextDouble(), s_rand.NextDouble(), s_rand.NextDouble())).ToList();
        }
    }
}
