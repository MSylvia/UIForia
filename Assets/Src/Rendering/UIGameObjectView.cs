﻿using System;
using Src.Systems;
using UnityEngine;

namespace Src.Rendering {

    public sealed class UIGameObjectView : UIView {

        private readonly RectTransform rectTransform;
        
        public UIGameObjectView(Type elementType, RectTransform viewTransform) : base(elementType) {
            this.rectTransform = viewTransform;
            layoutSystem = new LayoutSystem(styleSystem);
            renderSystem = new RenderSystem(Camera.main, layoutSystem, styleSystem);
//            renderSystem = new GORenderSystem(layoutSystem, styleSystem, viewTransform);
            inputSystem = new GOInputSystem(layoutSystem, styleSystem);
            systems.Add(inputSystem);
            systems.Add(layoutSystem);
            systems.Add(renderSystem);
        }

        public override void Update() {
            Rect viewport = rectTransform.rect;
            viewport.y = viewport.height + viewport.y;
            layoutSystem.SetViewportRect(viewport);
            styleSystem.SetViewportRect(viewport);
            base.Update();
        }

    }

}