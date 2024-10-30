using UnityEngine;
using UnityEngine.SceneManagement;

public class OnMenuButtonClicked : MonoBehaviour
{
    [SerializeField] private string destinationSceneName;
    [SerializeField] private AudioClip uiSFX;

    public void MenuButtonListener()
    {
        AudioManager.instance.PlaySFX(uiSFX);
        SceneManager.LoadScene(destinationSceneName);
    }
}