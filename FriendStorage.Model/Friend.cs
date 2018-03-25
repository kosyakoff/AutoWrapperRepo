// ---------------------------------------------------------------------------------------------------------------------------------------------------
// Copyright ElcomPlus LLC. All rights reserved.
// Author: 
// ---------------------------------------------------------------------------------------------------------------------------------------------------

namespace FriendStorage.Model
{
    using System;
    using System.Collections.Generic;

    public class Friend
    {
        #region Properties

        public Address Address { get; set; }

        public DateTime? Birthday { get; set; }

        public List<FriendEmail> Emails { get; set; }

        public string FirstName { get; set; }

        public int FriendGroupId { get; set; }
        public int Id { get; set; }

        public bool IsDeveloper { get; set; }

        public string LastName { get; set; }

        #endregion
    }
}
