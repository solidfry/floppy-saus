using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "World", menuName = "Levels/World", order =+ 1)]
public class World : ScriptableObject
{
    public string worldName;
    [SerializeField]
    public List<Level> levels = new();
}
