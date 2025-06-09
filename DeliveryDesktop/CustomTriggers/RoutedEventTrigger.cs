using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeliveryDesktop.CustomTriggers
{
    public class RoutedEventTrigger : EventTriggerBase<DependencyObject>
    {
        private RoutedEvent? _routedEvent;


        public RoutedEvent? RoutedEvent
        {
            get { return _routedEvent; }
            set { _routedEvent = value; }
        }


        protected override void OnAttached()
        {
            Behavior? behavior = AssociatedObject as Behavior;
            FrameworkElement? associatedElement = AssociatedObject as FrameworkElement;

            if (behavior != null)
            {
                associatedElement = ((IAttachedObject)behavior).AssociatedObject as FrameworkElement;
            }

            if (associatedElement == null)
            {
                throw new ArgumentException("Routed Event trigger can only be associated to framework elements");
            }

            if (RoutedEvent != null)
            {
                associatedElement.AddHandler(RoutedEvent, new RoutedEventHandler(this.OnRoutedEvent));
            }
        }


        void OnRoutedEvent(object sender, RoutedEventArgs args)
        {
            base.OnEvent(args);
        }


        protected override string? GetEventName()
        {
            return RoutedEvent?.Name;
        }
    }
}
