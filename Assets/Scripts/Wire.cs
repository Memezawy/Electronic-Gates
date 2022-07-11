using Gates.Nodes;
using UnityEngine;
using System.Collections.Generic;

public class Wire : MonoBehaviour
{
    [SerializeField]
    private bool _enableCollider;
    private bool state;
    private LineRenderer _lineRenderer;
    private EdgeCollider2D _edgeColider;
    private Transform _endNode;
    private Transform _startNode;

    private List<WireAnchor> _wireAnchors = new List<WireAnchor>();
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
        // if there's no fingers on the screen just fuck off.
        if (Input.touches.Length <= 0)
        {
            return;
        }
        else if (Input.GetTouch(0).phase == TouchPhase.Ended && !Connected)
        {
            AddAnchorPoint(GetAnchorPoint());
        }
        else if (Input.GetTouch(0).phase == TouchPhase.Ended && !Connected)
        {
            // add an anchor at the tip of the line
            AddAnchorPoint(_lineRenderer.GetPosition(_lineRenderer.positionCount - 1));
        }

        UpdateEdgeColider();
    }
    public bool Getstate() => state;

    public void Setstate(bool value)
    {
        UpdateLineColor();
        state = value;
    }
    private void KeepFollowingTheMouse()
    {
        // Always Keeps the Tail at the starting Node.
        _lineRenderer.SetPosition(0, _startNode.position);

        // Always keeps the Head at the ending Node.
        if (Connected)
        {
            _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, _endNode.transform.position);
            return;
        }

        // if not hovering over a node it will Follow The cursor.
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, GetAnchorPoint());
    }
    private Vector2 GetAnchorPoint()
    {
        GameObject _mouseHoverObject = MouseManager.instance.HoverOverGameObject();
        // if there's nothing the mouse is hovering over follow the mouse
        if (!_mouseHoverObject)
        {
            Vector3 pos = Input.GetTouch(0).position;
            pos.z = 10;
            return Camera.main.ScreenToWorldPoint(pos);
        }

        if (_mouseHoverObject.CompareTag("InputNode"))
        {
            ConnectWireTo(_mouseHoverObject);
            return _mouseHoverObject.transform.position;
        }
        return MouseManager.instance.GetPosition();
    }

    private void ConnectWireTo(GameObject _gameObject)
    {
        _gameObject.GetComponent<Node>()?.ConnectWire(this);
        _endNode = _gameObject.transform;
        Connected = true;
    }

    private void AddAnchorPoint(Vector3 point)
    {
        // Increases by 1 so there's a point to Follow the mouse.
        _lineRenderer.positionCount += 1;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, point);

        // Instantiates the Point
        if (_lineRenderer.positionCount <= 2) return;
        var wireAnchor = InstantateAnchorPoint(point, _lineRenderer.positionCount - 2); // ?
        ConnectWireTo(wireAnchor);
    }

    private GameObject InstantateAnchorPoint(Vector3 point, int index)
    {
        var _anchorPoint = Instantiate(GameAssets.i.wireAnchor, point, Quaternion.identity, transform).GetComponent<WireAnchor>();
        _anchorPoint.init(index, this);
        _wireAnchors.Add(_anchorPoint);
        return _anchorPoint.gameObject;
    }


    public void Instantiate(Transform startPos, bool _state)
    {
        Setstate(_state);
        _startNode = startPos;
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, startPos.position);
        KeepFollowingTheMouse();
    }
    public void RemoveWire()
    {
        Setstate(false);
        Destroy(gameObject);
    }
    private void UpdateLineColor()
    {
        if (_lineRenderer == null) return;
        _lineRenderer.startColor = _lineRenderer.endColor = Getstate() ?
            WiresManager.instance.onColor : WiresManager.instance.offColor;
    }

    private void OnDisable()
    {
        WiresManager.RemoveWiresEvent -= RemoveWire;
    }

    private void UpdateEdgeColider()
    {
        if (!_enableCollider)
            return;

        _edgeColider.enabled = Connected;
        var offX = -_lineRenderer.GetPosition(0).x;
        var offY = -_lineRenderer.GetPosition(0).y;
        var points = new Vector2[_lineRenderer.positionCount];
        points[0] = Vector2.zero;
        for (int i = 1; i < _lineRenderer.positionCount; i++)
        {
            var pointX = (offX + _lineRenderer.GetPosition(i).x) / transform.root.lossyScale.x * transform.localScale.x;
            var pointY = (offY + _lineRenderer.GetPosition(i).y) / transform.root.lossyScale.y * transform.localScale.y;
            points[i] = new Vector2(pointX, pointY);
        }
        _edgeColider.points = points;
    }


    public void RemoveWireAnchorAt(WireAnchor wireAnchor)
    {

        Vector3[] points = new Vector3[_lineRenderer.positionCount];
        Vector3[] newPoints = new Vector3[_lineRenderer.positionCount - 1];
        _lineRenderer.GetPositions(points);
        for (int i = 0; i < _lineRenderer.positionCount - 1; i++)
        {
            newPoints[i] = i >= wireAnchor._anchorIndex ? points[i + 1] : points[i];
        }
        _lineRenderer.SetPositions(newPoints);
        UpdateWireAnchorsIndex(wireAnchor._anchorIndex);
    }

    private void UpdateWireAnchorsIndex(int index)
    {
        _wireAnchors.RemoveAt(index - 1);
        foreach (var anchor in _wireAnchors)
        {
            if (anchor._anchorIndex > index)
            {
                anchor._anchorIndex--;
            }
        }
    }

    public void MoveAnchorAt(int index, Vector3 newPos)
    {
        _lineRenderer.SetPosition(index, newPos);
    }
    public Vector3 GetAnchorPositionAt(int index)
    {
        return _lineRenderer.GetPosition(index);
    }


}
