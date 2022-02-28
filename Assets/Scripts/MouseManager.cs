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

    public Vector2 GetPosition()
    {
        var mousePostion = Input.mousePosition;
        mousePostion.z = 10f;
        mousePostion = Camera.main.ScreenToWorldPoint(mousePostion);
        mousePostion.z = 0f;
        return mousePostion;
    }

    public GameObject HoverOverGameObject()
    {
        var _hit = Physics2D.Raycast(GetPosition(), Vector2.zero);
        if (!_hit) return null;
        return _hit.transform.gameObject;
    }
}
