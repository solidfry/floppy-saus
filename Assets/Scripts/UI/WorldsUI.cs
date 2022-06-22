using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldsUI : MonoBehaviour
{
    public WorldManager worldManager;
    public GameObject worldUIPrefab;

    private void Awake()
    {
        List<World> worlds = worldManager.worlds;

        foreach (World world in worlds)
        {
            Debug.Log(
                "The world instance has formed"
            );
            //! This is fucked, says not instance of object
            GameObject w = Instantiate(worldUIPrefab, this.gameObject.transform);

            if (w)
            {
                WorldUI wUI = w.GetComponent<WorldUI>();
                if (wUI)
                {
                    wUI.world = world;
                    wUI.titleText.text = world.worldName;
                }
            }


        }
    }
}
