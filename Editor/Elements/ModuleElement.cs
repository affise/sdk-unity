#nullable enable
using System.Collections.Generic;
using AffiseAttributionLib.Editor.Extensions;
using AffiseAttributionLib.Editor.Ui;
using UnityEngine.UIElements;

namespace AffiseAttributionLib.Editor.Elements
{
    internal class ModuleElement : VisualElement, INotifyValueChanged<Modules.Module>
    {
        #region UXML

        public new class UxmlFactory : UxmlFactory<ModuleElement, UxmlTraits>
        {
        }

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            private readonly UxmlStringAttributeDescription _moduleAttribute = new() { name = "Module" };
            private readonly UxmlBoolAttributeDescription _androidAttribute = new() { name = "Android" };
            private readonly UxmlBoolAttributeDescription _iosAttribute = new() { name = "Ios" };

            public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
            {
                get { yield break; }
            }

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var cmp = (ModuleElement)ve;

                cmp.Module = _moduleAttribute.GetValueFromBag(bag, cc);

                cmp.value.androidModule = _androidAttribute.GetValueFromBag(bag, cc);
                cmp.value.iosModule = _iosAttribute.GetValueFromBag(bag, cc);

                cmp._label.text = _moduleAttribute.GetValueFromBag(bag, cc);
                cmp._toggleAndroid.Visible(_androidAttribute.GetValueFromBag(bag, cc));
                cmp._toggleIos.Visible(_iosAttribute.GetValueFromBag(bag, cc));
            }
        }

        #endregion UXML

        public string? Module { get; set; }

        public bool ShowAndroid { get; set; }
        public bool ShowIos { get; set; }

        public Modules.Module value { get; set; }

        private readonly Label _label;
        private readonly Toggle _toggleAndroid;
        private readonly Toggle _toggleIos;

        public ModuleElement() : this(new Modules.Module())
        {
        }

        public ModuleElement(Modules.Module module)
        {
            Module = module.name;
            ShowAndroid = module.androidModule;
            ShowIos = module.iosModule;
            value = module;

            UI.Get(nameof(ModuleElement)).ToRoot(this);
            _label = this.Q<Label>("name");
            _toggleAndroid = this.Q<Toggle>("android");
            _toggleIos = this.Q<Toggle>("ios");

            this.tooltip = module.tooltip;
            _toggleAndroid.value = module.android;
            _toggleIos.value = module.ios;

            _toggleAndroid.RegisterValueChangedCallback(OnChangePlatform);
            _toggleIos.RegisterValueChangedCallback(OnChangePlatform);

            BindData();
        }

        private void BindData()
        {
            _label.text = Module;
            _toggleAndroid.Visible(ShowAndroid);
            _toggleIos.Visible(ShowIos);
        }

        private void OnChangePlatform(ChangeEvent<bool> evt)
        {
            if (evt.previousValue == evt.newValue) return;

            var newValue = value.Copy(_toggleAndroid.value, _toggleIos.value);

            SetNewValue(newValue);
        }

        private void SetNewValue(Modules.Module newValue)
        {
            if (panel is null) return;
            using (var evt = ChangeEvent<Modules.Module>.GetPooled(value, newValue))
            {
                evt.target = this;
                SetValueWithoutNotify(newValue);
                SendEvent(evt);
            }
        }

        public void SetValueWithoutNotify(Modules.Module newValue)
        {
            value = newValue;
        }
    }
}