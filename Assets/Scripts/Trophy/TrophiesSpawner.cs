using UnityEngine;

public class TrophiesSpawner : MonoBehaviour
{
    public static int level;

    [SerializeField] private GameObject trophy;

    private Vector3 trophyPosition;
    private int trophiesAmountToInstantiate;

    private void Awake()
    {
        level = 1;
    }

    public void SpawnTrophies()
    {
        if(level >= 24)
        {
            trophiesAmountToInstantiate = 24;
        }
        else
        {
            trophiesAmountToInstantiate = level;
        }

        for (int i = 0; i < trophiesAmountToInstantiate; i++)
        {
            SetTrophyPosition();
            Collider2D[] colliders = Physics2D.OverlapCircleAll(trophyPosition, .2f);
            
            if(colliders.Length < 1)
            {
                Instantiate(trophy, trophyPosition, Quaternion.identity);
            }
            else
            {
                i-= 1;
            }
        }
    }

    private void SetTrophyPosition()
    {
        float randomX = Random.Range(-2f, 2f);
        float randomY = Random.Range(-3.5f, 3.5f);
        trophyPosition = new Vector3(randomX, randomY, 0);
    }
}