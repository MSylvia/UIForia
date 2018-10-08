﻿using System.Collections;
using System.Collections.Generic;
using Rendering;
using Src.Util;

namespace Src.Systems {

    public class BindingSystem : ISystem {

        private SkipTree<BindingNode>.TreeNode treeRoot;
        private readonly List<BindingNode> repeatNodes;
        private readonly SkipTree<BindingNode> bindingSkipTree;

        private bool isTreeDirty;

        public BindingSystem() {
            this.isTreeDirty = true;
            this.repeatNodes = new List<BindingNode>();
            this.bindingSkipTree = new SkipTree<BindingNode>();
            this.bindingSkipTree.onTreeChanged += HandleTreeChanged;
        }

        private void HandleTreeChanged(SkipTree<BindingNode>.TreeChangeType changeType) {
            isTreeDirty = true;
        }

        public void OnReset() {
            bindingSkipTree.Clear();
        }

        public void OnUpdate() {
            for (int i = 0; i < repeatNodes.Count; i++) {
                repeatNodes[i].Validate();
            }

            if (isTreeDirty) {
                isTreeDirty = false;
                bindingSkipTree.RecycleTree(treeRoot);
                treeRoot = bindingSkipTree.GetTraversableTree();
            }

            if (treeRoot.children != null && treeRoot.children.Length > 0) {
                treeRoot.children[0].item?.OnUpdate(treeRoot.children[0].children);
            }
        }

        public bool EnableBinding(UIElement element, string bindingId) {
//            TemplateBinding binding = bindingSkipTree.GetItem(element);
//            if (binding == null) return false;
//            for (int i = 0; i < binding.bindings.Length; i++) {
//                if (binding.bindings[i].bindingId == bindingId) {
//                    binding.bindings[i].isEnabled = true;
//                    return true;
//                }
//            }

            return false;
        }

        public bool DisableBinding(UIElement element, string bindingId) {
//            TemplateBinding binding = bindingSkipTree.GetItem(element);
//            if (binding == null) return false;
//            for (int i = 0; i < binding.bindings.Length; i++) {
//                if (binding.bindings[i].bindingId == bindingId) {
//                    binding.bindings[i].isEnabled = false;
//                    return true;
//                }
//            }

            return false;
        }

        public bool HasBinding(UIElement element, string bindingId) {
//            TemplateBinding binding = bindingSkipTree.GetItem(element);
//            if (binding == null) return false;
//            for (int i = 0; i < binding.bindings.Length; i++) {
//                if (binding.bindings[i].bindingId == bindingId) {
//                    return true;
//                }
//            }

            return false;
        }

        public bool IsBindingEnabled(UIElement element, string bindingId) {
//            TemplateBinding binding = bindingSkipTree.GetItem(element);
//            if (binding == null) return false;
//            for (int i = 0; i < binding.bindings.Length; i++) {
//                if (binding.bindings[i].bindingId == bindingId) {
//                    return binding.bindings[i].isEnabled;
//                }
//            }

            return false;
        }

        public void OnDestroy() {
            bindingSkipTree.Clear();
            repeatNodes.Clear();
        }

        public void OnReady() { }

        public void OnInitialize() { }
        public void OnElementCreated(UIElement element) { }

        public void OnElementMoved(UIElement element, int newIndex, int oldIndex) { }

        public void OnElementCreatedFromTemplate(MetaData data) {
            UIElement element = data.element;

            if (data.constantBindings.Length != 0) {
                for (int i = 0; i < data.constantBindings.Length; i++) {
                    data.constantBindings[i].Execute(element, data.context);
                }
            }

            UIRepeatElement repeat = element as UIRepeatElement;
            if (repeat != null) {
                ReflectionUtil.TypeArray2[0] = repeat.listType;
                ReflectionUtil.TypeArray2[1] = repeat.itemType;

                ReflectionUtil.ObjectArray4[0] = repeat.listExpression;
                ReflectionUtil.ObjectArray4[1] = repeat.itemAlias;
                ReflectionUtil.ObjectArray4[2] = repeat.indexAlias;
                ReflectionUtil.ObjectArray4[3] = repeat.lengthAlias;

                RepeatBindingNode node = (RepeatBindingNode) ReflectionUtil.CreateGenericInstanceFromOpenType(
                    typeof(RepeatBindingNode<,>),
                    ReflectionUtil.TypeArray2,
                    ReflectionUtil.ObjectArray4
                );

                node.bindings = data.bindings;
                node.element = data.element;
                node.context = data.context;
                node.template = repeat.template;
                node.scope = repeat.scope;
                repeatNodes.Add(node);
                bindingSkipTree.AddItem(node);
            }

            if (repeat == null && data.bindings.Length > 0) {
                BindingNode node = new BindingNode();
                node.bindings = data.bindings;
                node.element = data.element;
                node.context = data.context;
                bindingSkipTree.AddItem(node);
            }

            for (int i = 0; i < data.children.Count; i++) {
                OnElementCreatedFromTemplate(data.children[i]);
            }
        }

        public void OnElementEnabled(UIElement element) { }

        public void OnElementDisabled(UIElement element) { }

        public void OnElementDestroyed(UIElement element) {
            bindingSkipTree.RemoveHierarchy(element);
            isTreeDirty = true;
        }

        public void OnElementShown(UIElement element) { }

        public void OnElementHidden(UIElement element) { }

        public void OnElementParentChanged(UIElement element, UIElement oldParent, UIElement newParent) {
//            TemplateBinding elementBindings = bindingSkipTree.GetItem(element);
//
//            if (elementBindings != null) {
//                bindingSkipTree.UpdateItemParent(elementBindings);
//            }
//
//            TemplateBinding conditionalBindings = conditionalSkipTree.GetItem(element);
//            if (conditionalBindings != null) {
//                conditionalSkipTree.UpdateItemParent(conditionalBindings);
//            }
        }

    }

}

//if (data.element is UIRepeatChild) {
//TemplateBinding repeatChildBinding = new TemplateBinding(data.element, data.bindings, data.context);
//TemplateBinding parent = bindingSkipTree.GetItem(data.element.parent);
//int childCount = bindingSkipTree.GetChildCount(parent);
//bindingSkipTree.AddItem(repeatChildBinding);
//bindingSkipTree.SetSiblingIndex(repeatChildBinding, childCount - 1);
//}
//else if (data.element is UIRepeatTerminal) {
//// todo -- valid this
//TemplateBinding terminalBinding = new TemplateBinding(data.element, data.bindings, data.context);
//bindingSkipTree.AddItem(terminalBinding);
//bindingSkipTree.SetSiblingIndex(terminalBinding, int.MaxValue);
//}