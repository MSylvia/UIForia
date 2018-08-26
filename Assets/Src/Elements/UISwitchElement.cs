namespace Src {

    public class UISwitchElement : UIElement {

        public UISwitchElement() {
            flags |= UIElementFlags.Enabled;
            flags |= UIElementFlags.ImplicitElement;
            flags &= ~(UIElementFlags.RequiresLayout | UIElementFlags.RequiresLayout);
        }

    }

}