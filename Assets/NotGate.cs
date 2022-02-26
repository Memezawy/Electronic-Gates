using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotGate : MonoBehaviour
{
    public bool input;
    public bool output;

    private void Update()
    {
        output = !input;
    }
}
