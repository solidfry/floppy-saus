using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "World", menuName = "Levels/World", order =+ 1)]
public class World : ScriptableObject
{
    public string worldName;
    [SerializeField]
    public List<Level> levels = new();
    [SerializeField][ReadOnly]
    private List<bool> levelsComplete = new();

    private void Awake() => DetermineCompleteLevels();
    
    private void OnValidate() => DetermineCompleteLevels();

    void DetermineCompleteLevels()
    {
        levelsComplete.Clear();
        foreach (Level level in levels)
        {
            levelsComplete.Add(level.levelComplete);
        }
    }
}
