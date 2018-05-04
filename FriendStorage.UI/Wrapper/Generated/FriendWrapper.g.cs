		
using System;
using System.Linq;
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

        public System.Nullable<System.DateTime> BirthdayOriginalValue
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

        public System.String FirstNameOriginalValue
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

        public System.Int32 FriendGroupIdOriginalValue
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

        public System.Boolean IsDeveloperOriginalValue
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

        public System.String LastNameOriginalValue
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

 
		public AddressWrapper Address { get; private set; }
	 
	public ChangeTrackingCollection<FriendEmailWrapper> Emails { get; private set; }
	    
	protected override void InitializeComplexProperties(Friend model)
	{
		if (model.Address == null)
		{
		throw new ArgumentException("Address cannot be null");
		}
		Address = new AddressWrapper(model.Address);
		RegisterComplex(Address);
	}

	protected override void InitializeCollectionProperties(Friend model)
	{
		if (model.Emails == null)
		{
			throw new ArgumentException("Emails cannot be null");
		}
 
		Emails = new ChangeTrackingCollection<FriendEmailWrapper>(
		model.Emails.Select(e => new FriendEmailWrapper(e)));
		RegisterCollection(Emails, model.Emails);
	}

	}

}

