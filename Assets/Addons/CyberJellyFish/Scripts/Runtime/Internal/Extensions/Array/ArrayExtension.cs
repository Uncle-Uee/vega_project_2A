/*
 * Created By: Ubaidullah Effendi-Emjedi
 * LinkedIn : https://www.linkedin.com/in/ubaidullah-effendi-emjedi-202494183/
 */

using System;
using UnityEngine;
using Random = System.Random;

/// <summary>
/// Extend the Array Class.
/// </summary>
public static class ArrayExtension
{
    private static object _element;

    /// <summary>
    ///     Shuffling Algorithm Based on Knuth Fisher Yates Shuffle.
    /// </summary>
    /// <example>
    ///     <code>
    /// T[] list = { 1, 2, 3};
    /// list.Shuffle();
    /// </code>
    /// </example>
    /// <param name="array"></param>
    /// <typeparam name="T"></typeparam>
    public static void Shuffle(this Array array)
    {
        Random random = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array.Swap(i, i + random.Next(array.Length - i));
        }
    }

    /// <summary>
    ///     Swap 2 Elements at Index i and Index j.
    /// </summary>
    /// <param name="array"></param>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <returns>
    ///     The list with the newly Swapped Elements.
    /// </returns>
    private static void Swap(this Array array, int i, int j)
    {
        _element = array.GetValue(i);
        array.SetValue(array.GetValue(j), i);
        array.SetValue(_element, j);
    }

    /// <summary>
    /// Return String data of the Array Elements.
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public static string Display(this Array array)
    {
        array.Display(out string output);
        return output;
    }

    public static void Display(this Array array, out string output)
    {
        output = "";
        int length = array.Length;
        for (int i = 0; i < length; i++)
        {
            if (array.GetValue(i).GetType().IsArray)
            {
                output.Combine((array.GetValue(i) as Array).Display());
            }
            else
                output = output.Combine($"{array.GetValue(i)}");
        }

        output = output.Combine("\n");
    }
}