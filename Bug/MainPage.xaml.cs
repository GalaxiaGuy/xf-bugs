using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bug
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new MainPageViewModel();
            InitializeComponent();
        }
    }

    public class MainPageViewModel
    {
        public List<string> Urls { get; }

        public MainPageViewModel()
        {
            var rand = new Random();
            Urls = new List<string>
            {
                $"https://www.fujifilm.com/products/digital_cameras/x/fujifilm_x_t1/sample_images/img/index/ff_x_t1_001.JPG?r={rand.Next()}",
                $"https://www.fujifilm.com/products/digital_cameras/x/fujifilm_x_t1/sample_images/img/index/ff_x_t1_002.JPG?r={rand.Next()}",
                $"https://www.fujifilm.com/products/digital_cameras/x/fujifilm_x_t1/sample_images/img/index/ff_x_t1_003.JPG?r={rand.Next()}",
                $"https://www.fujifilm.com/products/digital_cameras/x/fujifilm_x_t1/sample_images/img/index/ff_x_t1_001.JPG?r={rand.Next()}",
                $"https://www.fujifilm.com/products/digital_cameras/x/fujifilm_x_t1/sample_images/img/index/ff_x_t1_002.JPG?r={rand.Next()}",
                $"https://www.fujifilm.com/products/digital_cameras/x/fujifilm_x_t1/sample_images/img/index/ff_x_t1_003.JPG?r={rand.Next()}",
                $"https://www.fujifilm.com/products/digital_cameras/x/fujifilm_x_t1/sample_images/img/index/ff_x_t1_001.JPG?r={rand.Next()}",
                $"https://www.fujifilm.com/products/digital_cameras/x/fujifilm_x_t1/sample_images/img/index/ff_x_t1_002.JPG?r={rand.Next()}",
                $"https://www.fujifilm.com/products/digital_cameras/x/fujifilm_x_t1/sample_images/img/index/ff_x_t1_003.JPG?r={rand.Next()}",
                $"https://www.fujifilm.com/products/digital_cameras/x/fujifilm_x_t1/sample_images/img/index/ff_x_t1_001.JPG?r={rand.Next()}",
                $"https://www.fujifilm.com/products/digital_cameras/x/fujifilm_x_t1/sample_images/img/index/ff_x_t1_002.JPG?r={rand.Next()}",
                $"https://www.fujifilm.com/products/digital_cameras/x/fujifilm_x_t1/sample_images/img/index/ff_x_t1_003.JPG?r={rand.Next()}",
            };
        }
    }
}
