// ---------------------------------------------------------------------------------------------------------------------------------------------------
// Copyright ElcomPlus LLC. All rights reserved.
// Author: 
// ---------------------------------------------------------------------------------------------------------------------------------------------------

namespace FriendStorage.UI.Wrapper
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
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

        public string FirstNameOriginalProperty
        {
            get
            {
                {
                    return GetOriginalValue<string>(nameof(FirstName));
                }
            }
        }

        public bool FirstNameIsChanged
        {
            get { return GetIsChanged(nameof(FirstName)); }
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

        public DateTime? Birthday
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

        public ChangeTrackingCollection<FriendEmailWrapper> Emails { get; private set; }

        public string LastNameOriginalProperty
        {
            get
            {
                {
                    return GetOriginalValue<string>(nameof(LastName));
                }
            }
        }

        public bool LastNameIsChanged
        {
            get { return GetIsChanged(nameof(LastName)); }
        }

        public DateTime? BirthdayOriginalProperty
        {
            get
            {
                {
                    return GetOriginalValue<DateTime?>(nameof(Birthday));
                }
            }
        }

        public bool BirthdayIsChanged
        {
            get { return GetIsChanged(nameof(Birthday)); }
        }

        public int IdOriginalProperty
        {
            get
            {
                {
                    return GetOriginalValue<int>(nameof(Id));
                }
            }
        }

        public bool IdIsChanged
        {
            get { return GetIsChanged(nameof(Id)); }
        }

        public int FriendGroupIdOriginalProperty
        {
            get
            {
                {
                    return GetOriginalValue<int>(nameof(FriendGroupId));
                }
            }
        }

        public bool FriendGroupIdIsChanged
        {
            get { return GetIsChanged(nameof(FriendGroupId)); }
        }

        public bool IsDeveloperOriginalProperty
        {
            get
            {
                {
                    return GetOriginalValue<bool>(nameof(IsDeveloper));
                }
            }
        }

        public bool IsDeveloperIsChanged
        {
            get { return GetIsChanged(nameof(IsDeveloper)); }
        }

        #endregion

        #region Constructors

        public FriendWrapper(Friend model)
            : base(model)
        {
        }

        #endregion

        #region Methods

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                yield return new ValidationResult("Firstname is required", 
                    new[] { nameof(FirstName) });
            }
            if (IsDeveloper && !Emails.Any())
            {
                yield return new ValidationResult("A developer must have an email address",
                    new [] {nameof(IsDeveloper), nameof(Emails)});
            }
        }

        protected override void InitializeComplexProperties(Friend model)
        {
            if (model.Address == null)
            {
                throw new ArgumentException(nameof(model.Address));
            }

            Address = new AddressWrapper(model.Address);
            RegisterComplex(Address);
        }

        protected override void InitializeCollectionProperties(Friend model)
        {
            if (model.Emails == null)
            {
                throw new ArgumentException(nameof(model.Emails));
            }

            Emails = 
                new ChangeTrackingCollection<FriendEmailWrapper>(model.Emails.Select(e => new FriendEmailWrapper(e)));

            RegisterCollection(Emails,model.Emails);
        }
        #endregion
    }
}
