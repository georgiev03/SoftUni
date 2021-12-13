using System;
using System.Collections.Generic;
using System.Text;

namespace Theatre.Common
{
    public static class GlobalConstants
    {
        //Theatre
        public const int THEATRE_NAME_MIN_LENGTH = 4;
        public const int THEATRE_NAME_MAX_LENGTH = 30;

        public const int THEATRE_DIRECTOR_MIN_LENGTH = 4;
        public const int THEATRE_DIRECTOR_MAX_LENGTH = 30;

        public const int THEATRE_HALLS_MIN_VALUE = 1;
        public const int THEATRE_HALLS_MAX_VALUE = 10;

        //Play
        public const int PLAY_TITLE_MIN_LENGTH = 4;
        public const int PLAY_TITLE_MAX_LENGTH = 50;

        public const double PLAY_RATING_MIN_VALUE = 0.0;
        public const double PLAY_RATING_MAX_VALUE = 10.0;

        public const int PLAY_DESCRIPTION_MAX_LENGTH = 700;

        public const int PLAY_SCREENWRITER_MIN_LENGTH = 4;
        public const int PLAY_SCREENWRITER_MAX_LENGTH = 30;

        //Cast
        public const int CAST_NAME_MIN_LENGTH = 4;
        public const int CAST_NAME_MAX_LENGTH = 30;

        public const string CAST_PHONE_REGEX = @"^\+44-\d{2}-\d{3}-\d{4}$";

        //Ticket
        public const double TICKET_PRICE_MIN_VALUE = 1.0;
        public const double TICKET_PRICE_MAX_VALUE = 100.0;

        public const int TICKET_ROWNUMBER_MIN_VALUE = 1;
        public const int TICKET_ROWNUMBER_MAX_VALUE = 10;
    }
}
