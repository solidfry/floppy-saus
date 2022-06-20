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
    public string description;
    public int sceneID;
    public Sprite image;
    public Worlds world;

    void LoadScene()
    {
        SceneManager.LoadScene(sceneID);
    }
}
