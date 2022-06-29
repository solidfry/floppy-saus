using UnityEngine;
namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Color", menuName = "Palettes/New Colour", order = 1)]
    public class ColorEntry : ScriptableObject
    {
        public string colorName;
        public Color color;
    }
}