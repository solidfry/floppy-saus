using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "World", menuName = "Levels/World", order = 2)]
public class World : ScriptableObject
{
    [SerializeField]
    public List<Level> levels = new List<Level>();
}