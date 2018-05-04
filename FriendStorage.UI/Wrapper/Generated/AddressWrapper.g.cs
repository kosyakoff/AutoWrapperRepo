
		
using System;
using System.Linq;
using FriendStorage.Model;

namespace FriendStorage.UI.Wrapper
{

	public class AddressWrapper : ModelWrapper<Address>
	{
		public AddressWrapper(Address model) : base(model)
		{
		}

		public System.String City
        {
            get
            {
                return GetValue<System.String>();
            }
            set
            {
                SetValue(value);
            }
        }

        public System.String CityOriginalValue
        {
            get
            {
                {
                    return GetOriginalValue<System.String>(nameof(City));
                }
            }
        }

        public bool CityIsChanged
        {
            get { return GetIsChanged(nameof(City)); }
        }

		public System.Int32 Id
        {
            get
            {
                return GetValue<System.Int32>();
            }
            set
            {
                SetValue(value);
            }
        }

        public System.Int32 IdOriginalValue
        {
            get
            {
                {
                    return GetOriginalValue<System.Int32>(nameof(Id));
                }
            }
        }

        public bool IdIsChanged
        {
            get { return GetIsChanged(nameof(Id)); }
        }

		public System.String Street
        {
            get
            {
                return GetValue<System.String>();
            }
            set
            {
                SetValue(value);
            }
        }

        public System.String StreetOriginalValue
        {
            get
            {
                {
                    return GetOriginalValue<System.String>(nameof(Street));
                }
            }
        }

        public bool StreetIsChanged
        {
            get { return GetIsChanged(nameof(Street)); }
        }

		public System.String StreetNumber
        {
            get
            {
                return GetValue<System.String>();
            }
            set
            {
                SetValue(value);
            }
        }

        public System.String StreetNumberOriginalValue
        {
            get
            {
                {
                    return GetOriginalValue<System.String>(nameof(StreetNumber));
                }
            }
        }

        public bool StreetNumberIsChanged
        {
            get { return GetIsChanged(nameof(StreetNumber)); }
        }


	}

}

