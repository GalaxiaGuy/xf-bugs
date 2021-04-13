using Xamarin.Forms;

namespace Bug
{
    public class AccessibilityRoutingEffect : RoutingEffect
    {
        public AccessibilityRoutingEffect() : base("Bug.Accessibility")
        {
            ObjectTracker.Instance.Track("AccessibilityRoutingEffect", this);
        }
    }
}