using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralFunctions.Library.Extensions
{
    public static class EnumExtension
    {
        /// <summary>
        /// Check to see if string is in the enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool EnumContains<T>(this string value)
        {
            return Enum.TryParse(typeof(T), value, true, out _);
        }

        /// <summary>
        /// Convert string to enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
