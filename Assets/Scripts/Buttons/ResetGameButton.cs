using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGameButton : MonoBehaviour
{
    [SerializeField] private AudioClip uiSFX;

    public void OnResetGameButtonPressed()
    {
        AudioManager.instance.PlaySFX(uiSFX);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}