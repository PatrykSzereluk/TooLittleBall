using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    //[SerializeField]
    //private float maxLengthOfLine = 1f;

    private LineRenderer lineRenderer;
    private Vector3 dragStartPoint;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetStartPoint(Vector3 worldPosition)
    {
        dragStartPoint = worldPosition;
        lineRenderer.SetPosition(0, dragStartPoint);
    }

    public void SetEndPoint(Vector3 worldPositon)
    {
        Vector3 pointOffset = worldPositon - dragStartPoint;
        Vector3 endPoint = transform.position + pointOffset;

        lineRenderer.SetPosition(1, endPoint);
    }

    public void ResetLine()
    {
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, Vector3.zero);
    }

}
