using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.SimpleLocalization;
using System.Globalization;

public class MenuTranslatorManager : MonoBehaviour
{
    private void Awake()
    {
        LocalizationManager.Read();

        if (PlayerPrefs.HasKey("CurrentLanguage"))
        {
            SetCurrentLanguage();
            return;
        }
        else
        {
            PlayerPrefs.SetString("CurrentLanguage", "Spanish");
            SetCurrentLanguage();
        }
    }

    private void SetCurrentLanguage()
    {
        LocalizationManager.Language = PlayerPrefs.GetString("CurrentLanguage");
    }
}