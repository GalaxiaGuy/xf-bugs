using Xamarin.Forms;

namespace Bug
{
    public partial class EmptyPage : ContentPage
    {
        public EmptyPage()
        {
            InitializeComponent();
            ObjectCounter.Instance.TrackObject("EmptyPage", this);
            ObjectCounter.Instance.TrackObject("Object", new object());
        }
    }
}
