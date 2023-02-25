using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static Dictionary<string, bool> inventory = new Dictionary<string, bool>()
    {
        {"Mate", false},
        {"Empanada", false},
        {"Shovel", false},
    };

    public static InventoryManager instance;

    private void Awake()
    {
        if(InventoryManager.instance == null)
        {
            InventoryManager.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void LoadData()
    {
        InventoryData shopManagerData = SaveManager.LoadInventoryManagerData();
        inventory = shopManagerData.inventory;
    }
}