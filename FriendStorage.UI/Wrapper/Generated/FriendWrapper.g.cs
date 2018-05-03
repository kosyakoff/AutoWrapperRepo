		

using FriendStorage.Model;

namespace FriendStorage.UI.Wrapper
{

	public class FriendWrapper : ModelWrapper<Friend>
	{
		public FriendWrapper(Friend model) : base(model)
		{
		}

		public System.Nullable<System.DateTime> Birthday
        {
            get
            {
                return GetValue<System.Nullable<System.DateTime>>();
            }
            set
            {
                SetValue(value);
            }
        }

        public System.Nullable<System.DateTime> BirthdayOriginalProperty
        {
            get
            {
                {
                    return GetOriginalValue<System.Nullable<System.DateTime>>(nameof(Birthday));
                }
            }
        }

        public bool BirthdayIsChanged
        {
            get { return GetIsChanged(nameof(Birthday)); }
        }

		public System.String FirstName
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

        public System.String FirstNameOriginalProperty
        {
            get
            {
                {
                    return GetOriginalValue<System.String>(nameof(FirstName));
                }
            }
        }

        public bool FirstNameIsChanged
        {
            get { return GetIsChanged(nameof(FirstName)); }
        }

		public System.Int32 FriendGroupId
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

        public System.Int32 FriendGroupIdOriginalProperty
        {
            get
            {
                {
                    return GetOriginalValue<System.Int32>(nameof(FriendGroupId));
                }
            }
        }

        public bool FriendGroupIdIsChanged
        {
            get { return GetIsChanged(nameof(FriendGroupId)); }
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

        public System.Int32 IdOriginalProperty
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

		public System.Boolean IsDeveloper
        {
            get
            {
                return GetValue<System.Boolean>();
            }
            set
            {
                SetValue(value);
            }
        }

        public System.Boolean IsDeveloperOriginalProperty
        {
            get
            {
                {
                    return GetOriginalValue<System.Boolean>(nameof(IsDeveloper));
                }
            }
        }

        public bool IsDeveloperIsChanged
        {
            get { return GetIsChanged(nameof(IsDeveloper)); }
        }

		public System.String LastName
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

        public System.String LastNameOriginalProperty
        {
            get
            {
                {
                    return GetOriginalValue<System.String>(nameof(LastName));
                }
            }
        }

        public bool LastNameIsChanged
        {
            get { return GetIsChanged(nameof(LastName)); }
        }


	}

}

