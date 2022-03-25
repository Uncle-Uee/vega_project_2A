using CyberJellyFish.Utility;
using UnityEngine;

public static class ColorExtension
{
    /// <summary>
    /// Change the Alpha of the instance Color
    /// </summary>
    /// <param name="color"></param>
    /// <param name="alpha"></param>
    /// <returns></returns>
    public static void ChangeAlpha(ref this Color color, float alpha)
    {
        color.a = alpha;
    }

    /// <summary>
    /// Change the instance Color to a HTML String Color
    /// </summary>
    /// <param name="color"></param>
    /// <param name="htmlColor"></param>
    public static void ToHtmlColor(ref this Color color, string htmlColor)
    {
        ColourUtility.HtmlColor(htmlColor, out color);
    }

    public static void ToRandomColor(ref this Color color, bool adjustAlpha = false)
    {
        color.r = Random.value;
        color.g = Random.value;
        color.b = Random.value;
        if (adjustAlpha) color.a = Random.value;
    }
}