using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "World Manager", menuName = "Levels/WorldManager", order =+ 1)]
public class WorldManager : ScriptableObject
{
    [SerializeField]
    public List<World> worlds = new List<World>();

    public Level endlessLevel;
}
