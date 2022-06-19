using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Adds an edge collider to the player area so the play area is contained.
/// </summary>
public class PlayerAreaCollider : MonoBehaviour
{
    EdgeCollider2D edge;
    List<Vector2> pointsOnEdge = new List<Vector2>();
    SpriteRenderer sprite;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        Vector2 sSize = sprite.size;
        edge = gameObject.AddComponent<EdgeCollider2D>();

        if (edge != null)
        {
            edge = GetComponent<EdgeCollider2D>();
            pointsOnEdge.Add(new Vector2(-0.5f * sSize.x, -0.5f * sSize.y));
            pointsOnEdge.Add(new Vector2(0.5f * sSize.x, -0.5f * sSize.y));
            pointsOnEdge.Add(new Vector2(0.5f * sSize.x, 0.5f * sSize.y));
            pointsOnEdge.Add(new Vector2(-0.5f * sSize.x, 0.5f * sSize.y));
            pointsOnEdge.Add(new Vector2(-0.5f * sSize.x, -0.5f * sSize.y));
            SetPointsOnEdge();
        }
    }

    /// <summary>
    /// This sets all the points from the edge to the points from the list and then sets that list to an array.
    /// </summary>
    void SetPointsOnEdge()
    {
        edge.points = pointsOnEdge.ToArray();
    }

}
