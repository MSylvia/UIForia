namespace UIForia.Elements {

    public abstract class UIPrimitiveElement : UIElement {

        protected UIPrimitiveElement() {
            flags |= UIElementFlags.Primitive;
        }

    }

}