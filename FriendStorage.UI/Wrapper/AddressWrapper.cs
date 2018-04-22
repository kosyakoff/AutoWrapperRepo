using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendStorage.UI.Wrapper
{
    using Model;

    public class AddressWrapper : ModelWrapper<Address>
    {
        public AddressWrapper(Address model)
            : base(model)
        {
            
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

        public int IdOriginalValue
        {
            get
            {
                return GetOriginalValue<int>(nameof(Id));
            }
        }

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

        public string CityOriginalValue
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

        public string StreetOriginalValue
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

        public string StreetNumberOriginalValue
        {
            get
            {
                return GetOriginalValue<string>(nameof(StreetNumber));
            }
        }
    }
}
