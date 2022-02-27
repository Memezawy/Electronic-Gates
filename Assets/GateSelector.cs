using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSelector : MonoBehaviour
{
    public void SelectNotGate()
    {
        Instantiate(GameAssets.i.notGate, MouseManager.instance.GetPosition(), Quaternion.identity);
    }
    public void SelectAndGate()
    {
        Instantiate(GameAssets.i.andGate, MouseManager.instance.GetPosition(), Quaternion.identity);
    }
    public void SelectOrGate()
    {
        Instantiate(GameAssets.i.orGate, MouseManager.instance.GetPosition(), Quaternion.identity);
    }
}
