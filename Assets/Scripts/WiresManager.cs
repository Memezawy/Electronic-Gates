using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class WiresManager : MonoBehaviour
{
    public static WiresManager instance { get; private set; }

    public Color onColor;
    public Color offColor;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
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
