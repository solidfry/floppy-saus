using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "World", menuName = "Levels/World", order = 2)]
public class World : ScriptableObject
{
    [SerializeField]
    private List<Level> levels = new List<Level>();
    [SerializeField]
    private GameObject levelCard;

    public void CreateWorldUI()
    {
        foreach (Level level in levels)
        {
            // Instance of LevelCardUI prefab
            GameObject lc = Instantiate(levelCard);

            LevelCardUI lcScript = lc.GetComponent<LevelCardUI>();

        }
    }
}
