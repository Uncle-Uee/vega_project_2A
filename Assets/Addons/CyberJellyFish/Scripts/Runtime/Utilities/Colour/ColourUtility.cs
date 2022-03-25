/*
 * Created By: Ubaidullah Effendi-Emjedi
 * LinkedIn : https://www.linkedin.com/in/ubaidullah-effendi-emjedi-202494183/
 */

using System;
using System.Globalization;
using UnityEngine;

namespace CyberJellyFish.Utility
{
    public static class ColourUtility
    {
        #region VARIABLES

        private static Color _color;

        #endregion

        #region COLOR UTILITY METHODS

        /// <summary>
        /// Create a New Color based on the 255 Range of Values.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Color Color255(float r, float g, float b, float a = 255f)
        {
            return new Color(r / 255f, g / 255f, b / 255f, a / 255f);
        }

        /// <summary>
        /// Try Pass an HTML Colour String, to a Unity Colour
        /// </summary>
        /// <param name="htmlColor"></param>
        /// <returns></returns>
        public static Color HtmlColor(string htmlColor)
        {
            ColorUtility.TryParseHtmlString(htmlColor, out _color);
            return _color;
        }

        /// <summary>
        /// Try Pass an HTML Colour String, to a Unity Colour
        /// </summary>
        /// <param name="htmlColor"></param>
        /// <param name="color"></param>
        public static void HtmlColor(string htmlColor, out Color color)
        {
            ColorUtility.TryParseHtmlString(htmlColor, out color);
        }

        #endregion
    }
}