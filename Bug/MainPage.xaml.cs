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
            BindingContext = new MainViewModel
            {
                Items = new List<Item>
                {
                    new Item
                    {
                        Text = "A", X = 0, Y = 0
                    },
                    new Item
                    {
                        Text = "B", X = 1, Y = 0
                    },
                    new Item
                    {
                        Text = "C", X = 2, Y = 2
                    }
                }
            };
        }
    }

    public class MainViewModel
    {
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public string Text { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
