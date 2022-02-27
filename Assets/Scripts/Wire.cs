using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public bool State;
    private LineRenderer _lineRenderer;
    public bool _connected;
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        KeepFollowingTheMouse();
        if (Input.GetMouseButtonUp(0) && !_connected)
        {
            AddAnchorPoint(GetAnchorPoint());
        }
    }
    private void KeepFollowingTheMouse()
    {
        if (_connected) return;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, MouseManager.instance.GetPosition());
    }
    private void AddAnchorPoint(Vector3 point)
    {
        _lineRenderer.positionCount += 1;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, point);
    }

    private Vector3 GetAnchorPoint()
    {
        var _mouseHoverObject = MouseManager.instance.HoverOverGameObject();

        if (!_mouseHoverObject) return MouseManager.instance.GetPosition();

        if (_mouseHoverObject.CompareTag("Node"))
        {
            _mouseHoverObject.GetComponent<Node>().ConnectWire(this);
            _connected = true;
            return _mouseHoverObject.transform.position;
        }
        return MouseManager.instance.GetPosition();
    }

    public void Instantiate(Vector3 startPos)
    {
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, startPos);
    }
}
