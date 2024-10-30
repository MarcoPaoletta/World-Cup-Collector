using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSManager : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }
}
