using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public bool state;
    public bool isOutput;
    public bool isPower;
    private SpriteRenderer _spriteRenderer;
    public static Color OnColor = Color.green;
    public static Color OffColor = Color.red;

    [HideInInspector]
    public Wire connectedWire;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _spriteRenderer.color = state ? OnColor : OffColor;
        if (isOutput && connectedWire != null)
        {
            connectedWire.state = state;
        }
        else if (!isOutput && connectedWire != null)
        {
            state = connectedWire.state;
        }

    }
    private void OnMouseDown()
    {
        if (isOutput)
        {
            var wire = Instantiate(GameAssets.i.wire, transform.position, Quaternion.identity, transform).GetComponent<Wire>();
            wire.Instantiate(transform.position, state);
            ConnectWire(wire);
        }
    }

    public void ConnectWire(Wire wire)
    {
        if (connectedWire != null && !isPower)
        {
            wire.RemoveWire();
            return;
        }

        if (isOutput)
        {
            wire.state = state;
        }
        else
        {
            state = wire.state;
        }
        connectedWire = wire;
    }

    public void TriggerNode()
    {
        state = !state;
    }

}
