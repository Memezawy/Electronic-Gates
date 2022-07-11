using System.Collections.Generic;
using UnityEngine;

namespace Gates.Nodes
{
    public class OutputNode : Node
    {
        protected List<Wire> _wires = new List<Wire>();
        internal override void Awake()
        {
            base.Awake();
        }

        internal override void Update()
        {
            UpdateVisual();
            UpdateAllConnectedWires();
        }

        internal void UpdateAllConnectedWires()
        {
            foreach (var w in _wires)
            {
                if (w == null) continue;
                w?.Setstate(state);
            }
        }

        internal override void OnMouseOver()
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Wire wire = Instantiate(GameAssets.i.wire, transform.position, Quaternion.identity, transform).GetComponent<Wire>();
                wire.Instantiate(transform, state);
                _wires.Add(wire);
            }
            if (Input.GetMouseButtonDown(1))
            {
                // Removes all out wires then clears the list.
                foreach (var w in _wires)
                {
                    if (w == null) continue;
                    w?.RemoveWire();
                }
                _wires.Clear();
            }
        }
    }
}