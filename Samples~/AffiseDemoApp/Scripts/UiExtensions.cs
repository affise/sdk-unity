using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace AffiseDemo
{
    internal static class UiExtensions
    {
        internal static Button AddButton(this VisualElement parent, string title, Action action)
        {
            var button = new Button
            {
                text = title,
            };
            button.RegisterCallback<ClickEvent>(_ => { action.Invoke(); });
            parent.Add(button);
            button.AddToClassList("button");
            return button;
        }

        internal static DropdownField AddDropdown(
            this VisualElement parent,
            string title, 
            List<string> values,
            Action<string> action)
        {
            var elm = new DropdownField(title, values, 0);
            elm.RegisterValueChangedCallback(evt => { action.Invoke(evt.newValue); });
            parent.Add(elm);
            return elm;
        }

        internal static (Vector2, Vector2) SafeArea(this VisualElement elm)
        {
            var safeArea = Screen.safeArea;
            var leftTop = RuntimePanelUtils.ScreenToPanel(elm.panel,
                new Vector2(safeArea.xMin, Screen.height - safeArea.yMax));
            var rightBottom = RuntimePanelUtils.ScreenToPanel(elm.panel,
                new Vector2(Screen.width - safeArea.xMax, safeArea.yMin));

            return (leftTop, rightBottom);
        }

        internal static void SafeAreaMargin(this VisualElement elm)
        {
            var (leftTop, rightBottom) = elm.SafeArea();
            elm.style.marginLeft = new StyleLength(leftTop.x);
            elm.style.marginTop = new StyleLength(leftTop.y);
            elm.style.marginBottom = new StyleLength(rightBottom.y);
            elm.style.marginRight = new StyleLength(rightBottom.x);
        }

        internal static void SafeAreaPadding(this VisualElement elm)
        {
            var (leftTop, rightBottom) = elm.SafeArea();
            elm.style.paddingLeft = new StyleLength(leftTop.x);
            elm.style.paddingTop = new StyleLength(leftTop.y);
            elm.style.paddingBottom = new StyleLength(rightBottom.y);
            elm.style.paddingRight = new StyleLength(rightBottom.x);
        }
    }
}