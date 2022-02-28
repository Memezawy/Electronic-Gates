using UnityEngine;

namespace Gates
{
    public class NotGate : BaseGate
    {

        public bool input;
        public bool output; // returns the invese of the input.

        private void Update()
        {
            if (_inputIndicators[0].connectedWire != null)
            {
                input = _inputIndicators[0].connectedWire.Getstate();
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
            _inputIndicators[0].state = input;
            _outputIndicator.state = output;
        }
    }
}
