using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using NUnit.Framework;
using Tests.Mocks;
using UIForia;
using UIForia.Attributes;
using UIForia.Compilers;
using UIForia.Compilers.Style;
using UIForia.Elements;
using UIForia.Rendering;
using UIForia.UIInput;
using UnityEngine;

namespace TemplateBinding {

    public class TemplateBindingTests {

        private bool usePreCompiledTemplates = true;
        private bool generateCode = true;

        public MockApplication Setup<T>(string appName = null) {
            if (appName == null) {
                StackTrace stackTrace = new StackTrace();
                appName = stackTrace.GetFrame(1).GetMethod().Name;
            }

            TemplateSettings settings = new TemplateSettings();
            settings.applicationName = appName;
            settings.assemblyName = GetType().Assembly.GetName().Name;
            settings.outputPath = Path.Combine(UnityEngine.Application.dataPath, "..", "Packages", "UIForia", "Tests", "UIForiaGenerated");
            settings.codeFileExtension = "generated.xml.cs";
            settings.preCompiledTemplatePath = "Assets/UIForia_Generated/" + appName;
            settings.templateResolutionBasePath = Path.Combine(UnityEngine.Application.dataPath, "..", "Packages", "UIForia", "Tests");

            if (generateCode) {
                TemplateCodeGenerator.Generate(typeof(T), settings);
            }

            CompiledTemplateData compiledTemplates = usePreCompiledTemplates
                ? TemplateLoader.LoadPrecompiledTemplates(settings)
                : TemplateLoader.LoadRuntimeTemplates(typeof(T), settings);

            return new MockApplication(compiledTemplates, null);
        }

        [Template("Data/TemplateBindings/TemplateBindingTest_BasicBinding.xml")]
        public class TemplateBindingTest_BasicBindingOuter : UIElement { }

        [Template("Data/TemplateBindings/TemplateBindingTest_BasicBinding.xml#inner")]
        public class TemplateBindingTest_BasicBindingInner : UIElement {

            public int intVal = 5;

        }

        [Test]
        public void SimpleBinding() {
            MockApplication app = Setup<TemplateBindingTest_BasicBindingOuter>();
            TemplateBindingTest_BasicBindingInner inner = (TemplateBindingTest_BasicBindingInner) app.RootElement[0];
            Assert.AreEqual(5, inner.intVal);
            app.Update();
            Assert.AreEqual(25, inner.intVal);
        }

        [Template("Data/TemplateBindings/TemplateBindingTest_CreatedBinding.xml")]
        public class TemplateBindingTest_CreatedBindingOuter : UIElement {

            public int value = 15;

            public int GetValue() {
                return value;
            }

        }

        [Template("Data/TemplateBindings/TemplateBindingTest_CreatedBinding.xml#inner")]
        public class TemplateBindingTest_CreatedBindingInner : UIElement {

            public int intVal;

        }

        [Test]
        public void CreatedBinding() {
            MockApplication app = Setup<TemplateBindingTest_CreatedBindingOuter>();

            TemplateBindingTest_CreatedBindingOuter outer = (TemplateBindingTest_CreatedBindingOuter) app.RootElement;
            TemplateBindingTest_CreatedBindingInner inner = (TemplateBindingTest_CreatedBindingInner) app.RootElement[0];

            int original = outer.value;

            Assert.AreEqual(original, inner.intVal);
            outer.value = 25;
            app.Update();
            Assert.AreEqual(original, inner.intVal);
            Assert.AreEqual(25, outer.GetValue());
        }


        [Template("Data/TemplateBindings/TemplateBindingTest_AttributeBinding.xml")]
        public class TemplateBindingTest_AttributeBinding : UIElement {

            public int intVal = 18;

        }

        [Test]
        public void AttributeBinding() {
            MockApplication app = Setup<TemplateBindingTest_AttributeBinding>();

            TemplateBindingTest_AttributeBinding outer = (TemplateBindingTest_AttributeBinding) app.RootElement;
            UIElement inner = app.RootElement[0];

            Assert.AreEqual("attr-value", inner.GetAttribute("someAttr"));
            Assert.AreEqual("", inner.GetAttribute("dynamicAttr"));

            app.Update();

            Assert.AreEqual("attr-value", inner.GetAttribute("someAttr"));
            Assert.AreEqual("dynamic18", inner.GetAttribute("dynamicAttr"));
        }

        [Template("Data/TemplateBindings/TemplateBindingTest_MouseBinding.xml")]
        public class TemplateBindingTest_MouseBindingBinding : UIElement {

            public string output_NoParams;
            public string output_EvtParam;
            public string output_MixedParams;
            public string output_NoEvtParam;

