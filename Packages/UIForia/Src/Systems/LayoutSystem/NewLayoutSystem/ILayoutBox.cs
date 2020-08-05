﻿using System;
using UIForia.Elements;
using UIForia.Rendering;
using UIForia.Systems;

namespace UIForia.Layout {

    internal unsafe interface ILayoutBox : IDisposable {

        void OnInitialize(LayoutSystem layoutSystem, UIElement element);

        float ResolveAutoWidth(ref BurstLayoutRunner runner, ElementId elementId, UIMeasurement measurement, in BlockSize blockSize);
        
        float ResolveAutoHeight(ref BurstLayoutRunner runner, ElementId elementId, UIMeasurement measurement, in BlockSize blockSize);

        void RunHorizontal(BurstLayoutRunner* runner);

        void RunVertical(BurstLayoutRunner* runner);

        float ComputeContentWidth(ref BurstLayoutRunner layoutRunner, in BlockSize blockSize);
        
        float ComputeContentHeight(ref BurstLayoutRunner layoutRunner, in BlockSize blockSize);


    }

}