using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    [HideInInspector] public Vector3 obstaclePosition;
    [HideInInspector] public string francePlayerState;

    [Header("Obstacles")]
    [SerializeField] private GameObject mud;
    [SerializeField] private GameObject ice;
    [SerializeField] private GameObject francePlayer;

    private int obstaclesAmountToInstantiate;
    private bool mudAvailable = true;
    private bool iceAvailable;
    private bool francePlayerAvailable;

    public void SpawnObstacles()
    {
        if (TrophiesSpawner.level % 3 != 0)
        {
            return;
        }

        DestroyObstacles();
        CheckObstaclesAvailability();
        SetObstaclesAmountToInstantiate();

        for(int i = 0; i < obstaclesAmountToInstantiate; i++)
        {
            SetRandomPosition();
            Collider2D[] colliders = Physics2D.OverlapCircleAll(obstaclePosition, .4f);
            
            if(colliders.Length < 1)
            {
                if(obstaclesAmountToInstantiate == 1)
                {
                    Instantiate(mud, obstaclePosition, Quaternion.identity);
                }

                if(obstaclesAmountToInstantiate != 1)
                {
                    int randomObstacle = Random.Range(1, obstaclesAmountToInstantiate + 1);

                    if(randomObstacle == 1)
                    {
                        Instantiate(mud, obstaclePosition, Quaternion.identity);
                    }

                    if(randomObstacle == 2)
                    {
                        Instantiate(ice, obstaclePosition, Quaternion.identity);
                    }

                    if(randomObstacle == 3 && GameObject.FindGameObjectsWithTag("FrancePlayer").Length == 0)
                    {
                        Instantiate(francePlayer, obstaclePosition, Quaternion.identity); 
                        SetFrancePlayerState();
                    }
                    else if(randomObstacle == 3 && GameObject.FindGameObjectsWithTag("FrancePlayer").Length >= 1)
                    {
                        Instantiate(ice, obstaclePosition, Quaternion.identity);
                    }
                }
            }
            else
            {
                i-= 1;
            }
        }
    }

    public void DestroyObstacles()
    {
        GameObject[] muds = GameObject.FindGameObjectsWithTag("Mud");
        GameObject[] ices = GameObject.FindGameObjectsWithTag("Ice");
        GameObject[] francePlayers = GameObject.FindGameObjectsWithTag("FrancePlayer");
        
        foreach(var mud in muds)
        {
            Destroy(mud);
        }

        foreach(var ice in ices)
        {
            Destroy(ice);
        }

        foreach(var francePlayer in francePlayers)
        {
            Destroy(francePlayer);
        }
    }

    private void SetRandomPosition()
    {
        float randomX = Random.Range(-2f, 2f);
        float randomY = Random.Range(-3.5f, 3.5f);
        obstaclePosition = new Vector3(randomX, randomY, 0);
    }

    private void CheckObstaclesAvailability()
    {
        iceAvailable = TrophiesSpawner.level >= 10;
        francePlayerAvailable = TrophiesSpawner.level >= 15;
    }

    private void SetObstaclesAmountToInstantiate()
    {
        obstaclesAmountToInstantiate = mudAvailable ? 1 : obstaclesAmountToInstantiate;
        obstaclesAmountToInstantiate = iceAvailable ? 2 : obstaclesAmountToInstantiate;
        obstaclesAmountToInstantiate = francePlayerAvailable ? 3 : obstaclesAmountToInstantiate;
    }

    private void SetFrancePlayerState()
    {
        francePlayerState = TrophiesSpawner.level >= 20 ? "Walk" : "Idle";
    }
}