/*
 * Created By: Ubaidullah Effendi-Emjedi
 * LinkedIn : https://www.linkedin.com/in/ubaidullah-effendi-emjedi-202494183/
 */

using System;
using System.Text;

public static class StringExtension
{
    /// <summary>
    ///     Concat String Data using String Builder.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="separator"></param>
    /// <param name="values"></param>
    /// <returns></returns>
    public static string Combine(this string item, string separator = " ", params object[] values)
    {
        if (values?.Length == 0)
            return item;

        if (values.Length == 1 && !values[0].GetType().IsArray)
        {
            return $"{item}{separator}{values[0]}";
        }

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append($"{item}{separator}");
        foreach (object element in values)
        {
            stringBuilder.Append(element.GetType().IsArray ? (element as Array).Display() : $"{element}{separator}");
        }

        return stringBuilder.ToString();
    }

    public static string Combine(this string item, string element, string separator = " ")
    {
        return $"{item}{separator}{element}";
    }

    public static string Combine(this string item, object[] elements, string separator = " ")
    {
        if (elements.IsNull()) return item;

        if (elements.Length == 1 && !elements[0].GetType().IsArray) return $"{item}{separator}{elements[0]}";

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append($"{item}{separator}");
        foreach (object element in elements)
        {
            stringBuilder.Append(element.GetType().IsArray ? (element as Array).Display() : $"{element}{separator}");
        }

        return $"{stringBuilder}";
    }
}