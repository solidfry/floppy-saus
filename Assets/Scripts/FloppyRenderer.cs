using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FloppyRenderer : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;

    [SerializeField]
    private List<Transform> points;

    void Start()
    {
        Configure();
    }

    void Update()
    {
        DrawLine();
    }

    private void OnDrawGizmos()
    {
        DrawLine();
    }

    void DrawLine()
    {
        Configure();
        lineRenderer.SetPositions(points.Select(p => p.position).ToArray());
    }

    void Configure()
    {
        lineRenderer.positionCount = points.Count;
        lineRenderer.startWidth = 1f;
        lineRenderer.endWidth = 1f;
    }
}
