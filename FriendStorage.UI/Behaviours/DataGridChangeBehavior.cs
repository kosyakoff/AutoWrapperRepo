// ---------------------------------------------------------------------------------------------------------------------------------------------------
// Copyright ElcomPlus LLC. All rights reserved.
// Author: 
// ---------------------------------------------------------------------------------------------------------------------------------------------------

namespace FriendStorage.UI.Behaviours
{
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;

    public static class DataGridChangeBehavior
    {
        #region Fields

        public static readonly DependencyProperty IsActiveProperty;

        #endregion

        #region Constructors

        static DataGridChangeBehavior()
        {
            IsActiveProperty = DependencyProperty.RegisterAttached(
                "IsActive",
                typeof(bool),
                typeof(DataGridChangeBehavior),
                new PropertyMetadata(false, OnIsActivePropertyChanged));
        }

        private static void OnIsActivePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dataGrid = d as DataGrid;

            if (dataGrid != null)
            {
                if ((bool)e.NewValue)
                {
                    dataGrid.Loaded += DataGridLoaded;
                }
                else
                {
                    dataGrid.Loaded -= DataGridLoaded;
                }
            }
        }

        private static void DataGridLoaded(object sender, RoutedEventArgs e)
        {
            var dataGrid = (DataGrid)sender;

            foreach (DataGridTextColumn textColumn in dataGrid.Columns.OfType<DataGridTextColumn>())
            {
                var binding = textColumn.Binding as Binding;

                if (binding != null)
                {
                    textColumn.EditingElementStyle = CreateEditingElementStyle(dataGrid, binding.Path.Path);

                    textColumn.ElementStyle = CreateElementStyle(dataGrid, binding.Path.Path);
                }
            }
        }

        private static Style CreateElementStyle(DataGrid dataGrid, string bindingPath)
        {
            var baseStyle = dataGrid.FindResource("TextBlockBaseStyle") as Style;
            var style = new Style(typeof(TextBlock), baseStyle);

            AddSetters(style, bindingPath, dataGrid);

            return style;
        }

        private static Style CreateEditingElementStyle(DataGrid dataGrid, string bindingPath)
        {
            var baseStyle = dataGrid.FindResource(typeof(TextBox)) as Style;
            var style = new Style(typeof(TextBox), baseStyle);

            AddSetters(style, bindingPath, dataGrid);

            return style;
        }

        private static void AddSetters(Style style, string bindingPath, DataGrid dataGrid)
        {
            style.Setters.Add(new Setter(ChangeBehavior.IsActiveProperty, false));

            style.Setters.Add(new Setter(ChangeBehavior.IsChangedProperty, new Binding(bindingPath + "IsChanged")));

            style.Setters.Add(new Setter(ChangeBehavior.OriginalValueProperty, new Binding(bindingPath + "OriginalValue")));

            style.Setters.Add(new Setter(Validation.ErrorTemplateProperty, dataGrid.FindResource("ErrorInsideErrorTemplate")));

        }

        #endregion

        #region Methods

        public static bool GetIsActive(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsActiveProperty);
        }

        public static void SetIsActive(DependencyObject obj, bool value)
        {
            obj.SetValue(IsActiveProperty, value);
        }

        #endregion
    }
}
