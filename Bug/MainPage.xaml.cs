using System;
using Xamarin.Forms;

namespace Bug
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void CollectionViewGridPageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CollectionViewGridPage());
        }
    }
}
