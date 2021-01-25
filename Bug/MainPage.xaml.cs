using System;
using Xamarin.Forms;

namespace Bug
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = ObjectCounter.Instance;
        }

        private async void EmptyPageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmptyPage());
        }

        private async void EffectPageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EffectPage());
        }

        private async void CollectionViewEffectPageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CollectionViewEffectPage());
        }

        private async void CollectionViewGridPageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CollectionViewGridPage());
        }
    }
}
