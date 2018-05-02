// ---------------------------------------------------------------------------------------------------------------------------------------------------
// Copyright ElcomPlus LLC. All rights reserved.
// Author: 
// ---------------------------------------------------------------------------------------------------------------------------------------------------

namespace FriendStorage.UI.Wrapper
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    using ViewModel;

    public class NotifyDataErrorInfoBase : Observable, INotifyDataErrorInfo
    {
        #region Fields

        protected readonly Dictionary<string, List<String>> Errors;

        #endregion

        #region Events

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        #endregion

        #region Properties

        public bool HasErrors
        {
            get
            {
                return Errors.Any();
            }
        }

        #endregion

        #region Constructors

        protected NotifyDataErrorInfoBase()
        {
            Errors = new Dictionary<string, List<string>>();
        }

        #endregion

        #region Methods

        public IEnumerable GetErrors(string propertyName)
        {
            return propertyName != null && Errors.ContainsKey(propertyName) ? Errors[propertyName] : Enumerable.Empty<string>();
        }

        protected virtual void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected void ClearErrors()
        {
            foreach (string propertyName in Errors.Keys.ToList())
            {
                Errors.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }

        #endregion
    }
}
