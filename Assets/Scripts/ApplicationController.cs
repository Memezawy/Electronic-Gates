using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationController : MonoBehaviour
{
    private void Awake()
    {
        QualitySettings.vSyncCount = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
