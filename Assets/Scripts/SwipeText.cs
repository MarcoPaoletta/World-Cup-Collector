using UnityEngine;
using Assets.SimpleLocalization;
using UnityEngine.UI;

public class SwipeText : MonoBehaviour
{
    [SerializeField] private GameObject trophy;
    [SerializeField] private Text swipeText;

    [Header("Scripts")]
    [SerializeField] private Player playerScript;
    [SerializeField] private TrophiesSpawner trophiesSpawnerScript;

    private string swipeTextTranslation;

    private void Start()
    {
        SetTranslation();
    }

    private void SetTranslation()
    {
        swipeTextTranslation = LocalizationManager.Localize("SwipeText");
        swipeText.text = swipeTextTranslation;
    }

    public void OnSwipeTextAnimationFinished()
    {
        playerScript.canMove = true;
        playerScript.canAddPlayingSeconds = true;
        playerScript.SetPlayedSeconds();
        trophiesSpawnerScript.SpawnTrophies();
        Destroy(transform.gameObject.GetComponentInParent<Canvas>().gameObject);
    }
}