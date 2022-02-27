using UnityEngine;

namespace Gates
{
    public class NotGate : MonoBehaviour
    {

        public bool input;
        public bool output; // returns the invese of the input.

        [Header("Indicators")]
        [SerializeField] private Node _inputIndicator;
        [SerializeField] private Node _outputIndicator;

        private void Update()
        {
            if (_inputIndicator.connectedWire != null)
            {
                input = _inputIndicator.connectedWire.State;
                output = !input;
            }
            else
            {
                input = false;
                output = false;
            }
            UpdateIndicators();
        }

        private void UpdateIndicators()
        {
            _inputIndicator.state = input;
            _outputIndicator.state = output;
        }
    }
}
