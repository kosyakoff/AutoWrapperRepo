// ---------------------------------------------------------------------------------------------------------------------------------------------------
// Copyright ElcomPlus LLC. All rights reserved.
// Author: 
// ---------------------------------------------------------------------------------------------------------------------------------------------------

namespace FriendStorage.UI.Behaviours
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Data;

    public static class ChangeBehavior
    {
        #region Fields

        public static readonly DependencyProperty IsActiveProperty;

        public static readonly DependencyProperty IsChangedProperty;
        public static readonly DependencyProperty OriginalValueConverterProperty;
        public static readonly DependencyProperty OriginalValueProperty;

        private static readonly Dictionary<Type, DependencyProperty> _defaultProperties;

        #endregion

        #region Constructors

        static ChangeBehavior()
        {
            OriginalValueConverterProperty = DependencyProperty.RegisterAttached(
                "OriginalValueConverter",
                typeof(IValueConverter),
                typeof(ChangeBehavior),
                new PropertyMetadata(null, OnOriginalValueConverterPropertyChanged));

            IsChangedProperty = DependencyProperty.RegisterAttached("IsChanged", typeof(bool), typeof(ChangeBehavior), new PropertyMetadata(false));

            OriginalValueProperty = DependencyProperty.RegisterAttached(
                "OriginalValue",
                typeof(object),
                typeof(ChangeBehavior),
                new PropertyMetadata(null));

            IsActiveProperty = DependencyProperty.RegisterAttached(
                "IsActive",
                typeof(bool),
                typeof(ChangeBehavior),
                new PropertyMetadata(false, OnIsActivePropertyChanged));

            _defaultProperties = new Dictionary<Type, DependencyProperty>()
            {
                { typeof(TextBox), TextBox.TextProperty },
                { typeof(CheckBox), ToggleButton.IsCheckedProperty },
                { typeof(DatePicker), DatePicker.SelectedDateProperty },
                { typeof(ComboBox), Selector.SelectedValueProperty }
            };
        }

        #endregion

        #region Methods

        public static bool GetIsActive(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsActiveProperty);
        }

        public static bool GetIsChanged(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsChangedProperty);
        }

        public static object GetOriginalValue(DependencyObject obj)
        {
            return obj.GetValue(OriginalValueProperty);
        }

        public static IValueConverter GetOriginalValueConverter(DependencyObject obj)
        {
            return (IValueConverter)obj.GetValue(OriginalValueConverterProperty);
        }

        public static void SetIsActive(DependencyObject obj, bool value)
        {
            obj.SetValue(IsActiveProperty, value);
        }

        public static void SetIsChanged(DependencyObject obj, bool value)
        {
            obj.SetValue(IsChangedProperty, value);
        }

        public static void SetOriginalValue(DependencyObject obj, object value)
        {
            obj.SetValue(OriginalValueProperty, value);
        }

        public static void SetOriginalValueConverter(DependencyObject obj, IValueConverter value)
        {
            obj.SetValue(OriginalValueConverterProperty, value);
        }

        private static void CreatOriginalValueBinding(DependencyObject d, string originalValueBindingPath)
        {
            var newBinding = new Binding(originalValueBindingPath)
            {
                Converter = GetOriginalValueConverter(d),
                ConverterParameter = d
            };

            BindingOperations.SetBinding(d, OriginalValueProperty, newBinding);
        }

        private static void OnIsActivePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (_defaultProperties.ContainsKey(d.GetType()))
            {
                var defaultProperty = _defaultProperties[d.GetType()];

                if ((bool)e.NewValue)
                {
                    var binding = BindingOperations.GetBinding(d, defaultProperty);

                    if (binding != null)
                    {
                        string bindingPath = binding.Path.Path;
                        BindingOperations.SetBinding(d, IsChangedProperty, new Binding(bindingPath + "IsChanged"));
                        CreatOriginalValueBinding(d, bindingPath + "OriginalProperty");
                    }
                }
                else
                {
                    BindingOperations.ClearBinding(d, IsChangedProperty);
                    BindingOperations.ClearBinding(d, OriginalValueProperty);
                }
            }
        }

        private static void OnOriginalValueConverterPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Binding originalValueBinding = BindingOperations.GetBinding(d, OriginalValueProperty);

            if (originalValueBinding != null)
            {
                CreatOriginalValueBinding(d, originalValueBinding.Path.Path);
            }
        }

        #endregion
    }
}
