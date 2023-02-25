using UnityEngine;
using UnityEngine.UI;

public class ScoreTextsCanvas : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text levelText;

    private void Start()
    {
        UpdateLevelText();
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = "CUPS: " + score;
    }

    public void UpdateLevelText()
    {
        levelText.text = "LEVEL: " + TrophiesSpawner.level;
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