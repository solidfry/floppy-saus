using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Level", menuName = "Levels/Level", order = 1)]
public class Level : ScriptableObject
{
    [Header("Level Information")]
    public int levelID;
    public int sceneID;
    public string levelName;
    public string subTitle;
    public LevelType levelType;
    public string callToAction;
    [Header("Level Description")]
    [TextArea]
    public string description;
    public Sprite image;
    
    public void LoadScene()
    {
        Debug.Log("Attempted to load scene " + sceneID);
        SceneManager.LoadScene(sceneID);
    }
}
