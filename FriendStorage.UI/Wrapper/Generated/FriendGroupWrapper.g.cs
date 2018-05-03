		

using FriendStorage.Model;

namespace FriendStorage.UI.Wrapper
{

	public class FriendGroupWrapper : ModelWrapper<FriendGroup>
	{
		public FriendGroupWrapper(FriendGroup model) : base(model)
		{
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

		public System.String Name
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

        public System.String NameOriginalProperty
        {
            get
            {
                {
                    return GetOriginalValue<System.String>(nameof(Name));
                }
            }
        }

        public bool NameIsChanged
        {
            get { return GetIsChanged(nameof(Name)); }
        }


	}

}
