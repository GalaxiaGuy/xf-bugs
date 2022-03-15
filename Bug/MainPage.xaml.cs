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
            BindingContext = new Item();
        }

        public void Button_Clicked(object sender, EventArgs eventArgs)
        {
            BindingContext = new Item();
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
