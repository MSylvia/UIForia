using System;
using UIForia.Systems;
using UIForia.UIInput;
using UIForia.Util;
using UnityEngine;

namespace UIForia.Elements {

    public class InputHandlerGroup {

        public InputEventType handledEvents;
        public LightList<HandlerData> eventHandlers;
        public LightList<DragCreatorData> dragCreators;

        public void AddDragCreator(KeyboardModifiers modifiers, bool requiresFocus, EventPhase phase, Action<LinqBindingNode, InputEventHolder> creator) {
            dragCreators = dragCreators ?? new LightList<DragCreatorData>(1);
            handledEvents |= InputEventType.DragCreate;
            dragCreators.Add(new DragCreatorData() {
                eventPhase = phase,
                requireFocus = requiresFocus,
                modifiers = modifiers,
                handler = creator
            });
        }

        public void AddMouseEvent(InputEventType eventType, KeyboardModifiers modifiers, bool requiresFocus, EventPhase phase, Action<LinqBindingNode, InputEventHolder> handler) {
            handledEvents |= eventType;
            eventHandlers = eventHandlers ?? new LightList<HandlerData>(2);
            eventHandlers.Add(new HandlerData() {
                eventType = eventType,
                eventPhase = phase,
                keyCode = 0,
                character = '\0',
                requireFocus = requiresFocus,
                modifiers = modifiers,
                handlerFn = handler
            });
        }

        public void AddDragEvent(InputEventType eventType, KeyboardModifiers modifiers, bool requiresFocus, EventPhase phase,Action<LinqBindingNode, InputEventHolder> handler) {
            handledEvents |= eventType;
            eventHandlers = eventHandlers ?? new LightList<HandlerData>(2);
            eventHandlers.Add(new HandlerData() {
                eventType = eventType,
                eventPhase = phase,
                keyCode = 0,
                character = '\0',
                requireFocus = requiresFocus,
                modifiers = modifiers,
                handlerFn = handler
            });
        }

        public void AddKeyboardEvent(InputEventType eventType, KeyboardModifiers modifiers, bool requiresFocus, EventPhase phase, KeyCode keyCode, char character, Action<LinqBindingNode, InputEventHolder> handler) {
            handledEvents |= eventType;
            eventHandlers = eventHandlers ?? new LightList<HandlerData>(2);
            eventHandlers.Add(new HandlerData() {
                eventType = eventType,
                eventPhase = phase,
                keyCode = keyCode,
                character = character,
                requireFocus = requiresFocus,
                modifiers = modifiers,
                handlerFn = handler
            });
        }

        public struct HandlerData {

            public InputEventType eventType;
            public KeyboardModifiers modifiers;
            public KeyCode keyCode;
            public char character;
            public bool requireFocus;
            public EventPhase eventPhase;
            public Action<LinqBindingNode, InputEventHolder> handlerFn;

        }

        // todo -- remove this?
        public struct DragCreatorData {

            public KeyboardModifiers modifiers;
            public bool requireFocus;
            public EventPhase eventPhase;
            public Action<LinqBindingNode, InputEventHolder> handler;

        }

    }

}