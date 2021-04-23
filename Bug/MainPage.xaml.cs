using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestBinadleLayout
{
    public partial class MainPage : ContentPage
    {
        public class CreditData
        {
            public string user_id { get; set; }
            public string user_name { get; set; }
            public string country_code { get; set; }

            public string country_flag
            {
                get
                {
                    return string.Format("https://www.jassimrahma.net/images/flags/{0}.png", country_code);
                }
            }
        }

        public MainPage()
        {
            InitializeComponent();

            PopulateCredits();
        }

        public async void PopulateCredits()
        {
            try
            {
                var client = new HttpClient();

                client.BaseAddress = new Uri("https://www.jassimrahma.net/populate_test_credits.php");

                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("language", "EN"),
                });

                var response = await client.PostAsync("https://www.jassimrahma.net/populate_test_credits.php", content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    List<CreditData> data = JsonSerializer.Deserialize<List<CreditData>>(result);

                    BindableLayout.SetItemsSource(GridCredits, CreateGridcollection(data));

                    ListViewCredits.ItemsSource = data;
                    ListViewCredits.IsVisible = true;

                    // viewModel.IsLoaded = true;
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Error", "Error");
                }
            }
            catch (HttpRequestException ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");

                return;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");

                return;
            }
        }

        private IEnumerable<GridData> CreateGridcollection(IEnumerable<CreditData> data)
        {
            var row = 0;
            foreach (var item in data)
            {
                yield return new GridData { Row = row, Column = 0, Image = item.country_flag };
                yield return new GridData { Row = row, Column = 1, Text = item.user_name };
                row++;
            }
        }
    }
}
