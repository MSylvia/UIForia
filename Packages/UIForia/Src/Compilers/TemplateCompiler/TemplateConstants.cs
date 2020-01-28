namespace UIForia.Compilers {

    public class TemplateConstants {

        public const string InitSource = @"using System;
using System;
using System.Collections.Generic;
using UIForia.Compilers;
using UIForia.Elements;
using UIForia.Compilers.Style;
#pragma warning disable 0164
namespace UIForia.Generated {

    public partial class UIForiaGeneratedTemplates_::APPNAME:: : ITemplateLoader {
        
        public string[] StyleFilePaths => styleFilePaths;

        private string[] styleFilePaths = {
::STYLE_FILE_PATHS::
        };

        public Func<UIElement, TemplateScope, UIElement>[] LoadTemplates() {
::TEMPLATE_CODE::
        }

        public TemplateMetaData[] LoadTemplateMetaData(Dictionary<string, StyleSheet> sheetMap, UIStyleGroupContainer[] styleMap) {
::TEMPLATE_META_CODE::
        }

        public Action<UIElement, UIElement>[] LoadBindings() {
::BINDING_CODE::
        }

        public Func<UIElement, UIElement, TemplateScope, UIElement>[] LoadSlots() {
::SLOT_CODE::
        }

        public UIElement ConstructElement(int typeId) {
            switch(typeId) {
::ELEMENT_CONSTRUCTORS::
            }
            return null;
        }

    }

}";

        public const string TemplateSource = @"using System;
using UIForia.Compilers;
using UIForia.Elements;

namespace UIForia.Generated {

    public partial class UIForiaGeneratedTemplates_::APPNAME:: {
        // ::TEMPLATE_COMMENT::
        public Func<UIElement, TemplateScope, UIElement> Template_::GUID:: = ::CODE:: 
::BINDINGS::
::SLOTS::
    }

}
#pragma warning enable 0164

                ";

    }

}