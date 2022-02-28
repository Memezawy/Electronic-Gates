using UnityEngine;
using System.Collections.Generic;

public class Node : MonoBehaviour
{
    public bool state;
    public bool isOutput;
    public bool isPower;
    private SpriteRenderer _spriteRenderer;
    private TMPro.TMP_Text _powerText;
    public static Color OnColor = Color.green;
    public static Color OffColor = Color.red;
    internal List<Wire> _wires = new List<Wire>();

    [HideInInspector]
    public Wire connectedWire; // Has to Do with Normal Nodes.

    internal virtual void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _powerText = GetComponentInChildren<TMPro.TMP_Text>();
    }

    internal virtual void Update()
    {
        _spriteRenderer.color = state ? OnColor : OffColor;
        if (isOutput && connectedWire != null)
        {
            connectedWire.Setstate(state);
        }
        else if (!isOutput && connectedWire != null)
        {
            state = connectedWire.Getstate();
        }
        _powerText.text = state ? "1" : "0";

    }
    internal virtual void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isOutput)
        {
            Wire wire = Instantiate(GameAssets.i.wire, transform.position, Quaternion.identity, transform).GetComponent<Wire>();
            wire.Instantiate(transform, state);
            ConnectWire(wire);
            _wires.Add(wire);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            connectedWire?.RemoveWire();
        }
    }

    public virtual void ConnectWire(Wire wire)
    {
        if (connectedWire != null)
        {
            wire.RemoveWire();
            return;
        }

        if (isOutput)
        {
            wire.Setstate(state);
        }
        else
        {
            state = wire.Getstate();
        }
        connectedWire = wire;
    }

    public virtual void TriggerNode()
    {
        state = !state;
    }

}
