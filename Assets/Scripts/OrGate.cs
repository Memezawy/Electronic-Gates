using UnityEngine;

namespace Gates
{
    public class OrGate : BaseGate
    {

        public bool input1;
        public bool input2;
        public bool output;

        private void Update()
        {
            input1 = _inputIndicators[0].connectedWire != null ? _inputIndicators[0].connectedWire.Getstate() : false;
            input2 = _inputIndicators[1].connectedWire != null ? _inputIndicators[1].connectedWire.Getstate() : false;
            output = input1 || input2;
            UpdateIndicators();
        }

        private void UpdateIndicators()
        {
            _inputIndicators[0].state = input1;
            _inputIndicators[1].state = input2;
            _outputIndicator.state = output;
        }
    }
}
