using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public bool state;
    private LineRenderer _lineRenderer;
    private GameObject _endNode;
    public bool Connected { get; private set; }
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        KeepFollowingTheMouse();
        if (Input.GetMouseButtonDown(0) && !Connected)
        {
            AddAnchorPoint(GetAnchorPoint());
        }
        if ((Input.GetMouseButtonDown(1) && !Connected) || Input.GetKeyDown(KeyCode.F))
        {
            RemoveWire();
        }
    }
    private void KeepFollowingTheMouse()
    {
        if (Connected)
        {
            _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, _endNode.transform.position);
            return;
        }
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, GetAnchorPoint());
    }
    private void AddAnchorPoint(Vector3 point)
    {
        _lineRenderer.positionCount += 1;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, point);
    }

    private Vector2 GetAnchorPoint()
    {
        var _mouseHoverObject = MouseManager.instance.HoverOverGameObject();

        if (!_mouseHoverObject) return MouseManager.instance.GetPosition();

        if (_mouseHoverObject.CompareTag("InputNode"))
        {
            _mouseHoverObject.GetComponent<Node>().ConnectWire(this);
            Connected = true;
            _endNode = _mouseHoverObject;
            return _mouseHoverObject.transform.position;
        }
        return MouseManager.instance.GetPosition();
    }

    public void Instantiate(Vector3 startPos, bool _state)
    {
        state = _state;
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, startPos);
    }
    private void OnDestroy()
    {
        state = false;
    }

    public void RemoveWire()
    {
        Destroy(gameObject);
    }
}
