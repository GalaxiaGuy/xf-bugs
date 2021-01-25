using Bug;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(SimpleEffect), SimpleEffect.EffectId)]

namespace Bug.iOS
{
    public class SimpleEffect : PlatformEffect
    {
        public SimpleEffect()
        {
            ObjectCounter.Instance.TrackObject("SimpleEffect - Platform", this);
        }

        protected override void OnAttached()
        {
        }

        protected override void OnDetached()
        {
        }
    }
}