
using Xamarin.Forms;

namespace Bug
{
    public partial class EffectPage : ContentPage
    {
        public EffectPage()
        {
            InitializeComponent();
            ObjectCounter.Instance.TrackObject("EffectPage", this);
            ObjectCounter.Instance.TrackObject("Object", new object());
        }
    }
}
