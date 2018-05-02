// ---------------------------------------------------------------------------------------------------------------------------------------------------
// Copyright ElcomPlus LLC. All rights reserved.
// Author: 
// ---------------------------------------------------------------------------------------------------------------------------------------------------

namespace FriendStorage.UI.Wrapper
{
    using System.ComponentModel.DataAnnotations;

    using Model;

    public class AddressWrapper : ModelWrapper<Address>
    {
        #region Constructors

        public AddressWrapper(Address model)
            : base(model)
        {
        }

        #endregion

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

        public int IdOriginalValue
        {
            get
            {
                return GetOriginalValue<int>(nameof(Id));
            }
        }

        [Required(ErrorMessage = "City is required")]
        public string City
        {
            get
            {
                return GetValue<string>();
            }
            set
            {
                SetValue(value);
            }
        }

        public bool CityIsChanged
        {
            get
            {
                return GetIsChanged(nameof(City));
            }
        }

        public string CityOriginalProperty
        {
            get
            {
                return GetOriginalValue<string>(nameof(City));
            }
        }

        public string Street
        {
            get
            {
                return GetValue<string>();
            }
            set
            {
                SetValue(value);
            }
        }

        public bool StreetIsChanged
        {
            get
            {
                return GetIsChanged(nameof(Street));
            }
        }

        public string StreetOriginalProperty
        {
            get
            {
                return GetOriginalValue<string>(nameof(Street));
            }
        }

        public string StreetNumber
        {
            get
            {
                return GetValue<string>();
            }
            set
            {
                SetValue(value);
            }
        }

        public bool StreetNumberIsChanged
        {
            get
            {
                return GetIsChanged(nameof(StreetNumber));
            }
        }

        public string StreetNumberOriginalProperty
        {
            get
            {
                return GetOriginalValue<string>(nameof(StreetNumber));
            }
        }
    }
}
