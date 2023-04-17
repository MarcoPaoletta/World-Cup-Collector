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
       // Check if the CurrentLanguage key is set in PlayerPrefs
        if (PlayerPrefs.HasKey("CurrentLanguage"))
        {
            // The CurrentLanguage key is already set, don't change it
            Debug.Log("Current language is already set to " + PlayerPrefs.GetString("CurrentLanguage"));
            return;
        }

        // Get the system language code
        string languageCode = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

        // Check if the language is English or Spanish
        if (languageCode == "en" || languageCode == "es")
        {
            // Get the specific culture info for the language
            CultureInfo culture = CultureInfo.GetCultureInfo(languageCode);

            // Check if the language is a variation of English or Spanish
            if (culture.Name.StartsWith("en") || culture.Name.StartsWith("es"))
            {
                // The current language is English or Spanish or a variation
                Debug.Log("Current language is " + culture.DisplayName);

                // Set the PlayerPrefs value to the language name
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
                // The current language is not a variation of English or Spanish
                Debug.Log("Current language is not a variation of English or Spanish");

                // Set the PlayerPrefs value to English
                PlayerPrefs.SetString("CurrentLanguage", "English");
            }
        }
        else
        {
            // The current language is not English or Spanish
            Debug.Log("Current language is not English or Spanish");

            // Set the PlayerPrefs value to English
            PlayerPrefs.SetString("CurrentLanguage", "English");
        }

        LocalizationManager.Language = PlayerPrefs.GetString("CurrentLanguage");
    }
}