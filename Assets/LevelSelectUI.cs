using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectUI : MonoBehaviour
{
    [SerializeField]
    Level levelData;

    private string levelName;
    private string description;
    private int sceneID;

    private void Awake()
    {
        levelName = levelData.levelName;
        description = levelData.description;
    }
}
