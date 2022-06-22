using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldsUI : MonoBehaviour
{
    public WorldManager worldManager;
    public GameObject worldUIPrefab;
    private Transform parentTransform;

    private void Awake()
    {
        parentTransform = this.gameObject.transform;
        List<World> worlds = worldManager.worlds;

        foreach (World world in worlds)
        {
            Debug.Log(
                "The world instance has formed"
            );

            GameObject w = Instantiate(worldUIPrefab, parentTransform);

            if (w)
            {
                w.name = world.worldName;
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
