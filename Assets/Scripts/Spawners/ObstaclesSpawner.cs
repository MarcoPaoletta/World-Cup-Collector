using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    [HideInInspector] public Vector3 obstaclePosition;
    [HideInInspector] public string francePlayerState;

    [Header("Obstacles")]
    [SerializeField] private GameObject mud;
    [SerializeField] private GameObject ice;
    [SerializeField] private GameObject francePlayer;

    private int obstaclesAmountToInstantiateWhenCleanedUp = 5;
    private int randomObstacleIndex;
    private int lastRandomObstacleIndex;
    private bool mudAvailable = true;
    private bool iceAvailable;
    private bool francePlayerAvailable;
    private List<GameObject> obstaclesAvailableList = new List<GameObject>();

    private void Start()
    {
        obstaclesAvailableList.Add(mud);
    }

    public void TrySpawnObstacles()
    {
        CheckObstaclesAvailability();
        
        if (TrophiesSpawner.level >= 10)
        {
            if (TrophiesSpawner.level % 3 == 0 || TrophiesSpawner.level == 10)
            {
                DestroyObstacles();
                for (int i = 0; i < obstaclesAmountToInstantiateWhenCleanedUp; i++)
                {
                    SpawnObstacles();
                }
            }
        }
        else if (TrophiesSpawner.level % 2 == 0)
        {
            SpawnObstacles();
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

    private void CheckObstaclesAvailability()
    {
        if (TrophiesSpawner.level == 6)
        {
            iceAvailable = true;
            obstaclesAvailableList.Add(ice);
        }

        if (TrophiesSpawner.level == 12)
        {
            francePlayerAvailable = true;
            obstaclesAvailableList.Add(francePlayer);
        }
    }

    private void SpawnObstacles()
    {
        for(int i = 0; i < 1; i++)
        {
            SetRandomPosition();

            Collider2D[] colliders = Physics2D.OverlapCircleAll(obstaclePosition, .4f);
            if(colliders.Length < 1)
            {
                if (obstaclesAvailableList.Count > 1)
                {
                    do
                    {
                        randomObstacleIndex = Random.Range(0, obstaclesAvailableList.Count);
                    } while (lastRandomObstacleIndex == randomObstacleIndex);
                }
                else
                {
                    randomObstacleIndex = 0; 
                }

                if(randomObstacleIndex == 2 && GameObject.FindGameObjectsWithTag("FrancePlayer").Length == 0)
                {
                    Instantiate(francePlayer, obstaclePosition, Quaternion.identity); 
                    SetFrancePlayerState();
                }
                else if(randomObstacleIndex == 2 && GameObject.FindGameObjectsWithTag("FrancePlayer").Length >= 1)
                {
                    Instantiate(ice, obstaclePosition, Quaternion.identity);
                }
                else
                {
                    Instantiate(obstaclesAvailableList[randomObstacleIndex], obstaclePosition, Quaternion.identity);
                }
            }
            else
            {
                i-= 1;
            }

            lastRandomObstacleIndex = randomObstacleIndex;
        }
    }

    private void SetRandomPosition()
    {
        float randomX = Random.Range(-2f, 2f);
        float randomY = Random.Range(-3.5f, 3.5f);
        obstaclePosition = new Vector3(randomX, randomY, 0);
    }

    private void SetFrancePlayerState()
    {
        francePlayerState = TrophiesSpawner.level >= 15 ? "Walk" : "Idle";
    }
}