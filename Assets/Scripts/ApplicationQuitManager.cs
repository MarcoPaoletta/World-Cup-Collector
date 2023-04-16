using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationQuitManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuCanvas;
    [SerializeField] private GameObject blackPanelGamePausedCanvas;
    [SerializeField] private PauseButtonCanvas pauseButtonCanvasScript;

    void OnApplicationFocus(bool focusStatus)
    {
        if(!Player.dead)
        {
            pauseMenuCanvas.SetActive(true);
            blackPanelGamePausedCanvas.SetActive(true);
            Player.gamePaused = true;
        }
        
        pauseButtonCanvasScript.pauseButtonEnabled = true;
    }
}