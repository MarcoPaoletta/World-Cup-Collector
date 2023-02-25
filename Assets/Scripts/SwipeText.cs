using UnityEngine;

public class SwipeText : MonoBehaviour
{
    [SerializeField] private GameObject trophy;

    [Header("Scripts")]
    [SerializeField] private Player playerScript;
    [SerializeField] private TrophiesSpawner trophiesSpawnerScript;

    public void OnSwipeTextAnimationFinished()
    {
        playerScript.canMove = true;
        playerScript.canAddPlayingSeconds = true;
        playerScript.SetPlayedSeconds();
        trophiesSpawnerScript.SpawnTrophies();
        Destroy(transform.gameObject.GetComponentInParent<Canvas>().gameObject);
    }
}