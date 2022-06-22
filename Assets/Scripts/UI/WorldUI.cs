using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldUI : MonoBehaviour
{
    public World world;
    public TMP_Text titleText;
    private GameObject levelCard;
    [SerializeField]
    private GameObject row;

    private void Awake()
    {
        titleText.text = world.worldName;
        if (world != null)
            CreateWorldUI();
    }

    public void CreateWorldUI()
    {
        foreach (Level level in world.levels)
        {
            // Instance of LevelCardUI prefab
            GameObject lc = Instantiate(levelCard, row.gameObject.transform);

            LevelCardUI lcScript = lc.GetComponent<LevelCardUI>();
            if (lcScript != null)
                lcScript.levelData = level;
        }
    }
}
