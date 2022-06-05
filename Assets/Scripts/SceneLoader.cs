using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void LoadScene(int sceneToLoad)
    {
        Debug.Log("Load scene " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}
