using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ReablementApp.Models
{
    //This model is used to share the current client tghroughout the application
    public static class CurrentClientModel
    {
        public static int CurrentClientID;
        public static string CurrentClientFirstName;
        public static string CurrentClientLastName;
        public static DateTime dob;
        public static DateTime DOB;
        public static int Age;
        public static string Address;
        public static string MedicalConditions;
        public static string AccidentHistory;
        public static double TimeOnRE;
        public static DateTime JoinedRE;
        public static DateTime AppointedOT;
        public static DateTime AppointedCarer;
    }
}
