using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSelector : MonoBehaviour
{
    private Vector2 _spawnPosision = Vector2.zero;

    public void SelectNotGate()
    {
        Instantiate(GameAssets.i.notGate, _spawnPosision, Quaternion.identity);
    }
    public void SelectAndGate()
    {
        Instantiate(GameAssets.i.andGate, _spawnPosision, Quaternion.identity);
    }
    public void SelectOrGate()
    {
        Instantiate(GameAssets.i.orGate, _spawnPosision, Quaternion.identity);
    }
}
