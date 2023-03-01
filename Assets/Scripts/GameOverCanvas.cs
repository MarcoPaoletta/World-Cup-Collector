using UnityEngine;
using UnityEngine.UI;

public class GameOverCanvas : MonoBehaviour
{
    [SerializeField] private Player playerScript;

    [Header("Texts")]
    [SerializeField] private Text cupsText;
    [SerializeField] private Text timeText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text bestLevelText;
    [SerializeField] private Text totalCupsText;

    private void Start()
    {
        cupsText.text = "CUPS: " + playerScript.score.ToString();
        SetTimeText();
        levelText.text = "LEVEL: " + TrophiesSpawner.level.ToString();
        SetBestLevel();
        bestLevelText.text = "BEST LEVEL: " + GameManager.bestLevel.ToString();
        totalCupsText.text = "TOTAL CUPS: " + GameManager.cups.ToString();
    }

    private void SetTimeText()
    {
        int minutesPlayed = playerScript.totalSecondsPlayed / 60;
        int secondsPlayed = playerScript.totalSecondsPlayed - 60 * minutesPlayed;
        timeText.text = "TIME: " + minutesPlayed.ToString() + "' " + secondsPlayed.ToString() + "''";
    }

    private void SetBestLevel()
    {
        if(TrophiesSpawner.level > GameManager.bestLevel)
        {
            GameManager.bestLevel = TrophiesSpawner.level;
            SaveManager.SaveGameManagerData();
        }
    }
}