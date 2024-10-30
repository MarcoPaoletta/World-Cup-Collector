using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private GameObject itemAvailable;
    [SerializeField] private GameObject itemNotAvailable;

    private void Start()
    {
        LoadData();
        UpdateItem();
    }

    private void LoadData()
    {
        if(SaveManager.LoadInventoryManagerData() != null)
        {
            InventoryManager.LoadData();
            SaveManager.SaveInventoryManagerData();
        }
    }

    private void UpdateItem()
    {
        if(InventoryManager.inventory[gameObject.tag] == true)
        {
            itemAvailable.SetActive(true);
            itemNotAvailable.SetActive(false);
        }

        if(InventoryManager.inventory[gameObject.tag] == false)
        {
            itemAvailable.SetActive(false);
            itemNotAvailable.SetActive(true);
        }
    }
}