using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Common;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUserDto
    {
        [Required]
        [RegularExpression(GlobalConstants.USER_FULLNAME_REGEX)]
        public string FullName { get; set; }

        [Required]
        [MinLength(GlobalConstants.USER_USERNAME_MIN_LENGTH)]
        [MaxLength(GlobalConstants.USER_USERNAME_MAX_LENGTH)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Range(GlobalConstants.USER_AGE_MIN_YEARS, GlobalConstants.USER_AGE_MAX_YEARS)]
        public int Age { get; set; }

        [MinLength(1)]
        public ImportUserCardDto[] Cards { get; set; }
    }
}
