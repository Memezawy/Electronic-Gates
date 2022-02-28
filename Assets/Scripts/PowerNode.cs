using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PowerNode : Node
    {
        internal override void Awake()
        {
            base.Awake();
            state = isOutput = isPower = true;
        }

        internal override void Update()
        {
            base.Update();
        }
        public override void TriggerNode()
        {
            base.TriggerNode();
            foreach (var w in _wires)
            {
                w?.Setstate(state);
            }
        }

        internal override void OnMouseOver()
        {
            base.OnMouseOver();
            if (Input.GetMouseButtonDown(1))
            {
                foreach (var w in _wires)
                {
                    w.RemoveWire();
                }
                _wires.Clear();
            }
        }
    }
}