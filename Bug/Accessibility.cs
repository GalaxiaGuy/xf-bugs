using System.Collections.Specialized;
using Xamarin.Forms;

namespace Bug
{
    public class Accessibility
    {
        public static readonly BindableProperty CustomActionsProperty =
            BindableProperty.CreateAttached("CustomActions", typeof(XamlCollection<CustomAction>), typeof(Accessibility), null, defaultValueCreator: CreateCustomActionsCollection);

        public static XamlCollection<CustomAction> GetCustomActions(BindableObject bindable)
            => (XamlCollection<CustomAction>)bindable.GetValue(CustomActionsProperty);

        public static void SetCustomActions(BindableObject bindable, XamlCollection<CustomAction> value)
            => bindable.SetValue(CustomActionsProperty, value);

        private static object CreateCustomActionsCollection(BindableObject bindable)
        {
            var collection = new XamlCollection<CustomAction>(bindable);
            return collection;
        }
    }
}
