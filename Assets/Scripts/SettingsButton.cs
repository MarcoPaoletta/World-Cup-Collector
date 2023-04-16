using UnityEngine;
using UnityEngine.UI;
using Assets.SimpleLocalization;
using UnityEngine.SceneManagement;

public class SettingsButton : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Image buttonImage;
    [SerializeField] private Text buttonText;

    [Header("ButtonImages")]
    [SerializeField] private Sprite offButtonSprite;
    [SerializeField] private Sprite onButtonSprite;

    private string onText;
    private string offText;

    private void Start()
    {
        AssignVariables();
        LoadButtonsData();
    }

    private void AssignVariables()
    {
        onText = LocalizationManager.Localize("OnText");
        offText = LocalizationManager.Localize("OffText");
    }

    private void LoadButtonsData()
    {
        if(PlayerPrefs.GetString(gameObject.name.Replace("Button", "") + "Status") == "On")
        {
            buttonImage.sprite = onButtonSprite;
            buttonText.text = onText;  
        }
        else if(PlayerPrefs.GetString(gameObject.name.Replace("Button", "") + "Status") == "Off")
        {
            buttonImage.sprite = offButtonSprite;
            buttonText.text = offText;
        }
    }

    public void OnSettingsButtonPressed()
    {
        
        if(buttonText.text == offText)
        {
            buttonImage.sprite = onButtonSprite;
            buttonText.text = onText;
            PlayerPrefs.SetString(gameObject.name.Replace("Button", "") + "Status", "On");
        }

        else if(buttonText.text == onText)
        {
            buttonImage.sprite = offButtonSprite;
            buttonText.text = offText;
            PlayerPrefs.SetString(gameObject.name.Replace("Button", "") + "Status", "Off");
        }
    }
}