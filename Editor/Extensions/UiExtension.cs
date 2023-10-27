#nullable enable
using UnityEngine.UIElements;

namespace AffiseAttributionLib.Editor.Extensions
{
    internal static class UiExtension
    {
        public static VisualElement? ToRoot(this VisualTreeAsset? input, VisualElement? root)
        {
            if (input is null) return null;
            if (root is null) return null;
            
            input.CloneTree(root);

            return root; 
        }
        
        public static VisualElement? Hide(this VisualElement? input, bool hide = true)
        {
            if (input is null) return null;
            input.style.display = hide ? DisplayStyle.None : DisplayStyle.Flex;
            return input;
        }
        
        public static VisualElement? Show(this VisualElement? input, bool show = true) => input.Hide(!show);
        
        public static VisualElement? ToggleClass(this VisualElement? input, string style, bool active = true)
        {
            if (input is null) return null;
            
            if (active)
            {
                input.AddToClassList(style);
            }
            else
            {
                input.RemoveFromClassList(style);
            }
            return input;
        }
    }
}