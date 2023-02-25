using UnityEngine;

public class AnalyticsManager : MonoBehaviour
{
    public static int totalTrophies;
    public static int totalTime;
    public static int matchesPlayed;

    public static AnalyticsManager instance;

    private void Awake()
    {
        if(AnalyticsManager.instance == null)
        {
            AnalyticsManager.instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData();
            InvokeRepeating("IncreaseTotalTime", 1, 1);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadData()
    {
        totalTrophies = PlayerPrefs.GetInt("TotalTrophies");
        totalTime = PlayerPrefs.GetInt("TotalTime");
        matchesPlayed = PlayerPrefs.GetInt("MatchesPlayed");
    }

    public static void IncreaseTotalTrophies(int amount)
    {
        totalTrophies += amount;
        PlayerPrefs.SetInt("TotalTrophies", totalTrophies);
    }

    private void IncreaseTotalTime()
    {
        totalTime += 1;
        PlayerPrefs.SetInt("TotalTime", totalTime);
    }

    public static void IncreaseMatchesPlayed()
    {
        matchesPlayed += 1;
        PlayerPrefs.SetInt("MatchesPlayed", matchesPlayed);
    }
}