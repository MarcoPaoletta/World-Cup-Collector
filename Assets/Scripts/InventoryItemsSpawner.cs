using UnityEngine;

public class InventoryItemsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject mate;
    [SerializeField] private GameObject empanada;
    [SerializeField] private GameObject shovel;

    private Vector3 itemPosition;

    private void Start()
    {
        if(SaveManager.LoadInventoryManagerData() != null)
        {
            InventoryManager.LoadData();
            SaveManager.SaveInventoryManagerData();
        }
    }

    public void CheckSpawnInventoryItems()
    {
        SetRandomPosition();

        if(TrophiesSpawner.level == 15 && InventoryManager.inventory["Mate"] == false)
        {
            Instantiate(mate, itemPosition, Quaternion.identity);
        }

        if(TrophiesSpawner.level > 15 && GameObject.FindGameObjectsWithTag("Mate") != null)
        {
            foreach(var mate in GameObject.FindGameObjectsWithTag("Mate"))
            {
                Destroy(mate);
            }
        }

        if(TrophiesSpawner.level == 30 && InventoryManager.inventory["Empanada"] == false)
        {
            Instantiate(empanada, itemPosition, Quaternion.identity);  
        }

        if(TrophiesSpawner.level > 30 && GameObject.FindGameObjectsWithTag("Empanada") != null)
        {
            foreach(var empanada in GameObject.FindGameObjectsWithTag("Empanada"))
            {
                Destroy(empanada);
            }
        }

        if(TrophiesSpawner.level == 46 && InventoryManager.inventory["Shovel"] == false)
        {
            Instantiate(shovel, itemPosition, Quaternion.identity);
        }

        if(TrophiesSpawner.level > 46 && GameObject.FindGameObjectsWithTag("Shovel") != null)
        {
            foreach(var shovel in GameObject.FindGameObjectsWithTag("Shovel"))
            {
                Destroy(shovel);
            }
        }
    }

    private void SetRandomPosition()
    {
        float randomX = Random.Range(-2f, 2f);
        float randomY = Random.Range(-3.5f, 3.5f);
        itemPosition = new Vector3(randomX, randomY, 0);
    }
}