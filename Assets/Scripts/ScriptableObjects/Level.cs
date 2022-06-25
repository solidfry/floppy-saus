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
    public int playerCompletedTime;
    public Rank playerRank;

    private void OnEnable()
    {
        subTitle = "Level " + levelID;
        SetPlayerRank(DeterminePlayerRank());
    }

    public void LoadScene()
    {
        Debug.Log("Attempted to load scene " + sceneID);
        SceneManager.LoadScene(sceneID);
    }

    private Rank DeterminePlayerRank()
    {
        // 0 is none
        return Rank.None;
    }
    
    private void SetPlayerRank(Rank newRank)
    {
        playerRank = newRank;
    } 
}
