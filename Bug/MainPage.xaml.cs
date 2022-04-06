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

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            MainCollectionView.ItemSizingStrategy = ItemSizingStrategy.MeasureFirstItem;
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
        public List<string> Images { get; }

        public Item()
        {
            Images = Enumerable.Range(0, 3).Select(x => "https://picsum.photos/id/5/200").ToList();
        }
    }
}
