using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    [SerializeField] private AudioClip uiSFX;

    public void OnHomeButtonClicked()
    {
        AudioManager.instance.PlaySFX(uiSFX);
        SceneManager.LoadScene("Menu");
    }
}