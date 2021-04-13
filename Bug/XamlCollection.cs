using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Bug
{
    public class XamlCollection<T> : ObservableCollection<T>
        where T : BindableObject
    {
        public Element Owner { get; }

        public XamlCollection(Element bindable)
        {
            ObjectTracker.Instance.Track("XamlCollection", this);
            Owner = bindable;
            Owner.BindingContextChanged += BindableBindingContextChanged;
        }

        private void BindableBindingContextChanged(object sender, EventArgs e)
        {
            foreach (var item in this)
            {
                item.BindingContext = Owner?.BindingContext;
            }
        }

        private void UpdateItem(T item)
        {
            BindableObject.SetInheritedBindingContext(item, Owner?.BindingContext);
            NameScope.SetNameScope(item, NameScope.GetNameScope(Owner));
            if (item is Element element && Owner is Element parent)
            {
                element.Parent = parent;
            }
        }

        private void ClearItem(T item)
        {
            BindableObject.SetInheritedBindingContext(item, null);
            NameScope.SetNameScope(item, null);
            if (item is Element element && element.Parent == Owner)
            {
                element.Parent = null;
            }
        }

        protected override void InsertItem(int index, T item)
        {
            UpdateItem(item);
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, T item)
        {
            UpdateItem(item);
            base.SetItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            var item = this[index];
            ClearItem(item);
            base.RemoveItem(index);
        }

        protected override void ClearItems()
        {
            foreach (var item in this)
            {
                ClearItem(item);
            }
            base.ClearItems();
        }
    }
}
