
using Xamarin.Forms;

namespace Bug
{
    public partial class CollectionViewEffectPage : ContentPage
    {
        public CollectionViewEffectPage()
        {
            InitializeComponent();
            ObjectCounter.Instance.TrackObject("CollectionViewEffectPage", this);
            ObjectCounter.Instance.TrackObject("Object", new object());
        }
    }
}
