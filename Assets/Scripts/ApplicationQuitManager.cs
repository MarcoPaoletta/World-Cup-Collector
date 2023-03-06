using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationQuitManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuCanvas;

    void OnApplicationFocus(bool focusStatus)
    {
        pauseMenuCanvas.SetActive(true);
        Player.gamePaused = true;
    }
}