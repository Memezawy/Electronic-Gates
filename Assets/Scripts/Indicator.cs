using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public bool state;
    private SpriteRenderer _spriteRenderer;
    public static Color OnColor = Color.green;
    public static Color OffColor = Color.red;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _spriteRenderer.color = state ? OnColor : OffColor;
    }
}
