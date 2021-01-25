
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace Bug
{
    public partial class CollectionViewGridPage : ContentPage
    {
        public CollectionViewGridPage()
        {
            InitializeComponent();
            BindingContext = new CollectionViewGridViewModel();
        }
    }

    public class CollectionViewGridViewModel
    {
        public ObservableRangeCollection<LoadableItem> Items { get; set; }

        public CollectionViewGridViewModel()
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
            };
            Load();
        }

        public async void Load()
        {
            await Task.Delay(100);
            var newItems = new List<LoadableItem>();
            for (int i=0; i< 10; i++)
            {
                newItems.Add(new LoadableItem { IsLoaded = true });
            }
            Items.AddRange(newItems);
            var toRemove = Items.Where(x => !x.IsLoaded).ToList();
            Items.RemoveRange(toRemove);
        }
    }

    public class LoadableItem : ILoadable
    {
        public bool IsLoaded { get; set; }
    }
}
