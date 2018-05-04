// ---------------------------------------------------------------------------------------------------------------------------------------------------
// Copyright ElcomPlus LLC. All rights reserved.
// Author: 
// ---------------------------------------------------------------------------------------------------------------------------------------------------

namespace FriendStorage.UI.Wrapper
{
    using System.ComponentModel.DataAnnotations;

    using Model;

    public class FriendEmailWrapper : ModelWrapper<FriendEmail>
    {
        #region Constructors

        public FriendEmailWrapper(FriendEmail model)
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

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not valid email address")]
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
            get
            {
                return GetIsChanged(nameof(Email));
            }
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
            get
            {
                return GetIsChanged(nameof(Comment));
            }
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
