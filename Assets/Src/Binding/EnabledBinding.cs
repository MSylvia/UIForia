namespace Src {

    public class EnabledBinding : Binding {

        private readonly Expression<bool> expression;

        public EnabledBinding(Expression<bool> expression) {
            this.expression = expression;
        }

        public override void Execute(UIElement element, UITemplateContext context) {
            bool isEnabled = (element.flags & UIElementFlags.Enabled) != 0;
            if (expression.EvaluateTyped(context)) {
                if (isEnabled) return;
                context.view.EnableElement(element);
            }
            else {
                if (!isEnabled) return;
                context.view.DisableElement(element);

            }
        }

        public override bool IsConstant() {
            return expression.IsConstant();
        }

    }

}