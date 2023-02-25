using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Image buttonImage;
    [SerializeField] private Text buttonText;

    [Header("ButtonImages")]
    [SerializeField] private Sprite offButtonSprite;
    [SerializeField] private Sprite onButtonSprite;

    private void Start()
    {
        if(PlayerPrefs.GetString(gameObject.name.Replace("Button", "") + "Status") == "On")
        {
            buttonImage.sprite = onButtonSprite;
            buttonText.text = "on";  
        }
        else if(PlayerPrefs.GetString(gameObject.name.Replace("Button", "") + "Status") == "Off")
        {
            buttonImage.sprite = offButtonSprite;
            buttonText.text = "off";
        }
    }

    public void OnSettingsButtonPressed()
    {
        if(buttonText.text == "off")
        {
            buttonImage.sprite = onButtonSprite;
            buttonText.text = "on";
            PlayerPrefs.SetString(gameObject.name.Replace("Button", "") + "Status", "On");
        }

        else if(buttonText.text == "on")
        {
            buttonImage.sprite = offButtonSprite;
            buttonText.text = "off";
            PlayerPrefs.SetString(gameObject.name.Replace("Button", "") + "Status", "Off");
        }
    }
}