using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class WiresManager : MonoBehaviour
{
    public static event Action RemoveWiresEvent;

    public void RemoveAllWires()
    {
        RemoveWiresEvent?.Invoke();
    }
}
