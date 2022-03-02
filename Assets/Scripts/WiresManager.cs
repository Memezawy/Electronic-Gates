using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class WiresManager : MonoBehaviour
{
    public static event Action RemoveWiresEvent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RemoveAllWires();
        }
    }

    public void RemoveAllWires()
    {
        RemoveWiresEvent?.Invoke();
    }
}
