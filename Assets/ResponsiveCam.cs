using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponsiveCam : MonoBehaviour
{
    [SerializeField]
    private float _buffer = 5f;
    private Camera _cam;

    private void Awake()
    {
        _cam = GetComponent<Camera>();
    }

    private void Start()
    {
        var (center, size) = CalculateOrthoSize();
        _cam.transform.position = center;
        _cam.orthographicSize = size;
    }

    private (Vector3 center, float size) CalculateOrthoSize()
    {
        var bounds = new Bounds();

        foreach (var col in FindObjectsOfType<Collider2D>())
        {
            bounds.Encapsulate(col.bounds);
        }

        bounds.Expand(_buffer);

        var vertical = bounds.size.x;
        var horizontal = bounds.size.y * _cam.pixelHeight / _cam.pixelWidth;

        var size = Mathf.Max(horizontal, vertical) * 0.5f;
        var center = bounds.center + new Vector3(0, 0, -10f);

        return (center, size);
    }

}
