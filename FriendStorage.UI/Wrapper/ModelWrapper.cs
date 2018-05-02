// ---------------------------------------------------------------------------------------------------------------------------------------------------
// Copyright ElcomPlus LLC. All rights reserved.
// Author: 
// ---------------------------------------------------------------------------------------------------------------------------------------------------

namespace FriendStorage.UI.Wrapper
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using ViewModel;

    public class ModelWrapper<T> : NotifyDataErrorInfoBase, IValidatableTrackingObject
        where T : class
    {
        private Dictionary<string, object> _originalValues;

        private List<IValidatableTrackingObject> _trackingObjects;

        #region Properties

        public T Model { get; private set; }

        #endregion

        #region Constructors

        public ModelWrapper(T model)
        {
            if (model == null)
            {
                throw new ArgumentException(nameof(model));
            }

            Model = model;
            _originalValues = new Dictionary<string, object>();
            _trackingObjects = new List<IValidatableTrackingObject>();

            Validate();
        }

        public bool IsChanged
        {
            get { return _originalValues.Count > 0 || _trackingObjects.Any(t => t.IsChanged); }
        }

        public bool IsValid
        {
            get
            {
                return !HasErrors && _trackingObjects.All(t => t.IsValid);
            }
        }

        #endregion

        #region Methods

        public void AcceptChanges()
        {
            _originalValues.Clear();
            foreach (IRevertibleChangeTracking trackingObject in _trackingObjects)
            {
                trackingObject.AcceptChanges();
            }
            OnPropertyChanged("");
        }

        public void RejectChanges()
        {
            foreach (KeyValuePair<string, object> originalValueEntry in _originalValues)
            {
                typeof(T).GetProperty(originalValueEntry.Key).SetValue(Model, originalValueEntry.Value);
            }

            _originalValues.Clear();

            foreach (IRevertibleChangeTracking trackingObject in _trackingObjects)
            {
                trackingObject.RejectChanges();
            }

            Validate();
            OnPropertyChanged("");
        }

        protected TValue GetValue<TValue>([CallerMemberName] string propertyrName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyrName);

            return (TValue)propertyInfo.GetValue(Model);
        }

        protected TValue GetOriginalValue<TValue>(string propertyName)
        {
            return _originalValues.ContainsKey(propertyName) ? 
                       (TValue)_originalValues[propertyName] : GetValue<TValue>(propertyName);
        }

        protected bool GetIsChanged(string propertyName)
        {
            return _originalValues.ContainsKey(propertyName);
        }

        protected void RegisterCollection<TWrapper, TModel>(ChangeTrackingCollection<TWrapper> wrapperCollection, List<TModel> modelCollection)
            where TWrapper : ModelWrapper<TModel> where TModel : class
        {
            wrapperCollection.CollectionChanged += (s, e) =>
            {
                modelCollection.Clear();
                modelCollection.AddRange(wrapperCollection.Select(w => w.Model));
            };

            RegisterTrackingObject(wrapperCollection);
        }

        protected void RegisterComplex<TModel>(ModelWrapper<TModel> wrapper) where TModel : class
        {
            RegisterTrackingObject(wrapper);
        }

        protected void SetValue<TValue>(TValue newValue, [CallerMemberName] string propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName);
            var currentValue = propertyInfo.GetValue(Model);

            if (!Equals(currentValue, newValue))
            {
                UpdateOriginalValue(currentValue, newValue, propertyName);
                propertyInfo.SetValue(Model, newValue);
                Validate();
                OnPropertyChanged(propertyName);
                OnPropertyChanged(propertyName + "IsChanged");
            }
        }

        private void RegisterTrackingObject(IValidatableTrackingObject trackingObject)
        {
            if (!_trackingObjects.Contains(trackingObject))
            {
                _trackingObjects.Add(trackingObject);
                trackingObject.PropertyChanged += TrackingObjectPropertyChanged;
            }
        }

        private void Validate()
        {
            ClearErrors();

            var results = new List<ValidationResult>();
            var context = new ValidationContext(this);

            Validator.TryValidateObject(this, context, results, true);

            if (results.Any())
            {
                var propertyNames = results.SelectMany(x => x.MemberNames).Distinct().ToList();

                foreach (string propertyName in propertyNames)
                {
                    Errors[propertyName] = results.
                        Where(r => r.MemberNames.Contains(propertyName)).
                        Select(r => r.ErrorMessage).
                        Distinct().
                        ToList();
                    OnErrorsChanged(propertyName);
                }
            }
            OnPropertyChanged(nameof(IsValid));
        }

        private void TrackingObjectPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IsChanged))
            {
                OnPropertyChanged(nameof(IsChanged));
            }
            else if (e.PropertyName == nameof(IsValid))
            {
                OnPropertyChanged(nameof(IsValid));
            }
        }

        private void UpdateOriginalValue(object currentValue, object newValue, string propertyName)
        {
            if (!_originalValues.ContainsKey(propertyName))
            {
                _originalValues.Add(propertyName, currentValue);
                OnPropertyChanged(nameof(IsChanged));
            }
            else
            {
                if (Equals(_originalValues[propertyName], newValue))
                {
                    _originalValues.Remove(propertyName);
                    OnPropertyChanged(nameof(IsChanged));
                }
            }
        }

        #endregion
    }
}
