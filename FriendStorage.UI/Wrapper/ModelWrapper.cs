using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendStorage.UI.Wrapper
{
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;

    using ViewModel;

    public class ModelWrapper<T> : Observable
        where T : class
    {
        public T Model { get; private set; }

        public ModelWrapper(T model)
        {
            if (model == null)
            {
                throw new ArgumentException(nameof(model));
            }

            Model = model;
        }

        protected void SetValue<TValue>(TValue value, [CallerMemberName] string propertyrName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyrName);
            var currentValue = propertyInfo.GetValue(Model);

            if (!Equals(currentValue, value))
            {
                propertyInfo.SetValue(Model, value);
                OnPropertyChanged(propertyrName);
            }
        }

        protected TValue GetValue<TValue>([CallerMemberName] string propertyrName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyrName);

            return (TValue)propertyInfo.GetValue(Model);
        }

        protected void RegisterCollection<TWrapper, TModel>(ObservableCollection<TWrapper> wrappers, List<TModel> models) where TWrapper : ModelWrapper<TModel>
                                                                                                                        where TModel : class
        {
            wrappers.CollectionChanged += (s, e) =>
            {
                if (e.OldItems != null)
                {
                    foreach (var item in e.OldItems.Cast<TWrapper>())
                    {
                        models.Remove(item.Model);
                    }
                }

                if (e.NewItems != null)
                {
                    foreach (var item in e.NewItems.Cast<TWrapper>())
                    {
                        models.Add(item.Model);
                    }
                }
            };
        }

    }
}
