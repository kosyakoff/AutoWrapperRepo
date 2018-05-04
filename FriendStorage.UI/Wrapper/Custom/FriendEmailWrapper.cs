﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendStorage.UI.Wrapper
{
    public partial class FriendEmailWrapper
    {
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                yield return new ValidationResult("Email is required",
                    new[] { nameof(Email) });
            }

            if (!new EmailAddressAttribute().IsValid(Email))
            {
                yield return new ValidationResult("Email is not valid email address",
                    new[] { nameof(Email) });
            }
        }
    }
}