            public void HandleMouseClick_NoParams() {
                output_NoParams = "No Params Was Called";
            }

            public void HandleMouseClick_EvtParam(MouseInputEvent evt) {
                output_EvtParam = $"EvtParam was called {evt.MousePosition.x}, {evt.MousePosition.y}";
            }

            public void HandleMouseClick_MixedParams(MouseInputEvent evt, int param) {
                output_MixedParams = $"MixedParams was called {evt.MousePosition.x}, {evt.MousePosition.y} param = {param}";
            }

            public void HandleMouseClick_NoEvtParam(string str, int param) {
                output_NoEvtParam = $"NoEvtParam was called str = {str} param = {param}";
            }

            public float output_value;

            public void SetValue(float value) {
                output_value = value;
            }

        }

        [Test]
        public void MouseHandlerBinding() {
            MockApplication app = Setup<TemplateBindingTest_MouseBindingBinding>();
            TemplateBindingTest_MouseBindingBinding e = (TemplateBindingTest_MouseBindingBinding) app.RootElement;

            app.Update();

            app.InputSystem.MouseDown(new Vector2(50, 50));

            app.Update();

            Assert.AreEqual("No Params Was Called", e.output_NoParams);

            app.Update();

            app.InputSystem.MouseDown(new Vector2(50, 150));

            app.Update();

            Assert.AreEqual("EvtParam was called 50, 150", e.output_EvtParam);

            app.InputSystem.MouseDown(new Vector2(50, 250));

            app.Update();

            Assert.AreEqual("MixedParams was called 50, 250 param = 250", e.output_MixedParams);

            app.InputSystem.MouseDown(new Vector2(50, 350));

            app.Update();

            Assert.AreEqual("NoEvtParam was called str = string goes here param = 250", e.output_NoEvtParam);
        }

        [Template("Data/TemplateBindings/TemplateBindingTest_KeyboardBinding.xml")]
        public class TemplateBindingTest_KeyboardBinding : UIElement {

            public string output_NoParams;
            public string output_EvtParam;
            public string output_MixedParams;
            public string output_NoEvtParam;

            public void HandleKeyDown_NoParams() {
                output_NoParams = "No Params Was Called";
            }

            public void HandleKeyDown_EvtParam(KeyboardInputEvent evt) {
                output_EvtParam = $"EvtParam was called {evt.character}";
            }

            public void HandleKeyDown_MixedParams(KeyboardInputEvent evt, int param) {
                output_MixedParams = $"MixedParams was called {evt.character} param = {param}";
            }

            public void HandleKeyDown_NoEvtParam(string str, int param) {
                output_NoEvtParam = $"NoEvtParam was called str = {str} param = {param}";
            }

            public float output_value;

            public void SetValue(float value) {
                output_value = value;
            }

        }

        [Test]
        public void KeyboardHandlerBinding() {
            MockApplication app = Setup<TemplateBindingTest_MouseBindingBinding>();
            TemplateBindingTest_MouseBindingBinding e = (TemplateBindingTest_MouseBindingBinding) app.RootElement;

            throw new NotImplementedException("Keyboard input needs a re-write");
            // app.Update();
            //
            // app.InputSystem.MouseDown(new Vector2(50, 50));
            //
            // app.Update();
            //
            // Assert.AreEqual("No Params Was Called", e.output_NoParams);
            //
            // app.Update();
            //
            // app.InputSystem.KeyDown('a');
            //
            // app.Update();
            //
            // Assert.AreEqual("EvtParam was called 50, 150", e.output_EvtParam);
            //
            // app.InputSystem.MouseDown(new Vector2(50, 250));
            //
            // app.Update();
            //
            // Assert.AreEqual("MixedParams was called 50, 250 param = 250", e.output_MixedParams);
            //
            // app.InputSystem.MouseDown(new Vector2(50, 350));
            //
            // app.Update();
            //
            // Assert.AreEqual("NoEvtParam was called str = string goes here param = 250", e.output_NoEvtParam);
        }


        [Template("Data/TemplateBindings/TemplateBindingTest_ConditionalBinding.xml")]
        public class TemplateBindingTest_ConditionalBinding : UIElement {

            public bool condition;

            public bool SomeCondition() {
                return condition;
            }

        }

