using UnityEngine;

public class Boundaries : MonoBehaviour
{
    public static Boundaries instance = null;
    public static Vector2 vBounds = new Vector2(-4f, 4f);
    public static Vector2 hBounds = new Vector2(-8f, 8f);

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
}
