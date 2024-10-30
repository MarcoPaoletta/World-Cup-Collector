using UnityEngine;
using System.IO; // manage files
using System.Runtime.Serialization.Formatters.Binary; // use binary formatter

public static class SaveManager
{
    public static string gameManagerDataPath = Application.persistentDataPath + "/GameManagerData.txt";
    public static string shopManagerDataPath = Application.persistentDataPath + "/ShopManagerData.txt";
    public static string inventoryManagerDataPath = Application.persistentDataPath + "/InventoryManagerData.txt";
    public static BinaryFormatter binaryFormatter = new BinaryFormatter();

    public static void SaveGameManagerData()
    {
        GameManagerData gameManagerData = new GameManagerData();
        FileStream fileStream = new FileStream(gameManagerDataPath, FileMode.Create);
        binaryFormatter.Serialize(fileStream, gameManagerData);
        fileStream.Close();
    }

    public static GameManagerData LoadGameManagerData()
    {
        if(File.Exists(gameManagerDataPath))
        {
            FileStream fileStream = new FileStream(gameManagerDataPath, FileMode.Open);
            GameManagerData gameManagerData = (GameManagerData) binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return gameManagerData;
        }
        else
        {
            return null;
        }
    }

    public static void SaveShopManagerData()
    {
        ShopManagerData shopManagerData = new ShopManagerData();
        FileStream fileStream = new FileStream(shopManagerDataPath, FileMode.Create);
        binaryFormatter.Serialize(fileStream, shopManagerData);
        fileStream.Close();
    }

    public static ShopManagerData LoadShopManagerData()
    {
        if(File.Exists(shopManagerDataPath))
        {
            FileStream fileStream = new FileStream(shopManagerDataPath, FileMode.Open);
            ShopManagerData shopManagerData = (ShopManagerData) binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return shopManagerData;
        }
        else
        {
            return null;
        }
    }

    public static void SaveInventoryManagerData()
    {
        InventoryData inventoryData = new InventoryData();
        FileStream fileStream = new FileStream(inventoryManagerDataPath, FileMode.Create);
        binaryFormatter.Serialize(fileStream, inventoryData);
        fileStream.Close();
    }

    public static InventoryData LoadInventoryManagerData()
    {
        if(File.Exists(inventoryManagerDataPath))
        {
            FileStream fileStream = new FileStream(inventoryManagerDataPath, FileMode.Open);
            InventoryData inventoryData = (InventoryData) binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return inventoryData;
        }
        else
        {
            return null;
        }
    }
}