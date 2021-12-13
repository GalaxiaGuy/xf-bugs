using System;
using System.Linq;
using Xamarin.CommunityToolkit.Effects;
using Xamarin.Forms;

namespace Bug
{
    public class TestBehavior : Behavior
    {
        protected override void OnAttachedTo(BindableObject bindable)
        {
            if (bindable is Element element)
            {
                var effect = new LifecycleEffect();
                effect.Unloaded += Effect_Unloaded;
                element.Effects.Add(effect);
            }
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            if (bindable is Element element)
            {
                if (element.Effects.FirstOrDefault(x => x is LifecycleEffect) is LifecycleEffect effect)
                {
                    effect.Unloaded -= Effect_Unloaded;
                }
            }
            base.OnDetachingFrom(bindable);
        }

        private void Effect_Unloaded(object sender, EventArgs e)
        {
            if (sender is VisualElement element)
            {
                element.Behaviors.Clear();
            }
        }
    }
}
