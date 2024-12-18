using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.SimpleLocalization;
using UnityEngine.SceneManagement;

public class LanguageChanger : MonoBehaviour
{
    [SerializeField] private AudioClip uiSFX;

    [Header("Off / On button sprites")]
    [SerializeField] private Sprite offButtonSprite;
    [SerializeField] private Sprite onButtonSprite;

    [Header("ButtonImages")]
    [SerializeField] private Image spanishButtonImage;
    [SerializeField] private Image englishButtonImage;

    private string currentLanguage;

    private void Start()
    {
        LoadCurrentLanguage();
    }

    private void LoadCurrentLanguage()
    {
        currentLanguage = PlayerPrefs.GetString("CurrentLanguage", "Spanish");

        if(currentLanguage == "English")
        {
            OnEnglishButtonPressed();
        }

        if(currentLanguage == "Spanish")
        {
            OnSpanishButtonPressed();
        }
    }

    public void OnSpanishButtonPressed()
    {
        OnChangeLanguageButtonPressed("Spanish", englishButtonImage, spanishButtonImage);
    }

    public void OnEnglishButtonPressed()
    {
        OnChangeLanguageButtonPressed("English", spanishButtonImage, englishButtonImage);
    }

    private void OnChangeLanguageButtonPressed(string language, Image buttonImageToTurnOff, Image buttonImageToTurnOn)
    {
        currentLanguage = language;
        PlayerPrefs.SetString("CurrentLanguage", currentLanguage);
        buttonImageToTurnOff.sprite = offButtonSprite;
        buttonImageToTurnOn.sprite = onButtonSprite;
        LocalizationManager.Language = PlayerPrefs.GetString("CurrentLanguage", "English");
        UpdateSettingsButtonTexts();
    }

    private void UpdateSettingsButtonTexts()
    {
        foreach (var updateSettingButtonScript in GameObject.FindObjectsOfType<SettingsButton>())
        {
            updateSettingButtonScript.UpdateSettingsButtonTexts();
        }
    }

    public void PlayUiSFX()
    {
        AudioManager.instance.PlaySFX(uiSFX);
    }
}