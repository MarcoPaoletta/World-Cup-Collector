using UnityEngine;
using UnityEngine.UI;
using Assets.SimpleLocalization;

public class ScoreTextsCanvas : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text levelText;

    private string scoreTextTranslation;
    private string levelTextTranslation;

    private void Start()
    {
        SetTranslations();
        UpdateScoreText(0);
        UpdateLevelText();
    }

    private void SetTranslations()
    {
        scoreTextTranslation = LocalizationManager.Localize("ScoreTextsCanvas.ScoreText");
        levelTextTranslation = LocalizationManager.Localize("ScoreTextsCanvas.LevelText");
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = scoreTextTranslation + ": " + score;
    }

    public void UpdateLevelText()
    {
        levelText.text = levelTextTranslation + ": " + TrophiesSpawner.level;
    }

    public void Scored()
    {
        animator.SetTrigger("Scored");
    }

    public void LevelCompleted()
    {
        animator.SetTrigger("LevelCompleted");
    }
}