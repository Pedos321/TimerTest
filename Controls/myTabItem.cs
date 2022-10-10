using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace TimerTestApp.Controls
/**
Команда закрытия
Событие закрытия 
События открытия
Is Selected 
*/
{
    public class myTabItem : HeaderedContentControl
    {
        private static readonly RoutedUICommand _closeTabCommand = new RoutedUICommand("Close tab", "CloseTab", typeof(myTabItem));

        public static RoutedUICommand CloseTabCommand => _closeTabCommand;

        private static void HandleCloseTabCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (!(sender is myTabItem item)) { return; }
            item.ParentTabControl.RemoveTab(item);
        }

        private void myTabItem_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= myTabItem_Loaded;
            this.Unloaded += myTabItem_Unloaded;
        }

        private void myTabItem_Unloaded(object sender, RoutedEventArgs e)
        {
            this.Unloaded -= myTabItem_Unloaded;
        }

        private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
    
        }


        public bool IsSelected
        {
            get => (bool)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        public static readonly DependencyProperty IsSelectedProperty = Selector.IsSelectedProperty.AddOwner(typeof(myTabItem), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsParentMeasure | FrameworkPropertyMetadataOptions.AffectsParentArrange, OnIsSelectedChanged));

        private MyTabControl ParentTabControl => ItemsControl.ItemsControlFromItemContainer(this) as MyTabControl;

        static myTabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(myTabItem), new FrameworkPropertyMetadata(typeof(myTabItem)));
            CommandManager.RegisterClassCommandBinding(typeof(myTabItem), new CommandBinding(_closeTabCommand, HandleCloseTabCommand));

        }
        public myTabItem()
        {
            this.Loaded += myTabItem_Loaded;
        }


    }

    public  class MyTabControl : TabControl
    {
        internal void RemoveTab(object obj)
        {
        }
    }

    public class MyTabPanel : Panel
    {
        
    }
}
