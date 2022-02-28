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
    private List<Wire> _wires = new List<Wire>(); // Output and Input Nodes

    [HideInInspector]
    public Wire connectedWire; // Has to Do with Normal Nodes.

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _powerText = GetComponentInChildren<TMPro.TMP_Text>();
    }

    private void Update()
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
    private void OnMouseOver()
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
            foreach (var w in _wires)
            {
                w?.RemoveWire();
            }
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
            wire.Setstate(state);
        }
        else
        {
            state = wire.Getstate();
        }
        connectedWire = wire;
    }

    public void TriggerNode()
    {
        state = !state;
    }

}
