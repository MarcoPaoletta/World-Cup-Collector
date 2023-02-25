using System.Collections.Generic;

[System.Serializable] // turn on serialization so that we can turn the data of this script into binary and save it
public class InventoryData
{
    public Dictionary<string, bool> inventory = new Dictionary<string, bool>()
    {
        {"Mate", false},
        {"Empanada", false},
        {"Shovel", false},
    };

    public InventoryData()
    {
        inventory = InventoryManager.inventory;
    }
}