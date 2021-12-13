using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTheatreTicketsDto
    {
        [MinLength(GlobalConstants.THEATRE_NAME_MIN_LENGTH)]
        [MaxLength(GlobalConstants.THEATRE_NAME_MAX_LENGTH)]
        public string Name { get; set; }

        [Range(GlobalConstants.THEATRE_HALLS_MIN_VALUE,
            GlobalConstants.THEATRE_HALLS_MAX_VALUE)]
        public sbyte NumberOfHalls { get; set; }

        [MinLength(GlobalConstants.THEATRE_DIRECTOR_MIN_LENGTH)]
        [MaxLength(GlobalConstants.THEATRE_DIRECTOR_MAX_LENGTH)]
        public string Director { get; set; }

        public ImportTicketDto[] Tickets { get; set; }
    }
}
