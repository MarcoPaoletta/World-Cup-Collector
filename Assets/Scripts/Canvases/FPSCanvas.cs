using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCanvas : MonoBehaviour
{
    [SerializeField] private Text fpsText;

    private void Update()
    {
        fpsText.text = "FPS: " + (1 / Time.deltaTime).ToString();
    }
}
