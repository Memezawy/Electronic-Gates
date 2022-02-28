using System.Collections.Generic;
using UnityEngine;

namespace Gates.Nodes
{
    public class PowerNode : OutputNode
    {
        internal override void Awake()
        {
            base.Awake();
            state = true;
        }

        internal override void Update()
        {
            UpdateAllConnectedWires();
            UpdateVisual();
        }
        public virtual void TriggerNode()
        {
            state = !state;
        }

        internal override void OnMouseOver()
        {
            base.OnMouseOver();
        }
    }
}