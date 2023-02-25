using UnityEngine;
using UnityEngine.UI;

public class AnalyticsCanvas : MonoBehaviour
{
    [SerializeField] private Text totalTrophiesText;
    [SerializeField] private Text totalTimeText;
    [SerializeField] private Text matchesPlayedText;

    private void Start()
    {
        SetTotalTrophiesText();
        SetMatchesPlayedText();
    }

    private void SetTotalTrophiesText()
    {
        totalTrophiesText.text = "total trophies:\n" + AnalyticsManager.totalTrophies.ToString();
    }

    private void SetMatchesPlayedText()
    {
        matchesPlayedText.text = "matches played:\n" + AnalyticsManager.matchesPlayed.ToString();
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
    }
} 