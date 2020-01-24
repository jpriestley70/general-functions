using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralFunctions.Library.Extensions
{
    public static class ListExtension
    {
        public static void AppendList<T>(this List<T> appendTo, List<T> list)
        {
            foreach(T item in list)
            {
                appendTo.Add(item);
            }
        }
    }
}
