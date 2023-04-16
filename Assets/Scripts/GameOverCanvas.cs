using UnityEngine;
using UnityEngine.UI;
using Assets.SimpleLocalization;

public class GameOverCanvas : MonoBehaviour
{
    [SerializeField] private Player playerScript;

    [Header("Texts")]
    [SerializeField] private Text cupsText;
    [SerializeField] private Text timeText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text bestLevelText;
    [SerializeField] private Text totalCupsText;

    private string cupsTextTranslation;
    private string timeTextTranslation;
    private string levelTextTranslation;
    private string bestLevelTextTranslation;
    private string totalCupsTextTranslation;

    private void Start()
    {
        SetTranslations();
        SetTexts();
    }

    private void SetTranslations()
    {
        cupsTextTranslation = LocalizationManager.Localize("GameOverCanvas.CupsText");
        timeTextTranslation = LocalizationManager.Localize("GameOverCanvas.TimeText");
        levelTextTranslation = LocalizationManager.Localize("GameOverCanvas.LevelText");
        bestLevelTextTranslation = LocalizationManager.Localize("GameOverCanvas.BestLevelText");
        totalCupsTextTranslation = LocalizationManager.Localize("GameOverCanvas.TotalCupsText");
    }

    private void SetTexts()
    {
        cupsText.text = cupsTextTranslation + ": " + playerScript.score.ToString();
        SetTimeText();
        levelText.text = levelTextTranslation + ": " + TrophiesSpawner.level.ToString();
        SetBestLevel();
        bestLevelText.text = bestLevelTextTranslation + ": " + GameManager.bestLevel.ToString();
        totalCupsText.text = totalCupsTextTranslation + ": " + GameManager.cups.ToString();
    }

    private void SetTimeText()
    {
        int minutesPlayed = playerScript.totalSecondsPlayed / 60;
        int secondsPlayed = playerScript.totalSecondsPlayed - 60 * minutesPlayed;
        timeText.text = timeTextTranslation + ": " + minutesPlayed.ToString() + "' " + secondsPlayed.ToString() + "''";
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