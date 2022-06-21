using UnityEngine;
using UnityEngine.SceneManagement;

public enum Worlds
{
    WorldOne,
    WorldTwo,
}

[CreateAssetMenu(fileName = "Level", menuName = "Levels/Level", order = 1)]
public class Level : ScriptableObject
{
    [Header("Level Information")]
    public string levelName;
    public string subTitle;
    public string description;
    public int sceneID;
    public string callToAction;
    public Sprite image;
    public Worlds world;

    public void LoadScene()
    {
        Debug.Log("Attempted to load scene " + sceneID);
        SceneManager.LoadScene(sceneID);
    }
}
