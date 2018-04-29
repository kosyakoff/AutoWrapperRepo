// ---------------------------------------------------------------------------------------------------------------------------------------------------
// Copyright ElcomPlus LLC. All rights reserved.
// Author: 
// ---------------------------------------------------------------------------------------------------------------------------------------------------

namespace FriendStorage.UI.Converters
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Controls;
    using System.Windows.Data;

    using DataProvider.Lookups;

    public class ComboBoxOriginalValueConverter : IValueConverter
    {
        #region Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var id = (int)value;
            var combobox = parameter as ComboBox;

            if (combobox?.ItemsSource != null)
            {
                LookupItem lookupItem = combobox.ItemsSource.OfType<LookupItem>().SingleOrDefault(l => l.Id == id);

                if (lookupItem != null)
                {
                    return lookupItem.DisplayValue;
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
