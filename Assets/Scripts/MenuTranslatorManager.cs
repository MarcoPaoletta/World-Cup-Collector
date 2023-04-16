using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.SimpleLocalization;

public class MenuTranslatorManager : MonoBehaviour
{
    private void Awake()
    {
        LocalizationManager.Read();
        LocalizationManager.Language = PlayerPrefs.GetString("CurrentLanguage", "English");
    }
}