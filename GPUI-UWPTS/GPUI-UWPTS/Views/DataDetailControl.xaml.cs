﻿using System;

using GPUI_UWPTS.Core.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace GPUI_UWPTS.Views
{
    public sealed partial class DataDetailControl : UserControl
    {
        public SampleOrder ListMenuItem
        {
            get { return GetValue(ListMenuItemProperty) as SampleOrder; }
            set { SetValue(ListMenuItemProperty, value); }
        }

        public static readonly DependencyProperty ListMenuItemProperty = DependencyProperty.Register("ListMenuItem", typeof(SampleOrder), typeof(DataDetailControl), new PropertyMetadata(null, OnListMenuItemPropertyChanged));

        public DataDetailControl()
        {
            InitializeComponent();
        }

        private static void OnListMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as DataDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}