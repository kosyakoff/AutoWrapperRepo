		

using FriendStorage.Model;

namespace FriendStorage.UI.Wrapper
{

	public class FriendEmailWrapper : ModelWrapper<FriendEmail>
	{
		public FriendEmailWrapper(FriendEmail model) : base(model)
		{
		}

		public System.String Comment
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

        public System.String CommentOriginalProperty
        {
            get
            {
                {
                    return GetOriginalValue<System.String>(nameof(Comment));
                }
            }
        }

        public bool CommentIsChanged
        {
            get { return GetIsChanged(nameof(Comment)); }
        }

		public System.String Email
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

        public System.String EmailOriginalProperty
        {
            get
            {
                {
                    return GetOriginalValue<System.String>(nameof(Email));
                }
            }
        }

        public bool EmailIsChanged
        {
            get { return GetIsChanged(nameof(Email)); }
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


	}

}

