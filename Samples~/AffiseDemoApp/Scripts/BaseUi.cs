#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;


namespace AffiseDemo
{
    [RequireComponent(typeof(UIDocument))]
    public abstract class BaseUi : MonoBehaviour
    {
        #region variables
        
        private VisualElement? _tabViews;
        private ScrollView? _apiView;
        private ScrollView? _eventsView;
        private VisualElement? _storeView;
        private VisualElement? _apiContainer;
        
        private VisualElement? _alert;
        private Label? _alertTitle;
        private Label? _alertText;

        private VisualElement? _root;
        private VisualElement? _safeZone;
        private TextField? _output;

        private readonly Dictionary<CallbackEventHandler, EventCallback<ClickEvent>> _clickCallback = new();

        #endregion variables

        private void Start()
        {
            BindView();

            if (_apiView is not null) ApiView(_apiView);
            if (_eventsView is not null) EventsView(_eventsView);
            if (_storeView is not null) StoreView(_storeView);
            Init();
        }

        protected abstract void Init();
        protected abstract void ApiView(VisualElement view);
        protected abstract void EventsView(VisualElement view);
        protected abstract void StoreView(VisualElement view);

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

            _tabViews = _root.Q<VisualElement>("tab-views");
            _eventsView = _tabViews.Q<ScrollView>("events");
            _apiContainer = _tabViews.Q<VisualElement>("api-view");
            _apiView = _apiContainer.Q<ScrollView>("api");
            _storeView = _tabViews.Q<VisualElement>("store");

            _output = _root.Q<TextField>("output");

            BindAlert();
            BindTabs(_tabViews);

            BindButton("output-clear", () =>
            {
                _output.value = "";
            });
        }
        
        #region Alert View
        
        private void BindAlert()
        {
            _alert = _root.Q<VisualElement>("alert");
            var alertClose = _root.Q<Button>("alert-close");
            _alertTitle = _root.Q<Label>("alert-title");
            _alertText = _root.Q<Label>("alert-text");

            _alert.visible = false;
            
            EventCallback<ClickEvent> callback = (_) =>
            {
                _alert.visible = !_alert.visible;
            };
            _alert.RegisterCallback(callback);

            _clickCallback[alertClose] = callback;
        }

        protected void Alert(string title, string text)
        {
            if (_alertTitle is null) return;
            if (_alertText is null) return;
            if (_alert is null) return;

            _alertTitle.text = title;
            _alertText.text = text;
            _alert.visible = true;
        }
        
        #endregion
        
        private void BindTabs(VisualElement tabViews)
        {
            var tabsButtons = _root.Q<VisualElement>("tabs");
            var tabChildren = tabsButtons.Children().OfType<Button>();
            var tabs = tabViews.Children().Select((view, i) => (view, i));
            
            foreach (var (button, i) in tabChildren.Select((button, i) => (button, i)))
            {
                BindButton(button, (() =>
                {
                    ToggleMode(tabs, i);
                    OnTabShow(i);
                }));
            }
        }

        protected virtual void OnTabShow(int index)
        {
        }

        private void UnBindView()
        {
            _safeZone?.UnregisterCallback<GeometryChangedEvent>(LayoutChanged);
            UnBindButtons();
        }

        protected void Output(string msg)
        {
            OutputTextUI(msg);
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

        private void ToggleMode(IEnumerable<(VisualElement view, int i)> views, int index)
        {
            foreach (var (view, i) in views)
            {
                Show(view, index == i);
            }
        }

        private void UnBindButtons()
        {
            foreach (var (button, callback) in _clickCallback)
            {
                button.UnregisterCallback(callback);
            }

            _clickCallback.Clear();
        }

        private Button BindButton(Button button, Action action)
        {
            EventCallback<ClickEvent> callback = (_) => 
            {
                action.Invoke();
            };

            button.RegisterCallback(callback);

            _clickCallback[button] = callback;

            return button;
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
        
        protected static VisualElement AddView(VisualElement parent, Action<VisualElement> action)
        {
            var view = new VisualElement();
            action.Invoke(view);
            parent.Add(view);
            return view;
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
