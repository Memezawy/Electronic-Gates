using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireAnchor : MonoBehaviour
{
    public int _anchorIndex;
    private Wire _inWire;
    private Wire _outWire;

    private void Update()
    {
        transform.position = _inWire.GetAnchorPositionAt(_anchorIndex);
        _outWire?.Setstate(_inWire.Getstate());
    }

    public void init(int index, Wire wire)
    {
        _anchorIndex = index;
        _inWire = wire;
    }

    private void OnMouseOver()
    {
        if (Input.touchCount <= 0)
            return;
        
        // TODO: Remove anchor

        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            MakeWire();
        }
    }
    private void OnMouseDrag()
    {
        UpdateWireAnchor(MouseManager.instance.GetPosition());
    }
    private void RemoveAnchor()
    {
        _inWire.RemoveWireAnchorAt(this);
        _outWire.RemoveWire();
        Destroy(gameObject);
    }
    public void UpdateWireAnchor(Vector3 pos)
    {
        transform.position = pos;
        _inWire.MoveAnchorAt(_anchorIndex, transform.position);
    }
    private void MakeWire()
    {
        Wire wire = Instantiate(GameAssets.i.wire, transform.position, Quaternion.identity, _inWire.transform).GetComponent<Wire>();
        wire.Instantiate(transform, _inWire.Getstate());
        _outWire = wire;
    }
}
