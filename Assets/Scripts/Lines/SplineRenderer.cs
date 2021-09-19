using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(BezierSpline))]
public class SplineRenderer : MonoBehaviour
{
    private BezierSpline spline;
    private LineRenderer lineRenderer;

    [SerializeField, Tooltip("Number of points")] int resolution;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        spline = GetComponent<BezierSpline>();
    }

    private void SetupRenderer()
    {
        float stepSize = 1f / (resolution-1);
        lineRenderer.loop = spline.Loop;
        Vector3[] points = new Vector3[resolution];
        float currentValue = 0.0f;
        for(int i = 0; i < resolution; i++)
        {
            points[i] = spline.GetPoint(currentValue);
            currentValue += stepSize;
        }
        lineRenderer.positionCount = resolution;
        lineRenderer.SetPositions(points);
    }

#if UNITY_EDITOR
    public void Setup()
    {
        lineRenderer = GetComponent<LineRenderer>();
        spline = GetComponent<BezierSpline>();
        SetupRenderer();
        UnityEditor.EditorUtility.SetDirty(lineRenderer);
    }

    public void OnValidate()
    {
        Setup();
    }
#endif
}
