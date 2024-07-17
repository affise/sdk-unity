#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using AffiseAttributionLib.Executors;
using UnityEngine;
using UnityEngine.UIElements;


namespace AffiseDemo
{
    [RequireComponent(typeof(UIDocument))]
    public abstract class BaseUi : MonoBehaviour
    {
        #region variables
        
        private ScrollView? _eventsView;
        private ScrollView? _apiView;
        private VisualElement? _apiContainer;
        
        private VisualElement? _root;
        private VisualElement? _safeZone;
        private TextField? _output;
        private bool _isApi = true;

        private readonly Dictionary<CallbackEventHandler, EventCallback<ClickEvent>> _clickCallback = new();

        private ContextThreadExecutor? _contextExecutor;

        #endregion variables

        private void Start()
        {
            _contextExecutor = new ContextThreadExecutor();
            
            BindView();

            if (_apiView is not null) ApiView(_apiView);
            if (_eventsView is not null) EventsView(_eventsView);
            Init();
        }

        protected abstract void Init();
        protected abstract void ApiView(VisualElement view);
        protected abstract void EventsView(VisualElement view);

        private void OnDestroy()
        {
            UnBindView();
        }

        #region UI utils
        
        private void BindView()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;

            _safeZone = _root.Q<VisualElement>("safe-zone");
            _safeZone.RegisterCallback<GeometryChangedEvent>(LayoutChanged);

            _eventsView = _root.Q<ScrollView>("events");
            _apiContainer = _root.Q<VisualElement>("api-view");
            _apiView = _root.Q<ScrollView>("api");

            _output = _root.Q<TextField>("output");

            BindButton("toggle-btn", ToggleMode);

            BindButton("output-clear", () =>
            {
                _output.value = "";
            });
        }

        private void UnBindView()
        {
            _safeZone?.UnregisterCallback<GeometryChangedEvent>(LayoutChanged);
            UnBindButtons();
        }

        protected void Output(string msg)
        {
            _contextExecutor?.Run(() => OutputTextUI(msg));
        }

        private void OutputTextUI(string msg)
        {
            // Debug.Log(msg);
            if (_output is null) return;
            if (string.IsNullOrWhiteSpace(_output.value))
            {
                _output.value = $"{msg}";
            }
            else
            {
                _output.value += $"\n{msg}";
            }
        }

        private void ToggleMode()
        {
            _isApi = !_isApi;
            Show(_apiContainer, _isApi);
            Hide(_eventsView, _isApi);
        }

        private void UnBindButtons()
        {
            foreach (var (button, callback) in _clickCallback)
            {
                button.UnregisterCallback(callback);
            }

            _clickCallback.Clear();
        }

        private Button BindButton(string btnName, Action action)
        {
            EventCallback<ClickEvent> callback = (_) => 
            {
                action.Invoke();
            };

            var button = _root.Q<Button>(btnName);
            button.RegisterCallback(callback);

            _clickCallback[button] = callback;

            return button;
        }

        private void LayoutChanged(GeometryChangedEvent e)
        {
            SafeAreaMargin(e);
        }

        protected static Button AddButton(VisualElement parent, string title, string? styleClass, Action action)
        {
            var button = new Button
            {
                text = title,
            };
            button.RegisterCallback<ClickEvent>(_ => { action.Invoke(); });
            button.AddToClassList("button");
            button.AddToClassList("affise-button");

            if (styleClass is not null)
            {
                button.AddToClassList(styleClass);
            }

            parent.Add(button);
            return button;
        }

        protected static DropdownField AddDropdown(
            VisualElement parent,
            string title, 
            List<string> values,
            Action<string> action)
        {
            var elm = new DropdownField(title, values, 0);
            elm.RegisterValueChangedCallback(evt => { action.Invoke(evt.newValue); });
            elm.AddToClassList("border");
            parent.Add(elm);
            return elm;
        }

        private static void Hide(VisualElement? input, bool hide = true)
        {
            if (input is null) return;
            input.style.display = hide ? DisplayStyle.None : DisplayStyle.Flex;
        }

        private static void Show(VisualElement? input, bool show = true) => Hide(input, !show);


        private static (Vector2, Vector2) SafeArea(VisualElement elm)
        {
            var safeArea = Screen.safeArea;
            var leftTop = RuntimePanelUtils.ScreenToPanel(elm.panel,
                new Vector2(safeArea.xMin, Screen.height - safeArea.yMax));
            var rightBottom = RuntimePanelUtils.ScreenToPanel(elm.panel,
                new Vector2(Screen.width - safeArea.xMax, safeArea.yMin));

            return (leftTop, rightBottom);
        }

        private static void SafeAreaMargin(VisualElement? elm)
        {
            if (elm is null) return;
            var (leftTop, rightBottom) = SafeArea(elm);
            elm.style.marginLeft = new StyleLength(leftTop.x);
            elm.style.marginTop = new StyleLength(leftTop.y);
            elm.style.marginBottom = new StyleLength(rightBottom.y);
            elm.style.marginRight = new StyleLength(rightBottom.x);
        }

        private static void SafeAreaPadding(VisualElement elm)
        {
            var (leftTop, rightBottom) = SafeArea(elm);
            elm.style.paddingLeft = new StyleLength(leftTop.x);
            elm.style.paddingTop = new StyleLength(leftTop.y);
            elm.style.paddingBottom = new StyleLength(rightBottom.y);
            elm.style.paddingRight = new StyleLength(rightBottom.x);
        }

        private static void SafeAreaMargin(GeometryChangedEvent input) => SafeAreaMargin(input.target as VisualElement);
        
        #endregion UI utils

        protected static string ToCamelCase(string input)
        {
            var words = input.Split('_');
            var list = new List<string>();
            foreach (var e in words)
            {
                if (e is null) continue;
                list.Add(e.First().ToString().ToUpper() + e.Substring(1));
            }
            return string.Join("", list);
        }
    }
}
