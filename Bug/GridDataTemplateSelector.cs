using System;
using Xamarin.Forms;

namespace TestBinadleLayout
{
    public class GridDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate CountryFlagTemplate { get; set; }
        public DataTemplate UserNameTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var data = (GridData)item;
            if (!string.IsNullOrEmpty(data.Image))
            {
                return CountryFlagTemplate;
            }
            return UserNameTemplate;
        }
    }

    public class GridData
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
    }
}

