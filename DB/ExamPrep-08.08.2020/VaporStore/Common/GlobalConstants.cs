using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace VaporStore.Common
{
    public static class GlobalConstants
    {
        //Game
        public const double GAME_PRICE_MIN_VALUE = 0;
        public const double GAME_PRICE_MAX_VALUE = double.MaxValue;

        //User
        public const string USER_FULLNAME_REGEX = @"^[A-Z][a-z]+ [A-Z][a-z]+$";

        public const int USER_USERNAME_MIN_LENGTH = 3;
        public const int USER_USERNAME_MAX_LENGTH = 20;

        public const int USER_AGE_MIN_YEARS = 3;
        public const int USER_AGE_MAX_YEARS = 103;

        //Card
        public const int CARD_NUMBER_LENGTH = 19;
        public const string CARD_NUMBER_REGEX = @"^\d{4} \d{4} \d{4} \d{4}$";
        public const string CARD_CVC_REGEX = @"^\d{3}$";

        //Purchase
        public const string PURCHASE_KEY_REGEX = @"^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$";

    }
}
