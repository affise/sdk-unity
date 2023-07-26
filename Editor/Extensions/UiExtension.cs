using UnityEngine.UIElements;

namespace AffiseAttributionLib.Editor.Extensions
{
    public static class UiExtension
    {
        public static VisualElement ToRoot(this VisualTreeAsset input, VisualElement root)
        {
            input.CloneTree(root);
            return root; 
        }
        
        public static VisualElement Hide(this VisualElement input, bool hide = true)
        {
            input.style.display = hide ? DisplayStyle.None : DisplayStyle.Flex;
            return input;
        }
        
        public static VisualElement Show(this VisualElement input, bool show = true) => input.Hide(!show);
    }
}