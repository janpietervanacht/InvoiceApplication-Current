using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Model.ConstantsAndEnums
{
    public static class Const
    {
        public static DateTime cMinBirthDate = new DateTime(1900, 01, 01);  // YY MM DD 
        public const string cAuthor = "Jan-Pieter van Acht";

        public static CultureInfo cCultureDutch = new System.Globalization.CultureInfo("nl-NL");
        public static int? cCountryIdNederland = 1;
    }
}    
