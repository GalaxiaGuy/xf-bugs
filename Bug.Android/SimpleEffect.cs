using Bug;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(SimpleEffect), SimpleEffect.EffectId)]

namespace Bug.Droid
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
