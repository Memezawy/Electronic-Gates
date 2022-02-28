using UnityEngine;
using System.Collections.Generic;

namespace Gates.Nodes
{


    public class Node : MonoBehaviour
    {
        public bool state;
        private SpriteRenderer _spriteRenderer;
        private TMPro.TMP_Text _powerText;
        public static Color OnColor = Color.green;
        public static Color OffColor = Color.red;


        [HideInInspector]
        public Wire connectedWire; // Has to Do with Normal Nodes.

        internal virtual void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _powerText = GetComponentInChildren<TMPro.TMP_Text>();
        }

        internal virtual void Update()
        {
            if (connectedWire != null)
            {
                state = connectedWire.Getstate();
            }
            UpdateVisual();
        }

        protected void UpdateVisual()
        {
            _spriteRenderer.color = state ? OnColor : OffColor;
            _powerText.text = state ? "1" : "0";
        }

        internal virtual void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(1))
            {
                RemoveAWire(connectedWire);
            }
        }

        public virtual void ConnectWire(Wire wire)
        {
            if (connectedWire != null) // Input with a connected wire
            {
                wire.RemoveWire();
                return;
            }
            connectedWire = wire;
        }

        public virtual void RemoveAWire(Wire wire)
        {
            if (wire == connectedWire)
            {
                connectedWire = null;
                wire.RemoveWire();
            }
        }
    }
}