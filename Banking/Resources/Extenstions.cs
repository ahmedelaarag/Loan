using System;
using System.Collections.Generic;
using System.Globalization;

namespace Banking.Resources
{
    public static class Extenstions
    {
        public static double ToDouble(this Decimal @decimal)
        {
            return Convert.ToDouble(@decimal, CultureInfo.InvariantCulture);
        }
        
        public static double Round(this Double @double)
        {
            return Math.Round(@double, 5, MidpointRounding.ToEven);
        }
        
        public static decimal ToDecimal(this Double @double)
        {
            return Convert.ToDecimal(@double, CultureInfo.InvariantCulture);
        }
        
        public static decimal Round(this Decimal @decimal)
        {
            return Math.Round(@decimal, 5, MidpointRounding.ToEven);
        }

        public static string ToStringFormat(this Decimal @decimal)
        {
            return @decimal.ToString("#,#.##", CultureInfo.InvariantCulture);
        }
        
        public static ICollection<T> CurrentOrEmpty<T>(this ICollection<T> collection)
        {
            return collection ?? new List<T>();
        }
    }
}