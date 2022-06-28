using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Level", menuName = "Levels/Level", order = 1)]
public class Level : ScriptableObject
{
    [Header("Level Information")]
    public int levelID;
    public int sceneID;
    public LevelType levelType;
    public string levelName;
    [ReadOnly]
    [SerializeField]
    public string subTitle;
    public string callToAction;
    [Space(40)]
    public int[] rankRequirements = new int[3];
    [Space(40)]
    [Header("Level Description")]
    [TextArea]
    public string description;
    public Sprite image;
    [Space(40)]
    [Header("Player progress")] 
    public float playerCompletedTime;
    [ReadOnly]
    public Rank playerRank;
    [SerializeField]
    public bool levelComplete = false;

    private void Awake()
    {
        levelComplete = false;
        DetermineLevelComplete();
    }

    private void OnValidate()
    {
        SetSubTitle();
        SetPlayerRank(DeterminePlayerRank());
        DetermineLevelComplete();
    }

    private void OnEnable()
    {
        SetSubTitle();
        SetPlayerRank(DeterminePlayerRank());
    }

    public void LoadScene()
    {
        Debug.Log("Attempted to load scene " + sceneID);
        SceneManager.LoadScene(sceneID);
    }

    private Rank DeterminePlayerRank()
    {
        //todo casting to int here from float might cause issues
        int t = (int)playerCompletedTime;
        if (t > rankRequirements[0] || t == 0)
        {
            return Rank.None;
        } 
        if (t > 0 && t <= rankRequirements.Min())
        {
            return Rank.Three;
        }
        if (t <= rankRequirements[1] && t > rankRequirements.Min())
        {
            return Rank.Two;
        }
        return Rank.One;
    }
    
    private void SetPlayerRank(Rank newRank)
    {
        playerRank = newRank;
    }

    public void DetermineAndSetPlayerRank()
    {
        SetPlayerRank(DeterminePlayerRank());
    }

    public void DetermineLevelComplete()
    {
        if (playerCompletedTime > 0 && playerCompletedTime <= rankRequirements.Max() )
            levelComplete = true;
    }

    void SetSubTitle()
    {
        subTitle = "Level " + levelID;
    }
}
