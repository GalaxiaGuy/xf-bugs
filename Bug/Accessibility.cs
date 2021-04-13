using System.Collections.Specialized;
using System.Linq;
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
            var collection = new XamlCollection<CustomAction>((Element)bindable);
            collection.CollectionChanged += Collection_CollectionChanged;
            return collection;
        }

        private static void Collection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender is XamlCollection<CustomAction> customActions)
            {
                if (customActions.Any())
                {
                    var owner = customActions.Owner;
                    if (!owner.Effects.Any(x => x is AccessibilityRoutingEffect))
                    {
                        owner.Effects.Add(new AccessibilityRoutingEffect());
                    }
                }
            }
        }
    }
}
