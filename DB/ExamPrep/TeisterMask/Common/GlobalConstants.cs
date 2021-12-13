﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TeisterMask.Common
{
    public static class GlobalConstants
    {
        //Employee
        public const int EMPLOYEE_USERNAME_MIN_LENGTH = 3;
        public const int EMPLOYEE_USERNAME_MAX_LENGTH = 40;
        public const string EMPLOYEE_USERNAME_REGEX = @"^[a-zA-Z\d]+$";
        public const string EMPLOYEE_PHONE_REGEX = @"^\d{3}-\d{3}-\d{4}$";

        public const int EMPLOYEE_PHONE_MAX_LENGTH = 12;

        //Project
        public const int PROJECT_NAME_MIN_LENGTH = 2;
        public const int PROJECT_NAME_MAX_LENGTH = 40;

        //Task
        public const int TASK_NAME_MIN_LENGTH = 2;
        public const int TASK_NAME_MAX_LENGTH = 40;

        public const int TASK_EXEC_MIN_VALUE = 0;
        public const int TASK_EXEC_MAX_VALUE = 3;

        public const int TASK_LABEL_MIN_VALUE = 0;
        public const int TASK_LABEL_MAX_VALUE = 4;
    }
}
