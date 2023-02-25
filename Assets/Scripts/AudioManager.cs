using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource sfx;

    public static AudioManager instance;

    private void Awake()
    {
        if(AudioManager.instance == null)
        {
            AudioManager.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        music.volume = PlayerPrefs.GetString("MusicStatus", "On") == "On" ? 1 : 0;
        sfx.volume = PlayerPrefs.GetString("SFXStatus", "On") == "On" ? 1 : 0;
    }

    public void PlaySFX(AudioClip sfxClip)
    {
        sfx.PlayOneShot(sfxClip);
    }
}