using Gates.Nodes;
using UnityEngine;
using System.Collections.Generic;

public class Wire : MonoBehaviour
{
    private bool state;
    private LineRenderer _lineRenderer;
    private EdgeCollider2D _edgeColider;
    private Transform _endNode;
    private Transform _startNode;
    public bool Connected { get; private set; }
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _edgeColider = GetComponent<EdgeCollider2D>();
        WiresManager.RemoveWiresEvent += RemoveWire;
    }

    void Update()
    {
        KeepFollowingTheMouse();
        if (Input.GetMouseButtonDown(0) && !Connected)
        {
            AddAnchorPoint(GetAnchorPoint());
        }
        else if (Input.GetMouseButtonUp(0) && !Connected)
        {
            AddAnchorPoint(_lineRenderer.GetPosition(_lineRenderer.positionCount - 1));
        }
        else if ((Input.GetMouseButtonDown(1) && !Connected))
        {
            RemoveWire();
        }
        UpdateEdgeColider();
    }
    public bool Getstate()
    {
        return state;
    }

    public void Setstate(bool value)
    {
        UpdateLineColor();
        state = value;
    }
    private void KeepFollowingTheMouse()
    {
        _lineRenderer.SetPosition(0, _startNode.position);
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
        GameObject _mouseHoverObject = MouseManager.instance.HoverOverGameObject();

        if (!_mouseHoverObject)
        {
            return MouseManager.instance.GetPosition();
        }

        if (_mouseHoverObject.CompareTag("InputNode"))
        {
            _mouseHoverObject.GetComponent<Node>().ConnectWire(this);
            Connected = true;
            _endNode = _mouseHoverObject.transform;
            return _mouseHoverObject.transform.position;
        }
        return MouseManager.instance.GetPosition();
    }

    public void Instantiate(Transform startPos, bool _state)
    {
        Setstate(_state);
        _startNode = startPos;
        _lineRenderer.positionCount = 1;
        _lineRenderer.SetPosition(0, startPos.position);
    }
    public void RemoveWire()
    {
        Setstate(false);
        Destroy(gameObject);
    }
    private void UpdateLineColor()
    {
        if (_lineRenderer == null) return;
        _lineRenderer.startColor = _lineRenderer.endColor = Getstate() ? Color.red : Color.red;
    }

    private void OnDisable()
    {
        WiresManager.RemoveWiresEvent -= RemoveWire;
    }

    private void UpdateEdgeColider()
    {
        _edgeColider.enabled = Connected;

        var offX = -_lineRenderer.GetPosition(0).x;
        var offY = -_lineRenderer.GetPosition(0).y;
        var points = new Vector2[_lineRenderer.positionCount];
        points[0] = Vector2.zero;
        for (int i = 1; i < _lineRenderer.positionCount; i++)
        {
            Debug.Log("Entered");
            Debug.Log(_lineRenderer.GetPosition(i));
            points[i] = new Vector2(offX + _lineRenderer.GetPosition(i).x, offY + _lineRenderer.GetPosition(i).y);
        }
        _edgeColider.points = points;
    }
}