        [Test]
        public void ConditionBinding() {
            MockApplication app = Setup<TemplateBindingTest_ConditionalBinding>();
            TemplateBindingTest_ConditionalBinding e = (TemplateBindingTest_ConditionalBinding) app.RootElement;

            app.Update();

            UITextElement textElementTrue = e[0] as UITextElement;
            UITextElement textElementFalse = e[1] as UITextElement;
            Assert.IsTrue(textElementFalse.isEnabled);
            Assert.IsTrue(textElementTrue.isDisabled);

            e.condition = true;
            app.Update();

            Assert.IsTrue(textElementFalse.isDisabled);
            Assert.IsTrue(textElementTrue.isEnabled);
        }

        [Template("Data/TemplateBindings/TemplateBindingTest_StyleBinding.xml")]
        public class TemplateBindingTest_StyleBinding : UIElement { }

        [Test]
        public void StyleBinding() {
            MockApplication app = Setup<TemplateBindingTest_StyleBinding>();
            TemplateBindingTest_StyleBinding e = (TemplateBindingTest_StyleBinding) app.RootElement;

            app.Update();

            Assert.AreEqual(Color.red, e[0].style.BackgroundColor);
            Assert.AreEqual(new OffsetMeasurement(53, OffsetMeasurementUnit.ViewportWidth), e[0].style.Hover.TransformPositionX);
        }

        [Template("Data/TemplateBindings/TemplateBindingTest_DynamicStyleBinding.xml")]
        public class TemplateBindingTest_DynamicStyleBinding : UIElement {

            public bool useDynamic;

            public UIStyleGroupContainer dynamicStyleReference;
            
            public string[] styleList;

            public string[] GetStyleList() {
                return styleList;
            }

        }

        [Test]
        public void DynamicStyleBinding() {
            MockApplication app = Setup<TemplateBindingTest_DynamicStyleBinding>();
            TemplateBindingTest_DynamicStyleBinding e = (TemplateBindingTest_DynamicStyleBinding) app.RootElement;

            e.useDynamic = false;

            app.Update();

            UIElement d0 = e[0];

            List<UIStyleGroupContainer> d0Styles = d0.style.GetBaseStyles();
            Assert.AreEqual(2, d0Styles.Count);
            Assert.AreEqual(e.templateMetaData.ResolveStyleByName("style-1"), d0Styles[0]);
            Assert.AreEqual(e.templateMetaData.ResolveStyleByName("style-2"), d0Styles[1]);

            e.useDynamic = true;

            app.Update();

            d0Styles = d0.style.GetBaseStyles();

            Assert.AreEqual(3, d0Styles.Count);
            Assert.AreEqual(e.templateMetaData.ResolveStyleByName("style-1"), d0Styles[0]);
            Assert.AreEqual(e.templateMetaData.ResolveStyleByName("style-2"), d0Styles[1]);
            Assert.AreEqual(e.templateMetaData.ResolveStyleByName("dynamicStyle"), d0Styles[2]);

            e.useDynamic = false;
            e.styleList = new[] {"list-1", "list-2"};

            app.Update();

            d0Styles = d0.style.GetBaseStyles();

            Assert.AreEqual(4, d0Styles.Count);
            Assert.AreEqual(e.templateMetaData.ResolveStyleByName("style-1"), d0Styles[0]);
            Assert.AreEqual(e.templateMetaData.ResolveStyleByName("style-2"), d0Styles[1]);
            Assert.AreEqual(e.templateMetaData.ResolveStyleByName("list-1"), d0Styles[2]);
            Assert.AreEqual(e.templateMetaData.ResolveStyleByName("list-2"), d0Styles[3]);
        }

        [Template("Data/TemplateBindings/TemplateBindingTest_UnresolvedDynamicStyle.xml")]
        public class TemplateBindingTest_UnresolvedDynamicStyle : UIElement {
            
            public int val;

        }

        [Test]
        public void DynamicStyleBinding_UnresolvedDynamic() {
            MockApplication app = Setup<TemplateBindingTest_UnresolvedDynamicStyle>();
            TemplateBindingTest_UnresolvedDynamicStyle e = (TemplateBindingTest_UnresolvedDynamicStyle) app.RootElement;

            e.val = 1;
            app.Update();

            UIElement d0 = e[0];

            List<UIStyleGroupContainer> d0Styles = d0.style.GetBaseStyles();
            Assert.AreEqual(2, d0Styles.Count);
            Assert.AreEqual(e.templateMetaData.ResolveStyleByName("style-1"), d0Styles[0]);
            Assert.AreEqual(e.templateMetaData.ResolveStyleByName("style-2"), d0Styles[1]);

            e.val = 300;

            app.Update();
            d0Styles = d0.style.GetBaseStyles();
            Assert.AreEqual(1, d0Styles.Count);
            Assert.AreEqual(e.templateMetaData.ResolveStyleByName("style-2"), d0Styles[0]);
           
        }

    }

}