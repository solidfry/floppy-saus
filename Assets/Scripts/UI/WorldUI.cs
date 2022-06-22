using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldUI : MonoBehaviour
{
    public World world;
    public TMP_Text titleText;
    [SerializeField]
    private GameObject levelCard;
    [SerializeField]
    private GameObject row;
    private Transform rowTr;

    private void Awake()
    {
        rowTr = row.gameObject.transform;
        titleText.text = world.worldName;
        if (world != null)
            CreateWorldUI();
    }

    public void CreateWorldUI()
    {
        foreach (Level level in world.levels)
        {
            // Instance of LevelCardUI prefab
            if (levelCard)
            {
                GameObject lc = Instantiate(levelCard, rowTr);
                LevelCardUI lcScript = lc.GetComponent<LevelCardUI>();
                lcScript.levelData = level;
                lc.name = "Level" + level.levelID;
                lcScript.AssignValues();
            }
        }
    }
}
