using System;
using Xamarin.Forms;

namespace Bug
{
    public class SimpleEffect : RoutingEffect
    {
        public const string EffectId = "Simple";

        public SimpleEffect() : base(EffectId)
        {
            ObjectCounter.Instance.TrackObject("SimpleEffect - Shared", this);
        }
    }

    public class LoadingDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate LoadingTemplate { get; set; }
        public DataTemplate DefaultTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return item switch
            {
                ILoadable { IsLoaded: true } => DefaultTemplate,
                _ => LoadingTemplate,
            };
        }
    }

    public interface ILoadable
    {
        public bool IsLoaded { get; set; }
    }
}
