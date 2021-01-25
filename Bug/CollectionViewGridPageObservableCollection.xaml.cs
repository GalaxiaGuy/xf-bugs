
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace Bug
{
    public partial class CollectionViewGridPageObservableCollection : ContentPage
    {
        public CollectionViewGridPageObservableCollection()
        {
            InitializeComponent();
            BindingContext = new CollectionViewGridViewModelObservableCollection();
        }
    }

    public class CollectionViewGridViewModelObservableCollection
    {
        public ObservableCollection<LoadableItem> Items { get; set; }

        public CollectionViewGridViewModelObservableCollection()
        {
            Items = new ObservableRangeCollection<LoadableItem>
            {
                new LoadableItem(),
                new LoadableItem(),
                new LoadableItem(),
                new LoadableItem(),
                new LoadableItem(),
                new LoadableItem(),
                new LoadableItem(),
                new LoadableItem(),
                new LoadableItem(),
                new LoadableItem(),
                new LoadableItem(),
                new LoadableItem(),
                new LoadableItem(),
                new LoadableItem(),
                new LoadableItem(),
                new LoadableItem(),
                new LoadableItem(),
                new LoadableItem(),
                new LoadableItem(),
                new LoadableItem(),
                new LoadableItem(),
                new LoadableItem(),
                new LoadableItem(),
                new LoadableItem(),
            };
            Load();
        }

        public async void Load()
        {
            await Task.Delay(100);
            var newItems = new List<LoadableItem>();
            for (int i = 0; i < 24; i++)
            {
                newItems.Add(new LoadableItem { IsLoaded = true, Name = i.ToString() });
            }
            Items.AddRange(newItems);
            var toRemove = Items.Where(x => !x.IsLoaded).ToList();
            Items.RemoveRange(toRemove);
        }
    }

    public static class Extensions
    {
        public static void AddRange<T>(this ObservableCollection<T> collection, IList<T> items)
        {
            foreach(var item in items)
            {
                collection.Add(item);
            }
        }

        public static void RemoveRange<T>(this ObservableCollection<T> collection, IList<T> items)
        {
            foreach (var item in items)
            {
                collection.Remove(item);
            }
        }
    }
}
