using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireAnchor : MonoBehaviour
{
    public int _anchorIndex;
    private Wire _connectedWire;

    private void Update()
    {
        transform.position = _connectedWire.GetAnchorPositionAt(_anchorIndex);
    }

    public void init(int index, Wire wire)
    {
        _anchorIndex = index;
        _connectedWire = wire;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(1))
        {
            RemoveAnchor();
        }
    }
    private void OnMouseDrag()
    {
        UpdateWireAnchor(MouseManager.instance.GetPosition());
    }
    private void RemoveAnchor()
    {
        _connectedWire.RemoveWireAnchorAt(this);
        Destroy(gameObject);
    }
    public void UpdateWireAnchor(Vector3 pos)
    {
        transform.position = pos;
        _connectedWire.MoveAnchorAt(_anchorIndex, transform.position);
    }
}
