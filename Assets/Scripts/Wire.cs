using Gates.Nodes;
using UnityEngine;
using System.Collections.Generic;

public class Wire : MonoBehaviour
{
    private bool state;
    private LineRenderer _lineRenderer;
    private EdgeCollider2D _edgeCollider;
    private Transform _endNode;
    private Transform _startNode;
    public bool Connected { get; private set; }
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _edgeCollider = GetComponent<EdgeCollider2D>();
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
        else if ((Input.GetMouseButtonDown(1) && !Connected) || Input.GetKeyDown(KeyCode.F))
        {
            RemoveWire();
        }
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
        _lineRenderer.startColor = _lineRenderer.endColor = Getstate() ? Color.green : Color.red;
    }

    private void OnDisable()
    {
        WiresManager.RemoveWiresEvent -= RemoveWire;
    }

    //private void UpdateCollider()
    //{
    //    var anchorPoints = new Vector3[_lineRenderer.positionCount];
    //    _lineRenderer.GetPositions(anchorPoints);
    //    var anchorPointsList = new List<Vector2>();
    //    anchorPointsList.Capacity = _lineRenderer.positionCount;
    //    for (int i = _lineRenderer.positionCount - 1; i >= 0; i--)
    //    {
    //        var v1 = _lineRenderer.GetPosition(i - 1);
    //        var v2 = _lineRenderer.GetPosition(i);
    //        Debug.Log($"V1 = {v1}, V2 = {v2}, Lr Count = {_lineRenderer.positionCount}, I = {i}");

    //        var points = v1.x - v2.x;
    //    }
    //    _edgeCollider.SetPoints(anchorPointsList);
    //}
}
