using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendStorage.UI.Wrapper
{
    using Model;

    public class FriendEmailWrapper : ModelWrapper<FriendEmail>
    {
        public FriendEmailWrapper(FriendEmail model)
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

        public string Email
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

        public bool EmailIsChanged
        {
            get { return GetIsChanged(nameof(Email)); }
        }

        public string EmailOriginalValue
        {
            get
            {
                return GetOriginalValue<string>(nameof(Email));
            }
        }

        public string Comment
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

        public bool CommentIsChanged
        {
            get { return GetIsChanged(nameof(Comment)); }
        }

        public string CommentOriginalValue
        {
            get
            {
                return GetOriginalValue<string>(nameof(Comment));
            }
        }
    }
}
