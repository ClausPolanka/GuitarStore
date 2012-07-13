// Type: System.Windows.FrameworkElement
// Assembly: PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\WPF\PresentationFramework.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace System.Windows
{
    [UsableDuringInitialization(true)]
    [RuntimeNameProperty("Name")]
    [StyleTypedProperty(Property = "FocusVisualStyle", StyleTargetType = typeof (Control))]
    [XmlLangProperty("Language")]
    public class FrameworkElement : UIElement, IFrameworkInputElement, IInputElement, ISupportInitialize, IHaveResources, IQueryAmbient
    {
        public static readonly DependencyProperty StyleProperty;
        public static readonly DependencyProperty OverridesDefaultStyleProperty;
        public static readonly DependencyProperty UseLayoutRoundingProperty;
        protected internal static readonly DependencyProperty DefaultStyleKeyProperty;
        public static readonly DependencyProperty DataContextProperty;
        public static readonly DependencyProperty BindingGroupProperty;
        public static readonly DependencyProperty LanguageProperty;
        public static readonly DependencyProperty NameProperty;
        public static readonly DependencyProperty TagProperty;
        public static readonly DependencyProperty InputScopeProperty;
        public static readonly RoutedEvent RequestBringIntoViewEvent;
        public static readonly RoutedEvent SizeChangedEvent;
        public static readonly DependencyProperty ActualWidthProperty;
        public static readonly DependencyProperty ActualHeightProperty;
        public static readonly DependencyProperty LayoutTransformProperty;
        public static readonly DependencyProperty WidthProperty;
        public static readonly DependencyProperty MinWidthProperty;
        public static readonly DependencyProperty MaxWidthProperty;
        public static readonly DependencyProperty HeightProperty;
        public static readonly DependencyProperty MinHeightProperty;
        public static readonly DependencyProperty MaxHeightProperty;
        public static readonly DependencyProperty FlowDirectionProperty;
        public static readonly DependencyProperty MarginProperty;
        public static readonly DependencyProperty HorizontalAlignmentProperty;
        public static readonly DependencyProperty VerticalAlignmentProperty;
        public static readonly DependencyProperty FocusVisualStyleProperty;
        public static readonly DependencyProperty CursorProperty;
        public static readonly DependencyProperty ForceCursorProperty;
        public static readonly RoutedEvent LoadedEvent;
        public static readonly RoutedEvent UnloadedEvent;
        public static readonly DependencyProperty ToolTipProperty;
        public static readonly DependencyProperty ContextMenuProperty;
        public static readonly RoutedEvent ToolTipOpeningEvent;
        public static readonly RoutedEvent ToolTipClosingEvent;
        public static readonly RoutedEvent ContextMenuOpeningEvent;
        public static readonly RoutedEvent ContextMenuClosingEvent;
        public FrameworkElement();

        public Style Style { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; set; }

        public bool OverridesDefaultStyle { get; set; }
        public bool UseLayoutRounding { get; set; }
        protected internal object DefaultStyleKey { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TriggerCollection Triggers { get; }

        public DependencyObject TemplatedParent { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; }

        protected override int VisualChildrenCount { get; }

        #region IHaveResources Members

        [Ambient]
        public ResourceDictionary Resources { get; set; }

        #endregion

        protected internal InheritanceBehavior InheritanceBehavior { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Localizability(LocalizationCategory.NeverLocalize)]
        public object DataContext { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Localizability(LocalizationCategory.NeverLocalize)]
        public BindingGroup BindingGroup { get; set; }

        public XmlLanguage Language { get; set; }

        [Localizability(LocalizationCategory.NeverLocalize)]
        public object Tag { get; set; }

        public InputScope InputScope { get; set; }
        public double ActualWidth { get; }
        public double ActualHeight { get; }
        public Transform LayoutTransform { get; set; }

        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        [TypeConverter(typeof (LengthConverter))]
        public double Width { get; set; }

        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        [TypeConverter(typeof (LengthConverter))]
        public double MinWidth { get; set; }

        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        [TypeConverter(typeof (LengthConverter))]
        public double MaxWidth { get; set; }

        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        [TypeConverter(typeof (LengthConverter))]
        public double Height { get; set; }

        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        [TypeConverter(typeof (LengthConverter))]
        public double MinHeight { get; set; }

        [TypeConverter(typeof (LengthConverter))]
        [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
        public double MaxHeight { get; set; }

        [Localizability(LocalizationCategory.None)]
        public FlowDirection FlowDirection { get; set; }

        public Thickness Margin { get; set; }
        public HorizontalAlignment HorizontalAlignment { get; set; }
        public VerticalAlignment VerticalAlignment { get; set; }
        public Style FocusVisualStyle { get; set; }
        public Cursor Cursor { get; set; }
        public bool ForceCursor { get; set; }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public bool IsInitialized { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; }

        public bool IsLoaded { get; }

        [Category("Appearance")]
        [Localizability(LocalizationCategory.ToolTip)]
        [Bindable(true)]
        public object ToolTip { get; set; }

        public ContextMenu ContextMenu { get; set; }

        public DependencyObject Parent { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; }

        protected internal virtual IEnumerator LogicalChildren { get; }

        #region IFrameworkInputElement Members

        [DesignerSerializationOptions(DesignerSerializationOptions.SerializeAsAttribute)]
        [Localizability(LocalizationCategory.NeverLocalize)]
        [MergableProperty(false)]
        public string Name { get; set; }

        #endregion

        #region IQueryAmbient Members

        bool IQueryAmbient.IsAmbientPropertyAvailable(string propertyName);

        #endregion

        #region ISupportInitialize Members

        public virtual void BeginInit();
        public virtual void EndInit();

        #endregion

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeStyle();

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        protected internal virtual void OnStyleChanged(Style oldStyle, Style newStyle);

        protected internal virtual void ParentLayoutInvalidated(UIElement child);
        public bool ApplyTemplate();
        public virtual void OnApplyTemplate();

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void BeginStoryboard(Storyboard storyboard);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public void BeginStoryboard(Storyboard storyboard, HandoffBehavior handoffBehavior);

        public void BeginStoryboard(Storyboard storyboard, HandoffBehavior handoffBehavior, bool isControllable);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeTriggers();

        protected override Visual GetVisualChild(int index);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeResources();

        protected internal DependencyObject GetTemplateChild(string childName);
        public object FindResource(object resourceKey);
        public object TryFindResource(object resourceKey);
        public void SetResourceReference(DependencyProperty dp, object name);
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e);
        protected internal override void OnVisualParentChanged(DependencyObject oldParent);
        public BindingExpression GetBindingExpression(DependencyProperty dp);
        public BindingExpressionBase SetBinding(DependencyProperty dp, BindingBase binding);
        public BindingExpression SetBinding(DependencyProperty dp, string path);
        protected internal override DependencyObject GetUIParentCore();
        public void BringIntoView();
        public void BringIntoView(Rect targetRectangle);
        public static FlowDirection GetFlowDirection(DependencyObject element);
        public static void SetFlowDirection(DependencyObject element, FlowDirection value);
        protected override sealed Size MeasureCore(Size availableSize);
        protected override sealed void ArrangeCore(Rect finalRect);
        protected internal override void OnRenderSizeChanged(SizeChangedInfo sizeInfo);
        protected override Geometry GetLayoutClip(Size layoutSlotSize);
        protected virtual Size MeasureOverride(Size availableSize);
        protected virtual Size ArrangeOverride(Size finalSize);
        public override sealed bool MoveFocus(TraversalRequest request);
        public override sealed DependencyObject PredictFocus(FocusNavigationDirection direction);
        protected override void OnGotFocus(RoutedEventArgs e);
        protected virtual void OnInitialized(EventArgs e);
        protected virtual void OnToolTipOpening(ToolTipEventArgs e);
        protected virtual void OnToolTipClosing(ToolTipEventArgs e);
        protected virtual void OnContextMenuOpening(ContextMenuEventArgs e);
        protected virtual void OnContextMenuClosing(ContextMenuEventArgs e);
        public void RegisterName(string name, object scopedElement);
        public void UnregisterName(string name);
        public object FindName(string name);
        protected internal void AddLogicalChild(object child);
        protected internal void RemoveLogicalChild(object child);

        public event EventHandler<DataTransferEventArgs> TargetUpdated;
        public event EventHandler<DataTransferEventArgs> SourceUpdated;
        public event DependencyPropertyChangedEventHandler DataContextChanged;
        public event RequestBringIntoViewEventHandler RequestBringIntoView;
        public event SizeChangedEventHandler SizeChanged;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event EventHandler Initialized;

        public event RoutedEventHandler Loaded;
        public event RoutedEventHandler Unloaded;
        public event ToolTipEventHandler ToolTipOpening;
        public event ToolTipEventHandler ToolTipClosing;
        public event ContextMenuEventHandler ContextMenuOpening;
        public event ContextMenuEventHandler ContextMenuClosing;
    }
}
