using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Common;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUserCardDto
    {
        [Required]
        [RegularExpression(GlobalConstants.CARD_NUMBER_REGEX)]
        public string Number { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.CARD_CVC_REGEX)]
        public string CVC { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
