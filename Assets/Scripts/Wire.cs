using Gates.Nodes;
using UnityEngine;

public class Wire : MonoBehaviour
{
    private bool state;
    private LineRenderer _lineRenderer;
    private Transform _endNode;
    private Transform _startNode;
    public bool Connected { get; private set; }
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        WiresManager.RemoveWiresEvent += RemoveWire;
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
        _lineRenderer.startColor = _lineRenderer.endColor = Getstate() ? Color.green : Color.red;
    }
}
