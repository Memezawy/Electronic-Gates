using System.Collections;
using UnityEngine;

namespace Gates
{
    public class BaseGate : MonoBehaviour
    {
        [Header("Indicators")]
        [SerializeField] internal Node[] _inputIndicators = new Node[2];
        [SerializeField] internal Node _outputIndicator;
        private void OnMouseDrag()
        {
            transform.position = MouseManager.instance.GetPosition();
        }

        private void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(gameObject);
            }
        }
        private void OnDestroy()
        {
            foreach (var i in _inputIndicators)
            {
                i?.connectedWire?.RemoveWire();
            }
            _outputIndicator.connectedWire?.RemoveWire();
        }
    }
}