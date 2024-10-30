using UnityEngine;

public class SocialMediaButton : MonoBehaviour
{
    [SerializeField] private string socialMediaURL;

    public void OnSocialMediaButtonClicked()
    {
        Application.OpenURL(socialMediaURL);
    }
}