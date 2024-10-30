using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonCanvas : MonoBehaviour
{
    [HideInInspector] public bool pauseButtonEnabled = true;

    [SerializeField] private GameObject pauseMenuCanvas;
    [SerializeField] private GameObject blackPanelGamePausedCanvas;
    [SerializeField] private AudioClip uiSFX;

    public void OnPauseButtonPressed()
    {
        if(pauseButtonEnabled && !Player.dead && !Player.frozen)
        {
            pauseMenuCanvas.SetActive(true);
            blackPanelGamePausedCanvas.SetActive(true);
            Player.gamePaused = true;
            AudioManager.instance.PlaySFX(uiSFX);
        }
    }
}