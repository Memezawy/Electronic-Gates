using UnityEngine;

namespace Gates
{
    public class NotGate : MonoBehaviour
    {

        [Header("Input")]

        public bool input;
        public bool Output => !input; // returns the invese of the input.

        [Header("Indicators")]
        [SerializeField] private Indicator _inputIndicator;
        [SerializeField] private Indicator _outputIndicator;

        private void Update()
        {
            _inputIndicator.state = input;
            _outputIndicator.state = Output;
        }
    }
}
