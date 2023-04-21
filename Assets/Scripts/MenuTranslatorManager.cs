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
            return;
        }

        string languageCode = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

        if (languageCode == "en" || languageCode == "es")
        {
            CultureInfo culture = CultureInfo.GetCultureInfo(languageCode);

            if (culture.Name.StartsWith("en") || culture.Name.StartsWith("es"))
            {
                if (languageCode == "en")
                {
                    PlayerPrefs.SetString("CurrentLanguage", "English");
                }
                else if (languageCode == "es")
                {
                    PlayerPrefs.SetString("CurrentLanguage", "Spanish");
                }
            }
            else
            {
                PlayerPrefs.SetString("CurrentLanguage", "English");
            }
        }
        else
        {
            PlayerPrefs.SetString("CurrentLanguage", "English");
        }

        LocalizationManager.Language = PlayerPrefs.GetString("CurrentLanguage");
    }
}