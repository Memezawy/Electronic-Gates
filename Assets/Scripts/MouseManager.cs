using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public static MouseManager instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        HoverOverGameObject();
    }


    public Vector2 GetPosition()
    {
        var mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePostion.z = 1;
        return mousePostion;
    }

    public GameObject HoverOverGameObject()
    {
        var _hit = Physics2D.Raycast(GetPosition(), Vector2.zero);
        if (!_hit) return null;
        return _hit.transform.gameObject;
    }
}
