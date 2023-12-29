#nullable enable
using System.Collections.Generic;
using AffiseAttributionLib.Editor.Extensions;
using AffiseAttributionLib.Editor.Ui;
using UnityEngine;
using UnityEngine.UIElements;

namespace AffiseAttributionLib.Editor.Elements
{
    internal class ModuleList : VisualElement, INotifyValueChanged<IEnumerable<Modules.Module>>
    {
        #region UXML

        public new class UxmlFactory : UxmlFactory<ModuleList, UxmlTraits>
        {
        }

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
            {
                get { yield break; }
            }

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
            }
        }

        #endregion UXML

        public ModuleList() : this(new List<Modules.Module>())
        {
        }

        public ModuleList(IEnumerable<Modules.Module> modules)
        {
            UI.Get(nameof(ModuleList)).ToRoot(this);
            var modulesView = this.Q<VisualElement>("modules");

            value = modules;

            foreach (var module in value)
            {
                var moduleElement = new ModuleElement(module);
                moduleElement.RegisterValueChangedCallback(OnChangeVal);
                modulesView.Add(moduleElement);
            }
        }

        private void OnChangeVal(ChangeEvent<Modules.Module> evt)
        {
            SetNewValue(evt.newValue);
        }

        private void SetNewValue(Modules.Module newModule)
        {
            if (panel is null) return;
            var newValue = new List<Modules.Module>();

            foreach (var module in value)
            {
                if (module.name == newModule.name)
                {
                    newValue.Add(module.Copy(newModule.android, newModule.ios));
                }
                else
                {
                    newValue.Add(module);
                }
            }

            using (var evt = ChangeEvent<IEnumerable<Modules.Module>>.GetPooled(value, newValue))
            {
                evt.target = this;
                SetValueWithoutNotify(newValue);
                SendEvent(evt);
            }
        }

        public void SetValueWithoutNotify(IEnumerable<Modules.Module> newValue)
        {
            value = newValue;
        }

        public IEnumerable<Modules.Module> value { get; set; }
    }
}