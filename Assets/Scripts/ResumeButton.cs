using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuCanvas;
    [SerializeField] private AudioClip uiSFX;

    public void OnResumeButtonPressed()
    {
        pauseMenuCanvas.SetActive(false);
        Player.gamePaused = false;
        AudioManager.instance.PlaySFX(uiSFX);
    }
}