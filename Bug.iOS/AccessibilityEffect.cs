using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Bug")]
[assembly: ExportEffect(typeof(Bug.iOS.AccessibilityEffect), "Accessibility")]

namespace Bug.iOS
{
    public class AccessibilityEffect : PlatformEffect
    {
        private IEnumerable<CustomAction> _customActions;

        protected override void OnAttached()
        {
            SetCustomActions();
        }

        protected override void OnDetached()
        {
            ClearCustomActions();
        }

        private void SetCustomActions()
        {
            if (_customActions != null)
            {
                Unsubscribe(_customActions);
            }
            if (Accessibility.GetCustomActions(Element) is IEnumerable<CustomAction> customActions)
            {
                Subscribe(customActions);
                _customActions = customActions;
                UpdateCustomActions();
            }
        }

        private void UpdateCustomActions()
        {
            if ((Control ?? Container) is UIView nativeView)
            {
                var valid = _customActions
                    .Where(x => CanExecute(x));

                nativeView.AccessibilityCustomActions = _customActions.Select(x => new UIAccessibilityCustomAction(x.Text, AsHandler(x))).ToArray();
            }
        }

        private void Subscribe(IEnumerable<CustomAction> customActions)
        {
            if (customActions is INotifyCollectionChanged observableCollection)
            {
                observableCollection.CollectionChanged += ObservableCollection_CollectionChanged;
            }
            foreach (var action in customActions)
            {
                action.PropertyChanged += CustomAction_PropertyChanged;
            }
        }

        private void Unsubscribe(IEnumerable<CustomAction> customActions)
        {
            if (customActions is INotifyCollectionChanged observableCollection)
            {
                observableCollection.CollectionChanged -= ObservableCollection_CollectionChanged;
            }
            foreach (var action in customActions)
            {
                action.PropertyChanged -= CustomAction_PropertyChanged;
            }
        }

        private void ObservableCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateCustomActions();
        }

        private void CustomAction_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateCustomActions();
        }

        private void ClearCustomActions()
        {
            if (_customActions != null)
            {
                Unsubscribe(_customActions);
            }
            if ((Control ?? Container) is UIView nativeView)
            {
                nativeView.AccessibilityCustomActions = null;
            }
        }

        private bool CanExecute(CustomAction customAction)
        {
            return customAction?.Command?.CanExecute(customAction.CommandParameter) == true;
        }

        private Func<UIAccessibilityCustomAction, bool> AsHandler(CustomAction action)
        {
            return _ =>
            {
                action.Command.Execute(action.CommandParameter);
                return true;
            };
        }
    }
}