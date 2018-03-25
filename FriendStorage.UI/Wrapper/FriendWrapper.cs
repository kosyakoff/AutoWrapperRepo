// ---------------------------------------------------------------------------------------------------------------------------------------------------
// Copyright ElcomPlus LLC. All rights reserved.
// Author: 
// ---------------------------------------------------------------------------------------------------------------------------------------------------

namespace FriendStorage.UI.Wrapper
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Documents;

    using Model;

    public class FriendWrapper : ModelWrapper<Friend>
    {
        #region Properties

        public AddressWrapper Address { get; private set; }

        public string FirstName
        {
            get
            {
                return GetValue<String>();
            }
            set
            {
                SetValue(value);
            }
        }

        public string LastName
        {
            get
            {
                return GetValue<String>();
            }
            set
            {
                SetValue(value);
            }
        }

        public DateTime? BirthDay
        {
            get
            {
                return GetValue<DateTime?>();
            }
            set
            {
                SetValue(value);
            }
        }

        public int Id
        {
            get
            {
                return GetValue<int>();
            }
            set
            {
                SetValue(value);
            }
        }

        public int FriendGroupId
        {
            get
            {
                return GetValue<int>();
            }
            set
            {
                SetValue(value);
            }
        }

        public bool IsDeveloper
        {
            get
            {
                return GetValue<bool>();
            }
            set
            {
                SetValue(value);
            }
        }

        public ObservableCollection<FriendEmailWrapper> Emails { get; private set; }

        #endregion

        #region Constructors

        public FriendWrapper(Friend model)
            : base(model)
        {
            InitializeComplexProperties(model);
            InitializeCollectionProperties(model);
        }

        #endregion

        #region Methods

        private void InitializeComplexProperties(Friend model)
        {
            if (model.Address == null)
            {
                throw new ArgumentException(nameof(model.Address));
            }

            Address = new AddressWrapper(model.Address);
        }

        private void InitializeCollectionProperties(Friend model)
        {
            if (model.Emails == null)
            {
                throw new ArgumentException(nameof(model.Emails));
            }

            Emails = 
                new ObservableCollection<FriendEmailWrapper>(model.Emails.Select(e => new FriendEmailWrapper(e)));

            RegisterCollection(Emails,model.Emails);
        }
        #endregion
    }
}
