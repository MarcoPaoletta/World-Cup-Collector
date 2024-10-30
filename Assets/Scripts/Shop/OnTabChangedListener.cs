using UnityEngine;

public class OnTabChangedListener : MonoBehaviour
{
    [SerializeField] private AudioClip uiSFX;

    public void OnTabChanged()
    {
        AudioManager.instance.PlaySFX(uiSFX);
    }   
}