using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

[CreateAssetMenu(fileName = "Color", menuName = "Palettes/Colour Palette", order = 1)]
public class Colors : ScriptableObject
{
    public List<ColorEntry> colors = new();

    public Color GetColor(string name)
    {
        var entry = colors.Find(c => c.name == name);
        if (entry != null)
        {
            return entry.color;
        }

        return Color.white;
    }
}
