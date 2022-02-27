using UnityEngine;

namespace Gates
{
    public class AndGate : MonoBehaviour
    {

        public bool input1;
        public bool input2;
        public bool output;

        [Header("Indicators")]
        [SerializeField] private Node _inputIndicator1;
        [SerializeField] private Node _inputIndicator2;
        [SerializeField] private Node _outputIndicator;

        private void Update()
        {
            input1 = _inputIndicator1.connectedWire != null ? _inputIndicator1.connectedWire.state : false;
            input2 = _inputIndicator2.connectedWire != null ? _inputIndicator2.connectedWire.state : false;
            output = input1 && input2;
            UpdateIndicators();
        }

        private void OnMouseDrag()
        {
            transform.position = MouseManager.instance.GetPosition();
        }

        private void UpdateIndicators()
        {
            _inputIndicator1.state = input1;
            _inputIndicator2.state = input2;
            _outputIndicator.state = output;
        }
    }
}
