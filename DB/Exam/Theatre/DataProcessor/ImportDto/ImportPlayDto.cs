using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlayDto
    {
        [XmlElement("Title")]
        [MinLength(GlobalConstants.PLAY_TITLE_MIN_LENGTH)]
        [MaxLength(GlobalConstants.PLAY_TITLE_MAX_LENGTH)]
        public string Title { get; set; }

        [XmlElement("Duration")]
        public string Duration { get; set; }

        [XmlElement("Rating")]
        [Range(GlobalConstants.PLAY_RATING_MIN_VALUE,
            GlobalConstants.PLAY_RATING_MAX_VALUE)]
        public string Rating { get; set; }

        [XmlElement("Genre")]
        public string Genre { get; set; }

        [XmlElement("Description")]
        [Required]
        public string Description { get; set; }

        [XmlElement("Screenwriter")]
        [MinLength(GlobalConstants.PLAY_SCREENWRITER_MIN_LENGTH)]
        [MaxLength(GlobalConstants.PLAY_SCREENWRITER_MAX_LENGTH)]
        public string Screenwriter { get; set; }
    }
}
