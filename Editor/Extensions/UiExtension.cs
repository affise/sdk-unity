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
        
        public static VisualElement Gone(this VisualElement input, bool gone, string className = "gone")
        {
            if (gone)
            {
                input.AddToClassList(className);
            }
            else
            {
                input.RemoveFromClassList(className);
            }

            return input;
        }
    }
}