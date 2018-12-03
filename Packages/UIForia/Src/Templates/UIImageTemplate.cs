using System;
using System.Collections.Generic;
using System.Linq;
using UIForia.Compilers.AliasSource;
using UnityEngine;

namespace UIForia {

    public class UIImageTemplate : UITemplate {

        public static readonly MethodAliasSource s_UrlSource;

        public UIImageTemplate(List<UITemplate> childTemplates, List<AttributeDefinition> attributes = null)
            : base(childTemplates, attributes) { }

        static UIImageTemplate() {
           s_UrlSource = new MethodAliasSource("url", typeof(UIImageTemplate).GetMethod(nameof(TextureUrl)));
        }

        protected override Type elementType => typeof(UIImageElement);

        public override void Compile(ParsedTemplate template) {
            // template.contextDefinition.AddConstAliasSource(s_UrlSource);
            // template.compiler.AddExpressionResolver("$url");
            base.Compile(template);
            // template.contextDefinition.RemoveConstAliasSource(s_UrlSource);
        }

        public override UIElement CreateScoped(TemplateScope inputScope) {
            UIImageElement element = new UIImageElement();
            element.OriginTemplate = this;
            return element;
        }

        public static Texture2D TextureUrl(string url) {
            throw new NotImplementedException();
        }

    }

}