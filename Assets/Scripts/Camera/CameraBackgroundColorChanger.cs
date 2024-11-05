using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackgroundColorChanger : MonoBehaviour
{
    [SerializeField] private Color cameraBackgroundColor;

    private void Start()
    {
        if(Application.platform == RuntimePlatform.WebGLPlayer)
        {
            Camera.main.backgroundColor = Color.white;
        }
        else
        {
            Camera.main.backgroundColor = cameraBackgroundColor;
        }
    }
}