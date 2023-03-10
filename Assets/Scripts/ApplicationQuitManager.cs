using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationQuitManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuCanvas;
    [SerializeField] private PauseButtonCanvas pauseButtonCanvasScript;

    void OnApplicationFocus(bool focusStatus)
    {
        pauseMenuCanvas.SetActive(true);
        Player.gamePaused = true;
        pauseButtonCanvasScript.pauseButtonEnabled = true;
    }
}