using UnityEngine;
using UnityEngine.UI;
using Assets.SimpleLocalization;

public class AnalyticsCanvas : MonoBehaviour
{
    [SerializeField] private Text analyticsTitleText;
    [SerializeField] private Text totalTrophiesText;
    [SerializeField] private Text totalTimeText;
    [SerializeField] private Text matchesPlayedText;

    private string totalTrophiesTranslation;
    private string totalTimeTranslation;
    private string matchesPlayedTranslation;

    private void Start()
    {
        SetTranslations();
        SetTitleText();
        SetTotalTrophiesText();
        SetMatchesPlayedText();
    }

    private void SetTranslations()
    {
        totalTrophiesTranslation = LocalizationManager.Localize("TotalTrophies");
        totalTimeTranslation = LocalizationManager.Localize("TotalTime");
        matchesPlayedTranslation = LocalizationManager.Localize("MatchesPlayed");
    }

    private void SetTitleText()
    {
        analyticsTitleText.text = LocalizationManager.Localize("AnalyticsTitle");
    }

    private void SetTotalTrophiesText()
    {
        totalTrophiesText.text = totalTrophiesTranslation + ":\n" + AnalyticsManager.totalTrophies.ToString();
    }

    private void SetMatchesPlayedText()
    {
        matchesPlayedText.text = matchesPlayedTranslation + ":\n" + AnalyticsManager.matchesPlayed.ToString();
    }

    private void Update()
    {
        SetTotalTimeText();
    }

    private void SetTotalTimeText()
    {
        int hoursPlayed = AnalyticsManager.totalTime / (60 * 60);
        int minutesPlayed = AnalyticsManager.totalTime / 60;
        int secondsPlayed = AnalyticsManager.totalTime - 60 * minutesPlayed;
        totalTimeText.text = "total time:\n" + hoursPlayed + "h " + minutesPlayed + "' " + secondsPlayed + "''";
        totalTimeText.text = totalTimeTranslation + ":\n" + hoursPlayed + "h " + minutesPlayed + "' " + secondsPlayed + "''";
    }
} 